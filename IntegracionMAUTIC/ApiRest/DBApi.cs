using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace IntegracionCRM.ApiRest
{
    class DBApi
    {
       
        public dynamic PostInsert(string url, string json,  string autorizacion = null)
        {

            try
            {

                var client = new RestClient(url);
     
                var request = new RestRequest(Method.POST);
                 client.Authenticator = new HttpBasicAuthenticator("user", "M3rcur10#2000");

                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);

                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);
                }

                IRestResponse response = client.Execute(request);

                //dynamic datos = JsonConvert.DeserializeObject(response.Content);
                dynamic datos = response.StatusCode;

                return datos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex);
                return null;
            }

        }


        public dynamic delete(string url, string autorizacion = null)
        {

            try
            {

                var client = new RestClient(url);

                var request = new RestRequest(Method.DELETE);
                client.Authenticator = new HttpBasicAuthenticator("user", "M3rcur10#2000");

                

                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);
                }

                IRestResponse response = client.Execute(request);

                //dynamic datos = JsonConvert.DeserializeObject(response.Content);
                dynamic datos = response.StatusCode;

                return datos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex);
                return null;
            }

        }

    }
}
