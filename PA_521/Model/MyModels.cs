using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PA_521.Model
{
    public class MyModels
    {
    }

    public class PostConcatModel
    {
        public string a { get; set; }
        public string b { get; set; }
    }

    public class Model1
    {
        public string a { get; set; }
        public string b { get; set; }
    }

    public class Model2
    {
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model1, Model2>();
        }
    }

    public class Model3
    {
        public string a { get; set; }
        public string b { get; set; }
    }

    public class Model4
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string c { get; set; }
    }

    public class MappingProfile2 : Profile
    {
        public MappingProfile2()
        {
            CreateMap<Model3, Model4>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.a))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.b));
        }
    }
}
