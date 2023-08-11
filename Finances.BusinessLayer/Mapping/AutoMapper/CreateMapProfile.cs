using AutoMapper;
using Finances.DtoLayer.DTOs.AboutUs;
using Finances.DtoLayer.DTOs.AboutUsService;
using Finances.DtoLayer.DTOs.Account;
using Finances.DtoLayer.DTOs.Blog;
using Finances.DtoLayer.DTOs.Contact;
using Finances.DtoLayer.DTOs.ContactUs;
using Finances.DtoLayer.DTOs.Gallery;
using Finances.DtoLayer.DTOs.HappyCustomer;
using Finances.DtoLayer.DTOs.Header;
using Finances.DtoLayer.DTOs.HowItWorks;
using Finances.DtoLayer.DTOs.Question;
using Finances.DtoLayer.DTOs.Service;
using Finances.DtoLayer.DTOs.Team;
using Finances.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.BusinessLayer.Mapping.AutoMapper
{
    public class CreateMapProfile:Profile
    {
        public CreateMapProfile()
        {
            CreateMap<AboutUs,AddAboutUsDto>().ReverseMap();
            CreateMap<AboutUs,UpdateAboutUsDto>().ReverseMap();
            CreateMap<AboutUs,ResultAboutUsDto>().ReverseMap();
            CreateMap<AboutUsService,AddAboutUsServiceDto>().ReverseMap();
            CreateMap<AboutUsService,ResultAboutUsServiceDto>().ReverseMap();
            CreateMap<AboutUsService,UpdateAboutUsServiceDto>().ReverseMap();
            CreateMap<Account,AddAccountDto>().ReverseMap();
            CreateMap<Account,ResultAccountDto>().ReverseMap();
            CreateMap<Account,UpdateAccountDto>().ReverseMap();
            CreateMap<Blog,AddBlogDto>().ReverseMap();
            CreateMap<Blog,ResultBlogDto>().ReverseMap();
            CreateMap<Blog,UpdateBlogDto>().ReverseMap();
            CreateMap<Contact,AddContactDto>().ReverseMap();
            CreateMap<Contact,ResultContactDto>().ReverseMap();
            CreateMap<Contact,UpdateContactDto>().ReverseMap();
            CreateMap<ContactUs,AddContactUsDto>().ReverseMap();
            CreateMap<ContactUs,ResultContactUsDto>().ReverseMap();
            CreateMap<ContactUs,UpdateContactUsDto>().ReverseMap();
            CreateMap<Gallery,AddGalleryDto>().ReverseMap();
            CreateMap<Gallery,ResultGalleryDto>().ReverseMap();
            CreateMap<Gallery,UpdateGalleryDto>().ReverseMap();
            CreateMap<HappyCustomer,AddHappyCustomerDto>().ReverseMap();
            CreateMap<HappyCustomer,ResultHappyCustomerDto>().ReverseMap();
            CreateMap<HappyCustomer,UpdateHappyCustomerDto>().ReverseMap();
            CreateMap<Header,AddHeaderDto>().ReverseMap();
            CreateMap<Header,ResultHeaderDto>().ReverseMap();
            CreateMap<Header,UpdateHeaderDto>().ReverseMap();
            CreateMap<HowItWorks,AddHowItWorksDto>().ReverseMap();
            CreateMap<HowItWorks,ResultHowItWorksDto>().ReverseMap();
            CreateMap<HowItWorks,UpdateHowItWorksDto>().ReverseMap();
            CreateMap<Question,AddQuestionDto>().ReverseMap();
            CreateMap<Question,ResultQuestionDto>().ReverseMap();
            CreateMap<Question,UpdateQuestionDto>().ReverseMap();
            CreateMap<Service,AddServiceDto>().ReverseMap();
            CreateMap<Service,ResultServiceDto>().ReverseMap();
            CreateMap<Service,UpdateServiceDto>().ReverseMap();
            CreateMap<Team,AddTeamDto>().ReverseMap();
            CreateMap<Team,UpdateTeamDto>().ReverseMap();
            CreateMap<Team,ResultTeamDto>().ReverseMap();
        }
    }
}
