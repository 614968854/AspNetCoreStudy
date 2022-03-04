using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement
{
    public class Startup
    {
        /// <summary>
        /// ���ڶ�ȡ������Ϣ
        /// </summary>
        private IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration">ע��IConfiguration</param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// ����Ӧ�ó�������ķ���
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// ����Ӧ�ó����������ܵ�
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                logger.LogInformation($"MW1����������{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}");
                await next();
                logger.LogInformation($"MW1��������Ӧ{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation($"MW2����������{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}");
                await next();
                logger.LogInformation($"MW2��������Ӧ{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}");
            });

            app.Run(async context =>
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"MW3����������������Ӧ{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}");
                logger.LogInformation($"MW3����������������Ӧ{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}");
            });
        }
    }
}
