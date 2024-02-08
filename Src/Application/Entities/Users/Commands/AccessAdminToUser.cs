using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Users.Commands
{
	public class AccessAdminToUser :IRequest<bool>
	{
        public Guid UserId { get; set; }
    }
}
