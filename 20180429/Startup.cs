using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _20180429.Helper.LogHelper;
using _20180429.Models;
using _20180429.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace _20180429
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
            var strCnn = Configuration.GetConnectionString("strCnn");
            //(new LogInfo()).RegLogInfo(string.Format("strCnn: {0}", strCnn));
            //services.AddDbContext<BDadosContext>(options => options.UseSqlite(Configuration.GetConnectionString("strCnn")));
            //services.AddDbContext<BDadosContext>(options => options.UseSqlServer(Configuration.GetConnectionString("strCnn")));
            services.AddDbContext<BDadosContext>(options => options.UseMySql(strCnn));
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddTransient<ILocacaoRepositorio, LocacaoRepositorio>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
