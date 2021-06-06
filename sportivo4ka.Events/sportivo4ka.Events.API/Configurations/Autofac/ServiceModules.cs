using Autofac;
using AutoMapper;
using Divergic.Configuration.Autofac;
using sportivo4ka.Events.API.Configurations.AutoMapper;
using sportivo4ka.Events.BI.Options;
using System;
using sportivo4ka.Events.BI.Interfaces;
using sportivo4ka.Events.BI.Services;

namespace sportivo4ka.Events.API.Configurations.Autofac
{
    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Event>()
                 .As<IEvent>();

            builder.RegisterType<Checker>()
                .As<IChecker>();

            builder.RegisterType<DataSend>()
                .As<IDataSend>();

            builder.RegisterType<Attachment>()
                .As<IAttachment>();

            builder.RegisterType<BI.Services.Dadata>()
                .As<IDadata>();

            builder.RegisterType<CreateEventToDto>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var resolver = new EnvironmentJsonResolver<Config>("appsettings.json", $"appsettings.{env}.json");
            var module = new ConfigurationModule(resolver);

            builder.RegisterModule(module);
        }
    }
}
