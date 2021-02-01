using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;

namespace NancyServer
{
    class URL
    {
        private string _url = "http://localhost";
        private int _port = 12345;
        private NancyHost _nancy;

        public URL()
        {
             Uri uri = new Uri($"{_url}:{_port}/");
            _nancy = new NancyHost(uri);
        }
        
        public void Start()
        {
            _nancy.Start();
            Console.WriteLine($"Started listening port {_port}");
            Console.WriteLine($"{_url} {_port}");
            //Console.ReadKey();
            //_nancy.Stop();
        }




    }
}
