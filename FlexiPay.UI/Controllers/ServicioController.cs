using AutoMapper;
using FlexiPay.Models.Model;
using FlexiPay.Models.ViewModel;
using FlexiPay.Services;
using FlexiPay.UI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FlexiPay.UI.Controllers
{
    public class ServicioController : Controller
    {

        private List<UIServicio> servicios;
        private UIServicio servicioedit;
        private readonly ServiceRepository serviceObj;
        public ServicioController()
        {
            serviceObj = new ServiceRepository();
        }
        
        // GET: Servicio
        public async Task<ActionResult> Index()
        {
            
            await GetListServicios();

            return View(servicios);
        }

        public ActionResult Create()
        {
            UIServicio servicio = new UIServicio();
            return View(servicio);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UIServicio newservicio)
        {
            await CreateServicio(newservicio);

            return RedirectToAction("index", "servicio");
        }

        public async Task<ActionResult> Edit(int id)
        {
            await FindServicio(id);
            return View(servicioedit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UIServicio servicioact)
        {
            await UpdateServicio(servicioact);

            return RedirectToAction("index", "servicio");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await FindServicio(id);
            return View(servicioedit);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(UIServicio serviciodel)
        {
            await DeleteServicio(serviciodel);
            return RedirectToAction("index", "servicio");
        }

        public async Task<ActionResult> Details(int id)
        {
            await FindServicio(id);
            return View(servicioedit);
        }

        private async Task DeleteServicio(UIServicio serviciodel)
        {
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Servicio/Deleteservicio/"+serviciodel.ID.ToString());
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task UpdateServicio(UIServicio servicioact)
        {
            HttpResponseMessage response = serviceObj.PostResponse("api/Servicio/Updateservicio", servicioact);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task FindServicio(int id)
        {
            HttpResponseMessage response = serviceObj.GetResponse("api/Servicio/getservicio/"+id.ToString());

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            servicioedit = JsonConvert.DeserializeObject<UIServicio>(result);
        }

        private async Task CreateServicio(UIServicio servicio)
        {
            HttpResponseMessage response = serviceObj.PostResponse("api/Servicio/Insertservicio",servicio);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task GetListServicios()
        {
            
            HttpResponseMessage response = serviceObj.GetResponse("api/Servicio/getservicios");

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            servicios = JsonConvert.DeserializeObject<List<UIServicio>>(result);
        }
    }
}