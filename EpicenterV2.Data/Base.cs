using System.Data;
using Autofac;

namespace EpicenterV2.Data
{
    public class Base
    {
        protected IContainer Container;
        protected readonly IDbConnection Connection;

        public Base()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(DatabaseConnectionModule).Assembly);
            Container = builder.Build();
            Connection = Container.Resolve<IDbConnection>();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}