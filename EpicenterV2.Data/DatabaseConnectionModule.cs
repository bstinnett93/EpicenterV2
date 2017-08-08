using System.Data;
using System.Data.SqlClient;
using Autofac;

namespace EpicenterV2
{
    public class DatabaseConnectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IDbConnection>(c => new SqlConnection("Server=BSTINNETT-LPT\\SS2016;Database=EpicenterV2;Trusted_Connection=True;"))
                .As<IDbConnection>().InstancePerLifetimeScope();
        }
    }
}