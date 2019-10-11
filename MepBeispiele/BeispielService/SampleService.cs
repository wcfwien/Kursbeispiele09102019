using System;
using System.ServiceModel;
using System.Threading;

namespace BeispielService
{
    public class SampleService : ISampleService
    {
        public void TestMethod1()
        {
            Thread.Sleep(2000);
        }

        public void TestMethod2()
        {
            Thread.Sleep(4000);
        }
        //public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> TestFunction1Completed;

        public void TestMethod3()
        {
            Thread.Sleep(6000);

            ICallBack callBack = OperationContext.Current.GetCallbackChannel<ICallBack>();
            callBack.NotifyClient("TestMethod3 wurde erfolgreich ausgeführt...");
        }
    }
}
