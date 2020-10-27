using System.Reflection;
using AutoMapper;
using Cryptocop.Software.API.Mappings;
using Cryptocop.Software.API.Middlewares;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Implementations;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Implementations;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cryptocop.Software.API
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            
            // Databases
            services.AddDbContext<CryptocopDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("CryptoCopDatabase"), options =>
                {
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            });
            
            // Authentication
            services.AddAuthentication(config =>
            {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtTokenAuthentication(Configuration);
            
            // AutoMapper
            var mappingProfile = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingProfile.CreateMapper();
            services.AddSingleton(mapper);

            // Service Transients
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICryptoCurrencyService, CryptoCurrencyService>();
            services.AddTransient<IExchangeService, ExchangeService>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IQueueService, QueueService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            
            var jwtConfig = Configuration.GetSection("JwtConfig");
            services.AddTransient<ITokenService>((c) => new TokenService(
                jwtConfig.GetSection("secret").Value,
                jwtConfig.GetSection("expirationInMinutes").Value,
                jwtConfig.GetSection("issuer").Value,
                jwtConfig.GetSection("audience").Value
            ));
            
            // Repository Transients
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.ConfigureExceptionHandler();
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
