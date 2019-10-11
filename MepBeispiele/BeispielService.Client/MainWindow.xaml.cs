using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeispielService.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InstanceContext instance;
        ServiceReference1.SampleServiceClient client;
        
        public MainWindow()
        {
            InitializeComponent();

            instance = new InstanceContext(new CallbackHandler());
            client = new ServiceReference1.SampleServiceClient(instance);
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "Request/Response: Aufruf der WCF Service Methode 1";
            client.TestMethod1();
            txtResult.Text = "Request/Response: WCF service Methode1 erfolgreich ausgeführt...";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "One Way: Aufruf der WCF Service Methode 2";
            client.TestMethod2();
            txtResult.Text = "One Way: WCF service Methode2 erfolgreich ausgeführt...";

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "Duplex: Aufruf der WCF Service Methode 3";
            client.TestMethod3();
            txtResult.Text = "Duplex: WCF service Methode3 erfolgreich ausgeführt...";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client.TestMethod1Completed +=
                new EventHandler<AsyncCompletedEventArgs>(client_TestMethod1Completed);
            client.TestMethod1Async();
        }

        private void client_TestMethod1Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Request/Response: TestMethode1Async erfolgreich ausgeführt");
        }
    }

    public class CallbackHandler : ServiceReference1.ISampleServiceCallback 
    {
        public void NotifyClient(string message) 
        {
            MessageBox.Show(message);
        } 
    }
}
