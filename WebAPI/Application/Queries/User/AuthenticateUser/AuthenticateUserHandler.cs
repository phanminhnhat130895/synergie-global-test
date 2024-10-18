﻿using Application.Repository;
using Application.Security;
using MediatR;

namespace Application.Queries.User.AuthenticateUser
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserRequest, AuthenticateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;

        public AuthenticateUserHandler(IUserRepository userRepository, IJwtHandler jwtHandler) 
        { 
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
        }

        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

            if (user == null)
            {
                throw new Exception("Email or password is incorrect.");
            }

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isPasswordValid)
            {
                throw new Exception("Email or password is incorrect.");
            }

            var accessToken = _jwtHandler.Create(user);

            return new AuthenticateUserResponse(accessToken);
        }
    }
}
