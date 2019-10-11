using AutoMapper;
using FlexiPay.Models.Model;
using FlexiPay.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiPay.UI.Repository
{
    public class UIServicioProfile : Profile
    {
        public UIServicioProfile()
        {
            CreateMap<Servicio, UIServicio>().ReverseMap();
        }
    }
}