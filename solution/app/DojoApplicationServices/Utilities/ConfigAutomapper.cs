using AutoMapper;
using DataStorage;
using DojoApplicationServices.Models;

namespace DojoApplicationServices.Utilities
{
    public static class ConfigAutomapper
    {
        public static IMapper mapper { get; set; }
        public static void Config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DojoModel, Dojo>().ReverseMap();
                cfg.CreateMap<MiembroModel, Miembro>().ReverseMap();
                cfg.CreateMap<RetoModel, Reto>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }
    }
}
