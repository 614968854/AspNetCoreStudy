using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).//返回一个实现IHostBuilder的对象
                Build().//将ASP.NET Core应用程序生成并托管到服务器上
                Run();//ASP.NET Core应用程序开始侦听传入的HTTP请求
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //程序配置默认值
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();//使用Startup类进行配置
                });
    }
}
