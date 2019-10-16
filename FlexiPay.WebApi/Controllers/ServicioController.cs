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
    public class ServicioController : ApiController
    {
        private readonly AutoMapper.MapperConfiguration objMap;
        private readonly DataServicio dataservServicio;

        public ServicioController()
        {
            dataservServicio = new DataServicio();

            List<Profile> profilelist = new List<Profile>();
            profilelist.Add(new ServicioProfile());
            profilelist.Add(new TarjetaProfile());
            profilelist.Add(new MServicioProfile());

            objMap = new AutoMapper.MapperConfiguration(i => i.AddProfiles(profilelist));
        }
        public JsonResult<List<ApiServicio>> GetServicios()
        {

            List<Servicio> servicioLista = dataservServicio.GetServicios();
            //AutoMapper.MapperConfiguration objMap = new AutoMapper.MapperConfiguration(i => i.AddProfile(new ServicioProfile()));
            List<ApiServicio> servicios = objMap.CreateMapper().Map<List<ApiServicio>>(servicioLista);

            return Json<List<ApiServicio>>(servicios);
        }

        public JsonResult<ApiServicio> GetServicio(int id)
        {
            Servicio servicioLista = dataservServicio.GetServicio(id);
            ApiServicio servicios = objMap.CreateMapper().Map<ApiServicio>(servicioLista);

            return Json<ApiServicio>(servicios);
        }

        [HttpPost]
        public JsonResult<bool> InsertServicio(ApiServicio servicio)
        {
            bool resultinsert = false;
            if (ModelState.IsValid)
            {
                Servicio servicioInsert = objMap.CreateMapper().Map<Servicio>(servicio);
                resultinsert = dataservServicio.InsertServicio(servicioInsert);
            }
            return Json<bool>(resultinsert);
        }

        [HttpPost]
        public JsonResult<bool> UpdateServicio(ApiServicio servicio)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                Servicio servicioUpdate = objMap.CreateMapper().Map<Servicio>(servicio);
                result = dataservServicio.UpdateServicio(servicioUpdate);
            }
            return Json<bool>(result);
        }

        [HttpPost]
        public JsonResult<bool> DeleteServicio(int id)
        {
            bool result = false;
            Servicio servicioDelete = dataservServicio.GetServicio(id);
            if (servicioDelete != null)
            {
                result = dataservServicio.DeleteServicio(id);
            }

            return Json<bool>(result);
        }
    }
}
