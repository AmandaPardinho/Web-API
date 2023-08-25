using AutoMapper;
using DesafioApiFilme.Data.Dtos.DtoProc;
using DesafioApiFilme.Models;

namespace DesafioApiFilme.Profiles
{
    public class ProcProfile: Profile
    {
        public ProcProfile()
        {
            CreateMap<CreateProcDto, Proc>();
            CreateMap<Proc, ReadProcDto>();
            CreateMap<UpdateProcDto, Proc>();
        }
    }
}
