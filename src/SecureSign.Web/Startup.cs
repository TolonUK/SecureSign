﻿/**
 * Copyright (c) 2017 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the MIT license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SecureSign.Core.Extensions;
using SecureSign.Web.Controllers;
using SecureSign.Web.Middleware;

namespace SecureSign.Web
{
    public class Startup
    {
	    public Startup(IConfiguration configuration)
	    {
		    Configuration = configuration;
	    }

	    public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddSecureSignCore(Configuration);
			services.TryAddSingleton<SigningControllerUtils>();
			services.Configure<FormOptions>(x =>
			{
				x.MultipartBodyLengthLimit = Constants.MAX_ARTIFACT_SIZE;
			});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
	        app.UseJsonExceptionHandler(isDev: env.IsDevelopment());
	        app.UseRouting();
	        app.UseEndpoints(endpoints =>
	        {
		        endpoints.MapControllerRoute(
			        name: "default",
			        pattern: "{controller}/{action=Index}/{id?}"
		        );
	        });
        }
    }
}
