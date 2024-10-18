using Application.Repository;
using Core.Entities;
using MediatR;

namespace Application.Commands.Users.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User(Guid.NewGuid())
                            .SetEmail(request.Email)
                            .SetPassword(request.Password);

            await _userRepository.CreateAsync(user, cancellationToken);

            await _unitOfWork.SaveAsync(cancellationToken);

            return new CreateUserResponse(true);
        }
    }
}
