using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RentACar.Business.Abstract;
using RentACar.Business.Concrete;
using RentACar.Business.DependencyResolvers.Autofac;
using RentACar.Core.Utilities.IoC;
using RentACar.Core.Utilities.Security.Encryption;
using RentACar.Core.Utilities.Security.JWT;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

         var builder = WebApplication.CreateBuilder(args);

         builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(p =>
          p.RegisterModule(new AutofacBusinessModule())
         );

            // Add services to the container.

         builder.Services.AddControllers();
         // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();

            //builder.Services.AddSingleton<ICarService, CarManager>();
            //builder.Services.AddSingleton<ICarDal, EfCarDal>();

            //builder.Services.AddSingleton<IRentalService, RentalManager>();
            //builder.Services.AddSingleton<IRentalDal, EfRentalDal>();

            //builder.Services.AddSingleton<IColorService, ColorManager>();
            //builder.Services.AddSingleton<IColorDal, EfColorDal>();

            //builder.Services.AddSingleton<IBrandService, BrandManager>();
            //builder.Services.AddSingleton<IBrandDal, EfBrandDal>();

            //builder.Services.AddSingleton<ICustomerService, CustomerManager>();
            //builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

            //builder.Services.AddSingleton<IUserService, UserManager>();
            //builder.Services.AddSingleton<IUserDal, EfUserDal>();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidIssuer = tokenOptions.Issuer,
                                    ValidAudience = tokenOptions.Audience,
                                    ValidateIssuerSigningKey = true,
                                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                                };
                            });
            ServiceTool.Create(builder.Services);


            var app = builder.Build();

         // Configure the HTTP request pipeline.
         if (app.Environment.IsDevelopment())
         {
                app.UseSwagger();
                app.UseSwaggerUI();
         }

         app.UseHttpsRedirection();

         app.UseAuthorization();

         app.UseAuthentication();

         app.MapControllers();

         app.Run();

        }
    }
}

