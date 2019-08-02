using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SiteMonitoramento.Models;

namespace SiteMonitoramento.Extensions
{
    public static class DependenciesExtensions
    {
        public static IHealthChecksBuilder AddDependencies(
            this IHealthChecksBuilder builder,
            List<Dependency> dependencies)
        {
            foreach (var dependencia in dependencies)
            {
                string nomeDependencia = dependencia.Name.ToLower();

                if (nomeDependencia.StartsWith("sqlserver-"))
                    builder = builder.AddSqlServer(dependencia.ConnectionString, name: dependencia.Name);
                else if (nomeDependencia.StartsWith("mongodb-"))
                    builder = builder.AddMongoDb(dependencia.ConnectionString, name: dependencia.Name);
                else if (nomeDependencia.StartsWith("redis-"))
                    builder = builder.AddRedis(dependencia.ConnectionString, name: dependencia.Name);
                else if (nomeDependencia.StartsWith("postgres-"))
                    builder = builder.AddNpgSql(dependencia.ConnectionString, name: dependencia.Name);
                else if (nomeDependencia.StartsWith("mysql-"))
                    builder = builder.AddMySql(dependencia.ConnectionString, name: dependencia.Name);
                else if (nomeDependencia.StartsWith("url-"))
                    builder = builder.AddUrlGroup(new Uri(dependencia.Url), name: dependencia.Name);
                else if (nomeDependencia.StartsWith("rabbitmq-"))
                    builder = builder.AddRabbitMQ(dependencia.ConnectionString, name: dependencia.Name);
                else if (nomeDependencia.StartsWith("azureservicebusqueue-"))
                    builder = builder.AddAzureServiceBusQueue(dependencia.ConnectionString, queueName: dependencia.QueueName, name: dependencia.Name);
                else if (nomeDependencia.StartsWith("azureblobstorage-"))
                    builder = builder.AddAzureBlobStorage(dependencia.ConnectionString, name: dependencia.Name);
                else if (nomeDependencia.StartsWith("documentdb-"))
                {
                    builder = builder.AddDocumentDb(
                        docdb => {
                            docdb.UriEndpoint = dependencia.UriEndpoint;
                            docdb.PrimaryKey = dependencia.PrimaryKey;
                        });
                }                    
            }

            return builder;
        }
    }
}