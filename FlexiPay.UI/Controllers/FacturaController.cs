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
    public class FacturaController : Controller
    {
        private List<UIFactura> facturas;
        private UIFactura facturaMng;
        private readonly ServiceRepository serviceObj;

        public FacturaController()
        {
            serviceObj = new ServiceRepository();
        }

        // GET: Factura
        public async Task<ActionResult> Index()
        {
            await GetListFacturas();

            return View(facturas);
        }

        public ActionResult Create()
        {
            UIFactura factura = new UIFactura();
            return View(factura);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UIFactura facturanew)
        {
            await CreateFactura(facturanew);

            return RedirectToAction("index", "factura");
        }

        public async Task<ActionResult> Edit(int id)
        {
             await FindFactura(id);
            return View(facturaMng);

        }

        [HttpPost]
        public async Task<ActionResult> Edit(UIFactura facturaupd)
        {
            await UpdateFactura(facturaupd);
            return RedirectToAction("index", "factura");
        }

        public async Task<ActionResult> Details(int id)
        {
            await FindFactura(id);
            return View(facturaMng);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await FindFactura(id);
            return View(facturaMng);
        }

        public async Task<ActionResult> Delete(UIFactura facturadel)
        {
            await DeleteFactura(facturadel);
            return RedirectToAction("index", "factura");
        }

        private async Task CreateFactura(UIFactura facturanew)
        {
            HttpResponseMessage response = serviceObj.PostResponse("api/Factura/InsertFactura",facturanew);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task UpdateFactura(UIFactura facturaupd)
        {
            HttpResponseMessage response = serviceObj.PostResponse("api/Factura/UpdateFactura", facturaupd);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task DeleteFactura(UIFactura facturadel)
        {
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Factura/UpdateFactura"+facturadel.ID.ToString());
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task GetListFacturas()
        {
            HttpResponseMessage response = serviceObj.GetResponse("api/Factura/getFacturas");

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            facturas = JsonConvert.DeserializeObject<List<UIFactura>>(result);
        }

        private async Task FindFactura(int id)
        {
            HttpResponseMessage response = serviceObj.GetResponse("api/Factura/getFactura/"+id.ToString());

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            facturaMng = JsonConvert.DeserializeObject<UIFactura>(result);
        }

    }
}