using FlexiPay.Models.ViewModel;
using FlexiPay.UI.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FlexiPay.UI.Controllers
{
    public class TarjetaController : Controller
    {
        private List<UITarjeta> tarjetas;
        private UITarjeta tarjetaMng;
        private readonly ServiceRepository serviceObj;

        public TarjetaController()
        {
            serviceObj = new ServiceRepository();
        }

        // GET: Tarjeta
        public async Task<ActionResult> Index()
        {
            await GetListTarjetas();

            return View(tarjetas);
        }

        public ActionResult Create()
        {
            UITarjeta tarjeta = new UITarjeta();
            return View(tarjeta);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UITarjeta tarjetanew)
        {
            await CreateTarjeta(tarjetanew);
            return RedirectToAction("index", "tarjeta");
        }

        public async Task<ActionResult> Edit(int id)
        {
            await FindTarjeta(id);
            return View(tarjetaMng);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UITarjeta tarjetaupd)
        {
            await UpdateTarjeta(tarjetaupd);

            return RedirectToAction("index", "tarjeta");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await FindTarjeta(id);
            return View(tarjetaMng);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(UITarjeta tarjetadelete)
        {
            await DeleteTarjeta(tarjetadelete);

            return RedirectToAction("index", "tarjeta");
        }

        public async Task<ActionResult> Detail(int id)
        {
            await FindTarjeta(id);
            return View(tarjetaMng);
        }

        private async Task FindTarjeta(int id)
        {
            HttpResponseMessage response = serviceObj.GetResponse("api/Tarjeta/getTarjeta/" + id.ToString());

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            tarjetaMng = JsonConvert.DeserializeObject<UITarjeta>(result);
        }

        private async Task DeleteTarjeta(UITarjeta tarjetadel)
        {
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Tarjeta/DeleteTarjeta/"+tarjetadel.ID.ToString());
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task UpdateTarjeta(UITarjeta tarjetaupd)
        {
            HttpResponseMessage response = serviceObj.PostResponse("api/Tarjeta/UpdateTarjeta", tarjetaupd);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task CreateTarjeta(UITarjeta tarjetanew)
        {
            HttpResponseMessage response = serviceObj.PostResponse("api/Tarjeta/InsertTarjeta", tarjetanew);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task GetListTarjetas()
        {
            HttpResponseMessage response = serviceObj.GetResponse("api/Tarjeta/getTarjetas");

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            tarjetas = JsonConvert.DeserializeObject<List<UITarjeta>>(result);
        }
   
    }
}