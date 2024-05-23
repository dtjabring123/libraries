using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.User.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity
            {
                Id = request.Id,
                LibraryId = request.LibraryId,
                Name = request.Name,
                Email = request.Email,
            };
            return _mapper.Map<UserDto>(await _userRepository.Update(user));
        }
    }
}