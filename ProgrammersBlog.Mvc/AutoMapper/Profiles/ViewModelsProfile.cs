using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.WebMvc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.WebMvc.AutoMapper.Profiles
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            CreateMap<ArticleAddDto, ArticleAddViewModel>();

            CreateMap<ArticleUpdateViewModel, ArticleUpdateDto>().ReverseMap();

            CreateMap<ArticleRightSideBarWidgetOptionsViewModel, ArticleRightSideBarWidgetOptions>().ReverseMap();
        }
    }
}
