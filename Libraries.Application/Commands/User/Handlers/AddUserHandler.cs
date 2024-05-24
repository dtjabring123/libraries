using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.User.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserDto>
    {
        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity
            {
                Name = request.Name,
                Email = request.Email,
            };
            return _mapper.Map<UserDto>(await _userRepository.Add(user));
        }
    }
}