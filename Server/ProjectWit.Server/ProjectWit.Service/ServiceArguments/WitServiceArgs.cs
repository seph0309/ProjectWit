using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Web;
using System.Runtime.Serialization;
using Ninject;
using Ninject.Modules;
using ProjectWit.Model;

namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public abstract class WitServiceArgs : ILogger
    {
        protected List<string> LogMessages = new List<string>();
        
        protected string _deviceType;
        protected string _browser;
        protected string _iP { get { return GetIP(); } }
        protected string _location;
        protected string _userUID;
        protected string _companyUID;
        protected IKernel kernel;

        public WitServiceArgs()
        {
            kernel = new StandardKernel();
            kernel.Load(new WitServiceLocator());
        }


        public void LogMsg(string message)
        {
            LogMessages.Add(message);
        }

        public void SaveLogToText(string message)
        {
            throw new NotImplementedException();
        }

        public void SaveLogToEvent(string message)
        {
            throw new NotImplementedException();
        }

        private string GetIP()
        {
            string ip = string.Empty;

            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint =
                    prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                ip = endpoint.Address;
            }
            return ip;
        }

    }
}