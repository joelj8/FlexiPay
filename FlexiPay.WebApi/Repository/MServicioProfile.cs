using AutoMapper;
using FlexiPay.Models.ApiModel;
using FlexiPay.Models.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiPay.WebApi.Repository
{
    public class MServicioProfile: Profile
    {
        public MServicioProfile()
        {
            CreateMap<ApiServicio, Servicio>()
            .ForMember(dest => dest.ServicioID, opts => opts.MapFrom(src => src.ID))
            .ForMember(dest => dest.ServicioName, opts => opts.MapFrom(src => src.Servicio))
            .ForMember(dest => dest.ServicioContrato, opts => opts.MapFrom(src => src.Contrato))
            .ForMember(dest => dest.ServicioTelefono, opts => opts.MapFrom(src => src.Telefono));
            
        }
    }
}