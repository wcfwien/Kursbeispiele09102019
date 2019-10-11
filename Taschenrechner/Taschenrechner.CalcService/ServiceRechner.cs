using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.CalcService
{
    public partial class ServiceRechner : ServiceBase
    {
        ServiceHost host;

        public ServiceRechner()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (host != null) host.Close();
            host = new ServiceHost(typeof(RechnerService));
            host.Open();
        }

        protected override void OnStop()
        {
            if (host != null)
            {
                host.Close();
                host = null;
            }
        }
    }
}
