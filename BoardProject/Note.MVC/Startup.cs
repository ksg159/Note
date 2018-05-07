using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Note.BLL;
using Note.DAL;
using Note.IDAL;
using ReflectionIT.Mvc.Paging;

namespace Note.MVC
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
            services.AddSingleton(Configuration);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options => options.LoginPath = new PathString("/Account/Login"));


            services.AddMvc();
            services.AddPaging();
            services.AddTransient<NoticeBll>();
            services.AddTransient<UserBll>();
            services.AddTransient<BoardBll>();
        
            services.AddTransient<INoticeDal, NoticeDal>();
            services.AddTransient<IUserDal, UserDal>();
            services.AddTransient<IBoardDal, BoardDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
         

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
