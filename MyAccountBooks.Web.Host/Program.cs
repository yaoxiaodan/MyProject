using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace MyAccountBooks.Web.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                WebBuilder(args).Run();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());

                throw;
            }

        }

        private static IWebHost WebBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).
                UseUrls("http://*:5000").
                UseStartup<Startup>()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    //builder
                    //.AddApollo(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                    //.AddDefault();
                })
                .Build();
    }
}

