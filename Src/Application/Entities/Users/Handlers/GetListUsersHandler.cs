using Application.Entities.Dtos;
using Application.Entities.Users.Queries;
using Application.Interface.Common;
using AutoMapper;
using Domain.Entities.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Users.Handlers
{
	public class GetListUsersHandler : IRequestHandler<GetListUsers, List<UserDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetListUsersHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
        public async Task<List<UserDto>> Handle( GetListUsers request, CancellationToken cancellationToken )
		{
			var Users=await _unitOfWork.UserRepository.Entities.ToListAsync(cancellationToken);
			var UsersDto = new List<UserDto>();
			Users.ForEach(async (user) =>
			{
				var userDto = _mapper.Map<UserDto>(user);
				userDto.IsAdminRole = await _unitOfWork.UserManager.IsInRoleAsync(user, "Admin");
				UsersDto.Add(userDto);
			});
			


			return UsersDto;
		}
	}
}
