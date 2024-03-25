using AutoMapper;
using GymManagement.BLL.DTOs.Request;
using GymManagementWebAPI.BLL.DTOs.Requests;
using GymManagementWebAPI.BLL.DTOs.Responses;
using GymManagementWebAPI.DAL.Entities;

namespace GymManagementWebAPI.BLL.AutoMapperProfile
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<GymWalletRequestDTO, GymWallet>();
            CreateMap<GymWallet, GymWalletResponseDTO>();
            CreateMap<MemberRequestDTO, Member>();
            CreateMap<Member, MemberResponseDTO>();
            CreateMap<PackageRequestDTO, Package>();
            CreateMap<Package, PackageResponseDTO>();
            CreateMap<TrainerRequestDTO, Trainer>();
            CreateMap<Trainer, TrainerResponseDTO>();
        }

    }
}
