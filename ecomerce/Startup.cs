using ecomerce.Model;
using ecomerce.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ecomerce.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using ecomerce.Settings;
using ecomerce.Data;
using Stripe;

namespace ecomerce
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
            services.Configure<JWT>(Configuration.GetSection("JWT"));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailingService,MailingService>();
            
            services.AddDbContext<dbSmartAgricultureContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Default")));
            //  services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<IAuthService, AuthServive>();
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<dbSmartAgricultureContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "e-commerce", Version = "v1" });
            });
            // services.AddTransient<IEmailSender, EmailSender>();
            services.AddAuthentication(options =>
            {
               //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                    };
                });

            //services.Configure<IdentityOptions>(opts =>
            //{
            //    opts.User.RequireUniqueEmail = true;
                

            //    opts.SignIn.RequireConfirmedEmail = true;

            //    opts.Lockout.AllowedForNewUsers = true;
            //    opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            //    opts.Lockout.MaxFailedAccessAttempts = 3;
            //});



            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;

            });

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddMvc();
            services.AddControllersWithViews();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.AddDbContext<dbSmartAgricultureContext>();

            services.AddRazorPages();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = "sk_test_51KxFLjKcqUX17Ez0AEf4baGXN8uEA2lIVU8dwuxoLXhiBJ7armCGRVIPv4wfz54kcmsLsjbrQyqrH8QcHbBW5JiY00Xc6CRjkR";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "e-commerce v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();


            app.Use(async (context, next) => 
            {   
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next(); 
            
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            // app.UseJwtTokenMiddleware();
            //app.UseMvcWithDefaultRoute();




            app.UseSession();






            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            
        }
    }
}
