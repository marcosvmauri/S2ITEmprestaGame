using AutoMapper;
using EmprestaGame.DTO;
using Entities;

namespace EmprestaGame.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<JogoDTO, Jogo>();
            CreateMap<JogoUsuarioDTO, Jogo>();
            CreateMap<EmprestimoDTO, Emprestimo>();
        }
    }
}
