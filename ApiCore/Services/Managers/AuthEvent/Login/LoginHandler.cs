using Business.TService;
using Core.Helper;
using Core.Results;
using Entities;
using Entities.JWTEntity;
using MediatR;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Business.Managers.AuthEvent.Login
{
    public partial class LoginHandler : IRequestHandler<LoginQuery, JWTResponse>
    {
        private readonly IService<User> _userService;
        private readonly IService<UserRole> _userRoleService;
        private readonly JwtSettings JwtSettings;

        public LoginHandler(IService<User> userService, IService<UserRole> userRoleService, IOptions<JwtSettings> jwtSettings)
        {
            this.JwtSettings = jwtSettings.Value;
            _userService = userService;
            _userRoleService = userRoleService;
        }
        public async Task<JWTResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            List<string> roles = new();
            var Model = await _userService.GetAllAsync(x => x.Username == request.Username && x.Password == request.Password);

            if (Model.ModelCount == 0)
                return new JWTResponse() { ErrorMessage = "Kullancı Adı Veya Şifre Hatalı", Status = false };
            if (Model.ListResponseModel.FirstOrDefault().Is_Active == false)
                return new JWTResponse() { ErrorMessage = "Kullancı Aktif Değildir.", Status = false };
            var test = Model.ListResponseModel.FirstOrDefault().ID;
           
            var userRoleList = await _userRoleService.GetAllInculudeAsync(x => x.UserId == Model.ListResponseModel.FirstOrDefault().ID, x => x.Role);


            if (userRoleList.Status == true)
                roles = userRoleList.ListResponseModel.Select(x => x.Role.Name).ToList(); ;

            List<Claim> claims = new()
                    {
                        new(ClaimTypes.Name, Model.ListResponseModel.FirstOrDefault().Username),
                        new(ClaimTypes.GivenName, Model.ListResponseModel.FirstOrDefault().Name),
                        new(ClaimTypes.Surname, Model.ListResponseModel.FirstOrDefault().Surname),
                        new(ClaimTypes.Email, Model.ListResponseModel.FirstOrDefault().Email),
                        new(ClaimTypes.NameIdentifier, Model.ListResponseModel.FirstOrDefault().ID.ToString()),
                        new(ClaimTypes.Authentication, Model.ListResponseModel.FirstOrDefault().ID.ToString()),
                    };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            TokenModel token = JwtHelper.GetJwtToken(JwtSettings, claims);
            return new JWTResponse() { TokenResponse = token, Status = true };

        }
    }
}