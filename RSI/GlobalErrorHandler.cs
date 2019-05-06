using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace RSI
{
    public class GlobalErrorHandler : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var newEx = new FaultException(
                $@"Exception caught at Service Application 
			GlobalErrorHandler {Environment.NewLine} Method: {error.TargetSite.Name} {Environment.NewLine} Message: {error.Message}");

            var msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
        }

        public bool HandleError(Exception error)
        {
            return true;
        }
    }
}