using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HackathonApi.Models;
using HackathonApi.Models.Context;
using Microsoft.AspNetCore;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace HackathonApi
{
    public class Startup
    {
        private readonly KeyVaultClient _keyVaultClient;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AzureServiceTokenProvider tokenProvider = new AzureServiceTokenProvider();
            _keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(tokenProvider.KeyVaultTokenCallback));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<JournalEntryContext>(opt => opt.UseSqlServer(_keyVaultClient.GetSecretAsync(Configuration.GetSection("Secrets:Database:Name").Value).Result.Value));
            services.AddDbContext<UserDataContext>(opt => opt.UseSqlServer(_keyVaultClient.GetSecretAsync(Configuration.GetSection("Secrets:Database:Name").Value).Result.Value));
            services.AddDbContext<GoalDataContext>(opt => opt.UseSqlServer(_keyVaultClient.GetSecretAsync(Configuration.GetSection("Secrets:Database:Name").Value).Result.Value));
            services.AddDbContext<GoalContext>(opt => opt.UseSqlServer(_keyVaultClient.GetSecretAsync(Configuration.GetSection("Secrets:Database:Name").Value).Result.Value));
            services.AddDbContext<FeelingContext>(opt => opt.UseSqlServer(_keyVaultClient.GetSecretAsync(Configuration.GetSection("Secrets:Database:Name").Value).Result.Value));
            services.AddDbContext<PromptContext>(opt => opt.UseSqlServer(_keyVaultClient.GetSecretAsync(Configuration.GetSection("Secrets:Database:Name").Value).Result.Value));
            services.AddDbContext<ProblemContext>(opt => opt.UseSqlServer(_keyVaultClient.GetSecretAsync(Configuration.GetSection("Secrets:Database:Name").Value).Result.Value));
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<KeyVaultClient>(_keyVaultClient);
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
