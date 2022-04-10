using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.API.Filters;
using eTuristickaAgencija.API.Security;
using eTuristickaAgencija.API.Services;
using eTuristickaAgencija.Models.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API
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
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers(x =>
            {
                x.Filters.Add<ErrorFilter>();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eTuristickaAgencija API", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddDbContext<TuristickaAgencijaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IPreporukaService, PreporukeService>();
            services.AddScoped<IService<Models.Grad, object>, BaseService<Models.Grad, object, Grad>>();
            services.AddScoped<IService<Models.Uloga, object>, BaseService<Models.Uloga, object, Uloga>>();
            services.AddScoped<ICRUDService<Models.Destinacija, DestinacijaSearchRequest, DestinacijaInsertRequest, DestinacijaInsertRequest>, DestinacijeService>();
            services.AddScoped<ICRUDService<Models.Hotel, HotelSearchRequest, HotelInsertRequest, HotelInsertRequest>, HoteliService>();
            services.AddScoped<ICRUDService<Models.Termin, TerminSearchRequest, TerminInsertRequest, TerminInsertRequest>, TerminiService>();
            services.AddScoped<ICRUDService<Models.Ocjena, OcjenaSearchRequest, OcjenaInsertRequest, OcjenaInsertRequest>, OcjeneService>();
            services.AddScoped<ICRUDService<Models.Karta, KartaSearchRequest, KartaInsertRequest, KartaInsertRequest>, KarteService>();
            services.AddScoped<ICRUDService<Models.Clan, ClanSearchRequest, ClanInsertRequest, ClanInsertRequest>, ClanoviService>();
            services.AddScoped<ICRUDService<Models.Grad, GradoviSearchRequest, GradoviInsertRequest, GradoviInsertRequest>, GradoviService>();
            services.AddScoped<ICRUDService<Models.Drzava, DrzavaSearchRequest, DrzavaInsertRequest, DrzavaInsertRequest>, DrzaveService>();
            services.AddScoped<ICRUDService<Models.Kontinent, KontinentSearchRequest, KontinentInsertRequest, KontinentInsertRequest>, KontinentiService>();
            services.AddScoped<ICRUDService<Models.Uposlenik, UposlenikSearchRequest, UposlenikInsertRequest, UposlenikInsertRequest>, UposlenikService>();
            services.AddScoped<ICRUDService<Models.Rezervacija, RezervacijaSearchRequest, RezervacijaInsertRequest, RezervacijaInsertRequest>, RezervacijaService>();



            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
