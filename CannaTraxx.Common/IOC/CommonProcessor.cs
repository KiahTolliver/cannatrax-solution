using Autofac;
using CannaTrax.Data.EF.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTraxx.Common.IOC
{
   public class CommonProcessor : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new ProcessorModule());
        }
    }
}
