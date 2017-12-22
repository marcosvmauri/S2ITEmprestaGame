using AutoMapper;
using EmprestaGame.DTO;
using Entities;

namespace EmprestaGame.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Jogo, JogoDTO>();
            CreateMap<Emprestimo, EmprestimoDTO>();
            CreateMap<Jogo, JogoUsuarioDTO>();
        }
    }
}