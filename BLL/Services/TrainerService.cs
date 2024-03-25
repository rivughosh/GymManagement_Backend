using AutoMapper;
using GymManagement.BLL.DTOs.Request;
using GymManagement.BLL.Services;
using GymManagementWebAPI.BLL.DTOs.Responses;
using GymManagementWebAPI.DAL.Entities;
using GymManagementWebAPI.DAL.Repository;

namespace GymManagementWebAPI.BLL.Services
{
    public interface ITrainerService : IBaseService<TrainerRequestDTO, TrainerResponseDTO>
    {
    }
    public class TrainerService : ITrainerService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public TrainerService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }
        public async Task<TrainerResponseDTO> Add(TrainerRequestDTO requestDTO)
        {
            var product = mapper.Map<Trainer>(requestDTO);
            var productResponse = await this.repositoryWrapper.TrainerRepository.CreateAsync(product);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<TrainerResponseDTO>(productResponse);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await this.repositoryWrapper.TrainerRepository.GetById(id);
            if (entity == null)
            {
                return false;
            }

            var result = await this.repositoryWrapper.TrainerRepository.DeleteAsync(entity);
            await this.repositoryWrapper.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<TrainerResponseDTO>> GetAll()
        {
            var productList = await this.repositoryWrapper.TrainerRepository.GetAllAsync();
            var productResponseDTO = mapper.Map<IEnumerable<TrainerResponseDTO>>(productList);
            return productResponseDTO;
        }

        public async Task<TrainerResponseDTO> GetById(int id)
        {
            var gymWallet = await this.repositoryWrapper.TrainerRepository.GetById(id);
            var result = mapper.Map<TrainerResponseDTO>(gymWallet);
            return result;
        }

        public async Task<TrainerResponseDTO?> Update(int id, TrainerRequestDTO requestDTO)
        {
            var product = await this.repositoryWrapper.TrainerRepository.GetById(id);
            if (product == null)
            {
                return null;
            }
            mapper.Map(requestDTO, product);
            await this.repositoryWrapper.TrainerRepository.UpdateAsync(product);
            await this.repositoryWrapper.SaveAsync();

            var result = mapper.Map<TrainerResponseDTO>(product);
            return result;
        }
    }
}
