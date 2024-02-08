using Application.Entities.Users.Commands;
using Application.Interface.Common;
using Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Users.Handlers
{
	public class AccessAdminToUserHandler : IRequestHandler<AccessAdminToUser, bool>
	{
		private readonly IUnitOfWork _unitOfWork;

		public AccessAdminToUserHandler(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle( AccessAdminToUser request, CancellationToken cancellationToken )
		{
			var user = await _unitOfWork.UserManager.FindByIdAsync(request.UserId.ToString());

			if (user == null)
				return false;

			var roleResult = await CreateUserRoleOrFindRole("Admin");

			if (roleResult == null)
				return false;

			var addRoleResult = await _unitOfWork.UserManager.AddToRoleAsync(user, roleResult.Name);

			return addRoleResult.Succeeded;

		}
		
		private async Task<Role> CreateUserRoleOrFindRole( string rolename )
		{

			var ExistRole = await _unitOfWork.RoleManager.FindByNameAsync(rolename);
			if (ExistRole == null)
			{
				var result = await _unitOfWork.RoleManager.CreateAsync(new Role()
				{
					Name = rolename,
					Description = $"this role for {rolename} ",
					RoleName = rolename,
					NormalizedName = rolename
				});
				var Findrole= await _unitOfWork.RoleManager.FindByNameAsync(rolename);
				if (Findrole == null)
					return null;
				return Findrole;
				
			}
			return ExistRole;
		}
	}
}
