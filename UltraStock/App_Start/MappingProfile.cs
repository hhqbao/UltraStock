using AutoMapper;
using UltraStock.Core.Dtos;
using UltraStock.Core.Models;

namespace UltraStock.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Supplier, SupplierDto>();
            Mapper.CreateMap<SupplierDto, Supplier>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<BarCode, BarCodeDto>();
            Mapper.CreateMap<BarCodeDto, BarCode>();
            Mapper.CreateMap<Invoice, InvoiceDto>();
            Mapper.CreateMap<InvoiceDto, Invoice>();
            Mapper.CreateMap<InvoiceDetail, InvoiceDetailDto>();
            Mapper.CreateMap<InvoiceDetailDto, InvoiceDetail>();
        }
    }
}