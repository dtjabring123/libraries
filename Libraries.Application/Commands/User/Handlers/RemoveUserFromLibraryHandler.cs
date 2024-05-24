using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.User.Handlers
{
    public class RemoveUserFromLibraryHandler : IRequestHandler<RemoveUserFromLibraryCommand, UserDto>
    {
        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RemoveUserFromLibraryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(RemoveUserFromLibraryCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _userRepository.RemoveFromLibrary(request.Id));
        }
    }
}