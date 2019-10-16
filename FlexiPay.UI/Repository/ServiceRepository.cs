using FlexiPay.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FlexiPay.UI.Repository
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }

        public ServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiUrl"]);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Client.GetAsync(("api/Servicio/Getservicio/1"));
            //http://localhost:65308/api/Factura/InsertFactura

        }

        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }

        public HttpResponseMessage PostResponse(string url, object model)
        {
            
            var json = JsonConvert.SerializeObject(model);
            var buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            //return Client.GetAsync(url).Result;

            var result = Client.PostAsync(url, byteContent).Result;

            return result;
            
        }


        public HttpResponseMessage DeleteResponse(string url)
        {
            var model = new { };
            var json = JsonConvert.SerializeObject(model);
            var buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = Client.PostAsync(url, byteContent).Result;

            return result;
        }
    }
}