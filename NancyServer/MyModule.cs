using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NancyServer
{
    public class MyModule : Nancy.NancyModule
    {
        public MyModule()
        {
         
            Get("/user/{id}", userID =>
            {

                if (((int)userID.id) == 000)
                {
                    return $"Its {userID.id}";
                }
                else return "it's not 000";

            });

            Post("/", args =>
            {
                var request = this.Bind<string>();
                return request.Length;

            });          

            
        }
        

    }
}
