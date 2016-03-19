using System.Collections.Generic;
using AutoMapper;
using FPTB.Data.Model;
using FPTB.Model;
using fromplaytobow.co.uk.Models;

namespace FPTB.Mappings.Profile
{
    public class DeliveryRequestMappingProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<HtmlPage, HtmlPageDto>();
            CreateMap<HtmlBlock, HtmlBlockDto>();
            CreateMap<IEnumerable<HtmlPage>, IEnumerable<HtmlPageDto>>();

            CreateMap<HtmlPageDto, HtmlPage>();
            CreateMap<HtmlPageDto, HtmlPageVM>();
            CreateMap<HtmlBlockDto, HtmlBlockVM>();
            CreateMap<HtmlPageVM, HtmlPageDto>();

            CreateMap<HtmlBlockDto, HtmlBlock>();
            CreateMap<HtmlBlockVM, HtmlBlockDto>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}