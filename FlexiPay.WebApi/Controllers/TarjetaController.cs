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
    public class TarjetaController : ApiController
    {
        private readonly AutoMapper.MapperConfiguration objMap;

        public TarjetaController()
        {
            List<Profile> profilelist = new List<Profile>();
            profilelist.Add(new TarjetaProfile());
            profilelist.Add(new MTarjetaProfile());

            objMap = new AutoMapper.MapperConfiguration(i => i.AddProfiles(profilelist));

        }

        public JsonResult<List<ApiTarjeta>> GetTarjetas()
        {
            List<Tarjeta> tarjetaLista = DataTarjeta.GetTarjetas();
            
            List<ApiTarjeta> tarjetas = objMap.CreateMapper().Map<List<ApiTarjeta>>(tarjetaLista);

            return Json<List<ApiTarjeta>>(tarjetas);
        }

        public JsonResult<ApiTarjeta> GetTarjeta(int id)
        {

            Tarjeta tarjetaLista = DataTarjeta.GetTarjeta(id);
            ApiTarjeta tarjetas = objMap.CreateMapper().Map<ApiTarjeta>(tarjetaLista);
            
            return Json<ApiTarjeta>(tarjetas);
            
        }

        [HttpPost]
        public JsonResult<bool> InsertTarjeta(ApiTarjeta tarjeta)
        {
            bool resultinsert = false;
            if (ModelState.IsValid)
            {
                Tarjeta tarjetaInsert = objMap.CreateMapper().Map<Tarjeta>(tarjeta);
                resultinsert = DataTarjeta.InsertTarjeta(tarjetaInsert);
            }
            return Json<bool>(resultinsert);
        }

        [HttpPost]
        public JsonResult<bool> UpdateTarjeta(ApiTarjeta tarjeta)
        {
            bool resultinsert = false;
            if (ModelState.IsValid)
            {
                Tarjeta tarjetaUpdate = objMap.CreateMapper().Map<Tarjeta>(tarjeta);
                resultinsert = DataTarjeta.UpdateTarjeta(tarjetaUpdate);
            }
            return Json<bool>(resultinsert);
        }

        [HttpPost]
        public JsonResult<bool> DeleteTarjeta(int id)
        {
            bool result = false;
            Tarjeta tarjetaDelete = DataTarjeta.GetTarjeta(id);
            if (tarjetaDelete != null)
            {
                result = DataTarjeta.DeleteTarjeta(id);
            }

            return Json<bool>(result);
        }

    }
}
