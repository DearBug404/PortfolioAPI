using AutoMapper;
using Portfolio.Application.DTOs;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Mappings
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<HeaderCreateDto, Header>()
                .ForMember(dest => dest.LogoPath, opt => opt.Ignore());
            CreateMap<Header, HeaderViewDto>()
                .ForMember(dest => dest.LogoPath, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<AboutCreateDto, About>()
                .ForMember(dest => dest.ImagePath, opt => opt.Ignore());
            CreateMap<About, AboutViewDto>()
                .ForMember(dest => dest.AboutImagePath, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<IntroCreateDto, Intro>()
                .ForMember(dest => dest.IntroImagePath, opt => opt.Ignore())
                .ForMember(dest => dest.ResumePath, opt => opt.Ignore());
            CreateMap<Intro, IntroViewDto>()
                .ForMember(dest => dest.IntroImagePath, opt => opt.Ignore())
                .ForMember(dest => dest.ResumePath, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<ServicesCreateDto, Services>()
                .ForMember(dest => dest.ServiceIconPath, opt => opt.Ignore());
            CreateMap<Services, ServicesViewDto>()
                .ForMember(dest => dest.ServiceIcon, opt => opt.MapFrom(src => src.ServiceIconPath))
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<SkillSectionCreateDto, SkillSection>();
            CreateMap<SkillSection, SkillSectionViewDto>()
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<SkillDetailCreateDto, SkillDetail>();
            CreateMap<SkillDetail, SkillDetailViewDto>()
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<ExperienceCreateDto, Experience>();
            CreateMap<Experience, ExperienceViewDto>()
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<EducationCreateDto, Education>();
            CreateMap<Education, EducationViewDto>()
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<ReviewCreateDto, Review>()
                .ForMember(dest => dest.ClientImagePath, opt => opt.Ignore());
            CreateMap<Review, ReviewViewDto>()
                .ForMember(dest => dest.ClientImage, opt => opt.MapFrom(src => src.ClientImagePath))
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<ContactInfoCreateDto, ContactInfo>();
            CreateMap<ContactInfo, ContactInfoViewDto>()
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));

            CreateMap<ClientMessageCreateDto, ClientMessage>();
            CreateMap<ClientMessage, ClientMessageViewDto>()
                .ForMember(dest => dest.SentMessageAtRaw, opt => opt.MapFrom(src => src.SentMessageAt));

            CreateMap<User, UserResponseDto>();
            CreateMap<User, UpdateUserRequestDto>();

            CreateMap<SocialLinksCreateDto, SocialLinks>();
            CreateMap<SocialLinks, SocialLinksViewDto>()
                .ForMember(dest => dest.CreatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.ConvertUsing(new DateTimeToStringConverter(), src => src.UpdatedAt));


        }
    }
}
