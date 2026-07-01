using AutoMapper;
using inaApp.DTOs.Producto;
using InaApp.ProyectoINAApp.Models.Producto;

namespace InaApp.ProyectoINAApp.Mapping
{
    public class WebMappingProfile:Profile
    {
        //Dto a ViewModel
        public WebMappingProfile() {
            //Dto a viewModel
            CreateMap<ProductoResponseDTO, ProductoIndexViewModel>();
            CreateMap<ProductoResponseDTO, ProductoEditViewModel>();

            //viewModel a Dto
            CreateMap<ProductoIndexViewModel,ProductoResponseDTO>();
            CreateMap<ProductoCreateViewModel, ProductoCreateDTO>();
            CreateMap<ProductoEditViewModel, ProductoUpdateDTO>();
        }
    }
}
