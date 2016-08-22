using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Framework;

namespace TodoList.Api
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JsonSerializableHelper>().As<IJsonSerializable>();//.InstancePerLifetimeScope();

            //base.Load(builder);
        }
    }
}
