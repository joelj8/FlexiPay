using AutoMapper;
using FlexiPay.Models.ApiModel;
using FlexiPay.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiPay.WebApi.Repository
{
    public class MTarjetaProfile : Profile 
    {
        public MTarjetaProfile()
        {
            CreateMap<ApiTarjeta, Tarjeta>()
            .ForMember(dest => dest.TarjetaID, opts => opts.MapFrom(src => src.ID))
            .ForMember(dest => dest.TarjetaNumero, opts => opts.MapFrom(src => src.TarjetaNumero));
        }
    }
}