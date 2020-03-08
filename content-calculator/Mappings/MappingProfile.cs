using AutoMapper;
using content_calculator.Models;
using content_calculator.InputModels;
using content_calculator.ViewModels;

namespace content_calculator.Mappings
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile" /> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.CategoryId));

            CreateMap<CategoryViewModel, Category>()
                .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.Id));

            CreateMap<Item, ItemViewModel>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.Price))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemId));

            CreateMap<ItemViewModel, Item>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.DisplayName))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Value))
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id));

            CreateMap<ItemInputModel, Item>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.DisplayName))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Value));
        }
    }
}
