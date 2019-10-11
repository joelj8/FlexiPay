using AutoMapper;
using FlexiPay.Models.ApiModel;
using FlexiPay.Models.Model;
using FlexiPay.Services;
using FlexiPay.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace FlexiPay.WebApi.Controllers
{
    public class FacturaController : ApiController
    {
        private readonly AutoMapper.MapperConfiguration objMap;
        public FacturaController()
        {
            List<Profile> profilelist = new List<Profile>();
            profilelist.Add(new FacturaProfile());
            profilelist.Add(new MFacturaProfile());
            profilelist.Add(new ServicioProfile());
            profilelist.Add(new MServicioProfile());
            profilelist.Add(new TarjetaProfile());
            profilelist.Add(new MTarjetaProfile());
            
            objMap = new AutoMapper.MapperConfiguration(i => i.AddProfiles(profilelist));
        }

        public JsonResult<List<ApiFactura>> GetFacturas()
        {
            List<Factura> facturaLista = DataFactura.GetFacturas();

            List<ApiFactura> facturas = objMap.CreateMapper().Map<List<ApiFactura>>(facturaLista);

            return Json<List<ApiFactura>>(facturas);
        }

        public JsonResult<ApiFactura> GetFactura(int id)
        {
            Factura facturaLista = DataFactura.GetFactura(id);

            ApiFactura facturas = objMap.CreateMapper().Map<ApiFactura>(facturaLista);

            return Json<ApiFactura>(facturas);
        }

        [HttpPost]
        public bool InsertFactura(ApiFactura factura)
        {
            bool resultinsert = false;
            
            Factura facturaInsert = objMap.CreateMapper().Map<Factura>(factura);
            resultinsert = DataFactura.InsertFactura(facturaInsert);

            return resultinsert;
        }

        [HttpPost]
        public bool UpdateFactura(ApiFactura factura)
        {
            bool resultupdate = false;

            Factura facturaUpdate = objMap.CreateMapper().Map<Factura>(factura);
            resultupdate = DataFactura.UpdateFactura(facturaUpdate);

            return resultupdate;
        }

        [HttpPost]
        public bool DeleteFactura(int id)
        {
            bool resultDelete = false;

            Factura facturaDelete = DataFactura.GetFactura(id);
            if (facturaDelete != null)
            {
                resultDelete = DataFactura.DeleteFactura(id);
            }


            return resultDelete;
        }

    }
}
