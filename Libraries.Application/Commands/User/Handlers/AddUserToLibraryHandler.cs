using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.User.Handlers
{
    public class AddUserToLibraryHandler : IRequestHandler<AddUserToLibraryCommand, UserDto>
    {
        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserToLibraryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(AddUserToLibraryCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _userRepository.AddToLibrary(request.UserId, request.LibraryId));
        }
    }
}