using Autofac;
using Autofac.Core;
using FirstGrphql.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace FirstGrphql
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var httpContextAccessor = context.Resolve<IHttpContextAccessor>();
                if(httpContextAccessor.HttpContext.Request.Headers.TryGetValue("db",out var db))
                {
                    var cs = context.Resolve<IConfiguration>().GetConnectionString("AbsCore");
                    var connectionString = new SqlConnectionStringBuilder(cs)
                    {
                        InitialCatalog = db,
                        DataSource="192.168.30.26"
                    }.ToString();

                    var optionBuilder = new DbContextOptionsBuilder<AbsContext>().UseSqlServer(connectionString);
                    return new AbsContext(optionBuilder.Options);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("abs db name not specified in request header");
                }

            }).InstancePerLifetimeScope();
        }
    }
}