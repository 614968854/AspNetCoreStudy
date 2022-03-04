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
            CreateHostBuilder(args).//����һ��ʵ��IHostBuilder�Ķ���
                Build().//��ASP.NET CoreӦ�ó������ɲ��йܵ���������
                Run();//ASP.NET CoreӦ�ó���ʼ���������HTTP����
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //��������Ĭ��ֵ
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();//ʹ��Startup���������
                });
    }
}
