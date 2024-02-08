using Application.Entities.Users.Commands;
using Application.Interface.Common;
using AutoMapper;
using Domain.Entities.Users;
using MediatR;


namespace Application.Entities.Users.Handlers
{
    public class RegisterUserHadler : IRequestHandler<RegisterUser, ResultRegister>
    {

    
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterUserHadler( IUnitOfWork unitOfWork, IMapper mapper)
        {
           
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResultRegister> Handle( RegisterUser request, CancellationToken cancellationToken )
        {
            var newuser=_mapper.Map<User>( request);
            var result=await _unitOfWork.UserManager.CreateAsync(newuser,request.Password);
            if (result.Succeeded)
            {
                var exsistRole=   await CreateUserRoleOrFindRole(request.Rolename);
                if (exsistRole)
                {
                   var Res= await _unitOfWork.UserManager.AddToRoleAsync(newuser, request.Rolename);
                   if (Res.Succeeded)
                   {
                        var userdata = _mapper.Map<UserDto>(newuser);
                        return new(userdata);
                   }
                }
                
            }  
            return new(result.Errors);
            
        }
        private async Task<bool> CreateUserRoleOrFindRole( string rolename )
        {

           var ExistRole= await _unitOfWork.RoleManager.FindByNameAsync( rolename );
            if (ExistRole == null)
            {
                var result = await _unitOfWork.RoleManager.CreateAsync(new Role()
                {
                    Name = rolename,
                    Description = $"this role for {rolename} ",
                    RoleName = rolename,
                    NormalizedName = rolename
                });
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;





        }
    }
}
