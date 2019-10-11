using AutoMapper;
using FlexiPay.Models.ApiModel;
using FlexiPay.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiPay.WebApi.Repository
{
    public class MFacturaProfile : Profile
    {
        public MFacturaProfile()
        {
            CreateMap<ApiFactura, Factura>()
            .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ID))
            .ForMember(dest => dest.ServicioID, opts => opts.MapFrom(src => src.ServicioID))
            .ForMember(dest => dest.Servicio, opts => opts.MapFrom(src => src.Servicio))
            .ForMember(dest => dest.AprobacionNumero, opts => opts.MapFrom(src => src.AprobacionNumero))
            .ForMember(dest => dest.Comentario, opts => opts.MapFrom(src => src.Comentario))
            .ForMember(dest => dest.FechaLimite, opts => opts.MapFrom(src => src.FechaLimite))
            .ForMember(dest => dest.FechaPago, opts => opts.MapFrom(src => src.FechaPago))
            .ForMember(dest => dest.Inactivo, opts => opts.MapFrom(src => src.Inactivo))
            .ForMember(dest => dest.Monto, opts => opts.MapFrom(src => src.Monto))
            .ForMember(dest => dest.Pagado, opts => opts.MapFrom(src => src.Pagado))
            .ForMember(dest => dest.TarjetaID, opts => opts.MapFrom(src => src.TarjetaID))
            .ForMember(dest => dest.Tarjeta, opts => opts.MapFrom(src => src.Tarjeta));
        }
    }
}