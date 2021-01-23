using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertApi.Models;
using AutoMapper;
using WebAdvert.Web.Models.AdvertManagement;

namespace WebAdvert.Web.Services
{
    public class WebSiteProfiles : Profile
    {

        public WebSiteProfiles()
        {
            CreateMap<CreateAdvertViewModel, AdvertModel>().ReverseMap();
        }
    }
}
