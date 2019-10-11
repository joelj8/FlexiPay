using AutoMapper;
using FlexiPay.Models.ApiModel;
using FlexiPay.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiPay.WebApi.Repository
{
    public class TarjetaProfile : Profile 
    {
        public TarjetaProfile()
        {
            CreateMap<Tarjeta, ApiTarjeta>()
            .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.TarjetaID))
            .ForMember(dest => dest.TarjetaNumero, opts => opts.MapFrom(src => src.TarjetaNumero));

        }
    }
}