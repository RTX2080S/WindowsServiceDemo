﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDemo
{
    public partial class ServiceDemo : ServiceBase
    {
        public ServiceDemo()
        {
            InitializeComponent();

            //Setup Service
            this.ServiceName = "WindowsService Demo";
            this.CanStop = true;
            this.CanPauseAndContinue = true;

            //Setup logging
            this.AutoLog = false;

            ((ISupportInitialize)this.EventLog).BeginInit();
            if (!EventLog.SourceExists(this.ServiceName))
            {
                EventLog.CreateEventSource(this.ServiceName, "Application");
            }
            ((ISupportInitialize)this.EventLog).EndInit();

            this.EventLog.Source = this.ServiceName;
            this.EventLog.Log = "Application";
        }

        protected override void OnStart(string[] args)
        {
            this.EventLog.WriteEntry($"{this.ServiceName} Started");
        }

        protected override void OnStop()
        {
            this.EventLog.WriteEntry($"{this.ServiceName} Stopped");
        }        
    }
}
