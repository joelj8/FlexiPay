using AutoMapper;
using FlexiPay.Models.ApiModel;
using FlexiPay.Models.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiPay.WebApi.Repository
{
    public class ServicioProfile : Profile 
    {
        public ServicioProfile()
        {
            //CreateMap<Servicio, ApiServicio>().ReverseMap();

            CreateMap<Servicio, ApiServicio>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ServicioID))
                .ForMember(dest => dest.Servicio, opts => opts.MapFrom(src => src.ServicioName))
                .ForMember(dest => dest.Contrato, opts => opts.MapFrom(src => src.ServicioContrato))
                .ForMember(dest => dest.Telefono, opts => opts.MapFrom(src => src.ServicioTelefono));

        }
    }
}