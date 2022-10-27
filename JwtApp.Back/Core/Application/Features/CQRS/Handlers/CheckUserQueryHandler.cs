using JwtApp.Back.Core.Application.Dto;
using JwtApp.Back.Core.Application.Features.CQRS.Queries;
using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;
using System.Xml;

namespace JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserDto>
    {
        private readonly IRepository<AppUser> _userrepo;
        private readonly IRepository<AppRole> _rolerepo;

        public CheckUserQueryHandler(IRepository<AppUser> userrepo, IRepository<AppRole> rolerepo)
        {
            _userrepo = userrepo;
            _rolerepo = rolerepo;
        }

        public async Task<CheckUserDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserDto();
            var user = await _userrepo.GetByFilterAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if(user == null)
            {
                dto.IsExist = false;
            }
            else 
            { 
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await _rolerepo.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }

            return dto;
        }
    }
}
