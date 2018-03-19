using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using Snorlax.Repository;
using Snorlax.Utilities;

namespace Snorlax.Web.Api.Controllers
{
    [Route("api/login")]
    [AllowAnonymous()]
    public class LoginController
        : BaseController
    {
        private readonly IAdminRepository _adminRepository;
        public LoginController(
            IAdminRepository adminRepository,
            ILogger logger) 
            : base(logger)
        {
            this._adminRepository=adminRepository;
        }

        [HttpPost]
        [Route("")]
        public async Task<ApiResponse> IndexAsync([FromBody]Models.Request.Login data)
        { 
            // demo için kullanıcı yok ise default kullanıcı eklemesi yapılıyor
            if(await _adminRepository.CountAsync()==0){
                await _adminRepository.AddOneAsync(new Repository.Model.Admin(){
                    Email="admin@snorlax.com",
                    Password="admin",
                    Surname="Snorlax",
                    Name="Admin"
                });
            }
            ApiResponse<Models.TokenModel> result=new ApiResponse<Models.TokenModel>();
            Repository.Model.Admin admin= await _adminRepository.LoginAsync(data.Email,data.Password);
            if(admin!=null)
            {
                await ILogger.WriteAsync("admin bulundu.");
                var claims=new Claim[]{
                    new Claim(JwtRegisteredClaimNames.Email,admin.Email),
                    new Claim(JwtRegisteredClaimNames.UniqueName,admin.Email),
                    new Claim(JwtRegisteredClaimNames.NameId,admin.Id.ToString())
                };
                SecurityKey securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfig.Current.SeckretKey));
                var token=new JwtSecurityToken(
                    issuer:AppConfig.Current.ValidIssuer,
                    audience:AppConfig.Current.ValidAudience,
                    claims:claims,
                    expires:DateTime.Now.AddDays(1),
                    signingCredentials:new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256)
                );
                Models.TokenModel tokenModel=new Models.TokenModel(){
                    Token=new JwtSecurityTokenHandler().WriteToken(token)
                };
                result.Success("giriş başarılı",tokenModel);
            }else{
                result.Error(new ErrorModel(){
                    UserMessage="kullanıcı bilgilerinizi kontrol ediniz."
                });
            }
            return result;
        }
    }
}