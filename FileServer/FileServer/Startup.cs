using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace FileServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser(); //绑定文件服务
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            var dir = new DirectoryBrowserOptions();
            dir.FileProvider = new PhysicalFileProvider(@"C:\");   

            app.UseDirectoryBrowser(dir);     //打开目录

            var staticfile = new StaticFileOptions();
            staticfile.FileProvider = new PhysicalFileProvider(@"C:\");//指定目录

            staticfile.ServeUnknownFileTypes = true;
            staticfile.DefaultContentType = "application/x-msdownload";//设置为默认，浏览器会自动下载这些文件

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Add(".log", "text/plain"); //手动设置对应MIME Type
            staticfile.ContentTypeProvider = provider;

            app.UseStaticFiles(staticfile); //打开目录文件

            //app.UseStaticFiles();//默认使用文件夹wwwroot
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
