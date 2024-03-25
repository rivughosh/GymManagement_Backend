using AutoMapper;
using GymManagement.BLL.DTOs.Request;
using GymManagement.BLL.Services;
using GymManagementWebAPI.BLL.DTOs.Responses;
using GymManagementWebAPI.DAL.Entities;
using GymManagementWebAPI.DAL.Repository;

namespace GymManagementWebAPI.BLL.Services
{
    public interface IMemberService : IBaseService<MemberRequestDTO, MemberResponseDTO>
    {
        Task<MemberResponseDTO?> UpdtaeWithTrainer(int id, int tranierID);
    }
    public class MemberService : IMemberService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public MemberService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<MemberResponseDTO> Add(MemberRequestDTO requestDTO)
        {
            var product = mapper.Map<Member>(requestDTO);
            var productResponse = await this.repositoryWrapper.MemberRepository.CreateAsync(product);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<MemberResponseDTO>(productResponse);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await this.repositoryWrapper.MemberRepository.GetById(id);
            if (entity == null)
            {
                return false;
            }

            var result = await this.repositoryWrapper.MemberRepository.DeleteAsync(entity);
            await this.repositoryWrapper.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<MemberResponseDTO>> GetAll()
        {
            var productList = await this.repositoryWrapper.MemberRepository.GetAllAsync("Trainer");
            var productResponseDTO = mapper.Map<IEnumerable<MemberResponseDTO>>(productList);
            return productResponseDTO;
        }

        public async Task<MemberResponseDTO> GetById(int id)
        {
            var gymWallet = await this.repositoryWrapper.MemberRepository.GetByIdWithTrainer(id);
            var result = mapper.Map<MemberResponseDTO>(gymWallet);
            return result;
        }

        public async Task<MemberResponseDTO?> Update(int id, MemberRequestDTO requestDTO)
        {
            var product = await this.repositoryWrapper.MemberRepository.GetById(id);
            if (product == null)
            {
                return null;
            }
            mapper.Map(requestDTO, product);
            await this.repositoryWrapper.MemberRepository.UpdateAsync(product);
            await this.repositoryWrapper.SaveAsync();

            var result = mapper.Map<MemberResponseDTO>(product);
            return result;
        }

        public async Task<MemberResponseDTO?> UpdtaeWithTrainer(int memberId, int tranierID)
        {
            var member = await this.repositoryWrapper.MemberRepository.GetByIdWithTrainer(memberId);
            if (member is not null) 
                {
                    member.TrainerId = tranierID;
                    var result = await this.repositoryWrapper.MemberRepository.UpdateAsync(member);
                    await this.repositoryWrapper.SaveAsync();
                    var responseResult = this.mapper.Map<MemberResponseDTO>(result);
                    return responseResult;
            }
            return null;
        }
        //---------------**** Made specific action method for this service to get the Trainer name ****---------------//
        //public async Task<MemberResponseDTO?> GetByIdWithTrainer(int id)
        //{
        //    Reuse the existing GetAllAsync logic
        //   var allEntities = await this.repositoryWrapper.MemberRepository.GetAllAsync("Trainer");
        //    var entity = allEntities.FirstOrDefault(e => e.Id.Equals(id));
        //    var result = mapper.Map<MemberResponseDTO?>(entity);
        //    return result;
        //}
    }
}
