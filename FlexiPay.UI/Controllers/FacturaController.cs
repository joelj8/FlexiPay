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
            var facturasPendientes = facturas.Where(x => x.Pagado == 0).OrderByDescending(x => x.FechaLimite).ToList();
            return View(facturasPendientes);
        }

        public async Task<ActionResult> Historico()
        {
            await GetListFacturas();
            var facturasHistorico = facturas.OrderByDescending(x => x.FechaLimite).ToList();
            return View(facturasHistorico);
        }

        public async Task<ActionResult> Create()
        {
            await LoadDataWork();

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
            
            HttpContext.Session["culture"] = "en-GB";

            await LoadDataWork();
            await FindFactura(id);
            if (facturaMng.Pagado != 0 || facturaMng.Inactivo)
            {
                return RedirectToAction("index", "factura");
            } 
            return View(facturaMng);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UIFactura facturaupd)
        {
            await UpdateFactura(facturaupd);
            return RedirectToAction("index", "factura");
        }

        public async Task<ActionResult> Pagado(int id)
        {
            await LoadDataWork();
            await FindFactura(id);
            if (facturaMng.Pagado >= facturaMng.Monto || facturaMng.Inactivo)
            {
                return RedirectToAction("index", "factura");
            }
            return View(facturaMng);
        }
      
        [HttpPost]
        public async Task<ActionResult> Pagado(UIFactura facturaupd)
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
            if (facturaMng.Pagado != 0 || facturaMng.Inactivo)
            {
                return RedirectToAction("index", "factura");
            }
            return View(facturaMng);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(UIFactura facturadel)
        {
            await DeleteFactura(facturadel);
            return RedirectToAction("index", "factura");
        }

        private async Task CreateFactura(UIFactura facturanew)
        {
            facturanew.setTextToValue();
            HttpResponseMessage response = serviceObj.PostResponse("api/Factura/InsertFactura",facturanew);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task UpdateFactura(UIFactura facturaupd)
        {
            facturaupd.setTextToValue();
            HttpResponseMessage response = serviceObj.PostResponse("api/Factura/UpdateFactura", facturaupd);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task DeleteFactura(UIFactura facturadel)
        {
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Factura/DeleteFactura/"+facturadel.ID.ToString());
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
        }

        private async Task GetListFacturas()
        {
            string result = await callResponse("api/Factura/getFacturas");
            facturas = JsonConvert.DeserializeObject<List<UIFactura>>(result);

        }

        private async Task FindFactura(int id)
        {
            string result = await callResponse("api/Factura/getFactura/" + id.ToString());
            facturaMng = JsonConvert.DeserializeObject<UIFactura>(result);
            facturaMng.setValueToText();
        }

        private async Task LoadDataWork()
        {
            // Tarjetas
            string result = await callResponse("api/Tarjeta/getTarjetas");
            List<UITarjeta> tarjetasMng = JsonConvert.DeserializeObject<List<UITarjeta>>(result);
            
            ViewBag.TarjetaList = tarjetasMng.Select(i => new SelectListItem { Value = i.ID.ToString(), Text = i.TarjetaNumero});

            // Servicios
            string resultserv = await callResponse("api/Servicio/getServicios");
            List<UIServicio> serviciosMng = JsonConvert.DeserializeObject<List<UIServicio>>(resultserv);

            ViewBag.ServicioList = serviciosMng.Select(i => new SelectListItem { Value = i.ID.ToString(), Text = i.Servicio });
        }

        private async Task<string> callResponse(string url)
        {
            HttpResponseMessage response = serviceObj.GetResponse(url);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}