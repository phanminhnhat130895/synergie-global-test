﻿using Application.Common;
using Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Security
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _settings;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private SecurityKey _issuerSigningKey;
        private SigningCredentials _signingCredentials;
        private JwtHeader _jwtHeader;
        public TokenValidationParameters Parameters { get; private set; }

        public JwtHandler(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
            if (_settings.UseRsa)
            {
                InitializeRsa();
            }
            else
            {
                InitializeHmac();
            }

            InitializeJwtParameters();
        }

        private void InitializeRsa()
        {
            using (RSA publicRsa = RSA.Create())
            {
                var publicKeyXml = File.ReadAllText(_settings.RsaPublicKey);
                RsaExtension.FromXmlString(publicRsa, publicKeyXml);
                _issuerSigningKey = new RsaSecurityKey(publicRsa);
            }
            if (string.IsNullOrEmpty(_settings.RsaPrivateKey))
            {
                return;
            }
            using (RSA privateRsa = RSA.Create())
            {
                var privateKeyXml = File.ReadAllText(_settings.RsaPrivateKey);
                RsaExtension.FromXmlString(privateRsa, privateKeyXml);
                var privateKey = new RsaSecurityKey(privateRsa);
                _signingCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.RsaSha256);
            }
        }

        private void InitializeHmac()
        {
            _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.HmacSecretKey));
            _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
        }

        private void InitializeJwtParameters()
        {
            _jwtHeader = new JwtHeader(_signingCredentials);
            Parameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidIssuer = _settings.Issuer,
                ValidateAudience = true,
                ValidAudience = _settings.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _issuerSigningKey
            };
        }

        public string Create(User user)
        {
            DateTime nowUtc = DateTime.UtcNow;
            DateTime expires;
            if (_settings.ExpiryTime.Contains('h'))
                expires = nowUtc.AddHours(Convert.ToDouble(_settings.ExpiryTime.Replace("h", "")));
            else
                expires = nowUtc.AddDays(Convert.ToDouble(_settings.ExpiryTime.Replace("h", "")));

            var payload = new[]
            {
                new Claim(ClaimType.USERID, user.Id.ToString()),
                new Claim(ClaimType.EMAIL, user.Email),
            };

            JwtSecurityToken token = new JwtSecurityToken(_settings.Issuer, _settings.Issuer, payload, nowUtc, expires, signingCredentials: _signingCredentials);
            return _jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
