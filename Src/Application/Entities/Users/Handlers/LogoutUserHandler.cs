
using Application.Entities.Users.Commands;
using Application.Interface.Common;
using AutoMapper;
using MediatR;

namespace Application.Entities.Users.Handlers
{
	public class LogoutUserHandler : IRequestHandler<LogoutUser, bool>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public LogoutUserHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
			_mapper = mapper;
			_unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle( LogoutUser request, CancellationToken cancellationToken )
		{
			await _unitOfWork.SignInManager.SignOutAsync();
			return true;
		}
	}
}
