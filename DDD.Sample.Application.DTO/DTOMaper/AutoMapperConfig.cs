using DDD.Sample.Application.DTO.DTOMaper.Profiles;

namespace DDD.Sample.Application.DTO.DTOMaper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(r =>
            {
                r.AddProfile<StudentProfile>();
            });
        }
    }
}
