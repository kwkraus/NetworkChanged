using System;
using System.Net.NetworkInformation;

namespace UriTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "localhost:5050";
            host = "dav.dev.uspto.gov";

            System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged += new

            System.Net.NetworkInformation.NetworkAddressChangedEventHandler(AddressChangedCallback);
            Console.WriteLine("Listening for address changes. Press any key to exit.");
            Console.ReadLine();
            bool connected = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (connected)
            {
                Uri validUri = null;
                bool isValid = Uri.TryCreate(host, UriKind.RelativeOrAbsolute, out validUri);

                UriBuilder builder = new UriBuilder(host);

                Console.WriteLine(validUri.ToString());
                Console.WriteLine(builder.ToString());
            }
            else
            {
                Console.WriteLine("Not connected");
            }
            Console.Read();
        }

        static void AddressChangedCallback(object sender, EventArgs e)
        {

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in adapters)
            {
                Console.WriteLine("   {0} is {1}", n.Name, n.OperationalStatus);
            }
        }
    }
}
