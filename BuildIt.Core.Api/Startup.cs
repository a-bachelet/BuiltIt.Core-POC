using Autofac;
using Autofac.Features.Variance;
using BuildIt.Core.Domain.FeatureProviders;
using BuildIt.Core.Domain.Generic.Classes;
using BuildIt.Core.Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BuildIt.Core.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc().ConfigureApplicationPartManager(m =>
            {
                m.FeatureProviders.Add(new GenericControllerFeatureProvider());
            });

            services.AddSwaggerGen();

            services.AddDbContextPool<GenericDbContext>(options => options.UseMySql(_configuration.GetConnectionString("DefaultConnection")));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder
                .RegisterSource(new ContravariantRegistrationSource());
            
            builder
                .Register<ServiceFactory>(ctx => {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });
            
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(GenericGetManyQuery<>))
                .As(typeof(IRequest<>));

            builder
                .RegisterGeneric(typeof(GenericGetManyHandler<,>))
                .As(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();
            
            builder
                .RegisterGeneric(typeof(GenericGetOneQuery<>))
                .As(typeof(IRequest<>));

            builder
                .RegisterGeneric(typeof(GenericGetOneHandler<,>))
                .As(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();
            
            builder
                .RegisterGeneric(typeof(GenericCreateCommand<>))
                .As(typeof(IRequest<>));

            builder
                .RegisterGeneric(typeof(GenericCreateHandler<,>))
                .As(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();
            
            builder
                .RegisterGeneric(typeof(GenericUpdateCommand<>))
                .As(typeof(IRequest<>));

            builder
                .RegisterGeneric(typeof(GenericUpdateHandler<,>))
                .As(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();
            
            builder
                .RegisterGeneric(typeof(GenericDeleteCommand<>))
                .As(typeof(IRequest<>));
            
            builder
                .RegisterGeneric(typeof(GenericDeleteHandler<,>))
                .As(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();

            builder
                .RegisterType(typeof(GenericDbContext))
                .AsImplementedInterfaces();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1.0 API"); });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}