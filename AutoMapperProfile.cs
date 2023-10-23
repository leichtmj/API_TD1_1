using API_TD1_1.Models.EntityFramework;
using API_TD1_1;
using AutoMapper;

namespace API_TD1_1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Produit, Models.DTO.ProduitDetailDTO>();
            CreateMap<Models.DTO.ProduitDetailDTO, Produit>();
        }
    }
}
