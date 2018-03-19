using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Snorlax.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(options=>{
                    options.SerializerSettings.NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore;
                    // options.SerializerSettings.DefaultValueHandling=Newtonsoft.Json.DefaultValueHandling.Ignore;
                });

            AppConfig.Build();
            
            services
                .RegisterTools()
                .RegisterConfig()
                .RegisterDBContext()
                .RegisterRepository();
                
            services
                .AddAuthentication(opitons=>{
                    opitons.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                    opitons.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options=>{
                    options.TokenValidationParameters=new TokenValidationParameters(){
                        ValidateAudience=true,
                        ValidAudience=AppConfig.Current.ValidAudience,
                        ValidIssuer=AppConfig.Current.ValidIssuer,
                        ValidateLifetime=true,
                        ValidateIssuerSigningKey=true, 
                        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfig.Current.SeckretKey))
                    };

                    options.Events=new JwtBearerEvents{
                        // OnTokenValidated=ctx=>{
                        //     return Task.CompletedTask;
                        // },
                        OnAuthenticationFailed=ctx=>{
                            ctx.Response.StatusCode=401;
                            return Task.CompletedTask;
                        },
                    };
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }
            // else
            // {
            //     app.UseExceptionHandler("/Home/Error");
            // }
            app.UseAuthentication();
            app.UseCors(builder =>
                builder.AllowAnyOrigin()//.WithOrigins("http://localhost:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            );
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
