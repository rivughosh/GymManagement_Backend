using AutoMapper;
using GymManagement.BLL.DTOs.Request;
using GymManagement.BLL.Services;
using GymManagementWebAPI.BLL.DTOs.Responses;
using GymManagementWebAPI.DAL.Entities;
using GymManagementWebAPI.DAL.Repository;

namespace GymManagementWebAPI.BLL.Services
{
    public interface IPackageService : IBaseService<PackageRequestDTO, PackageResponseDTO>
    {
    }
    public class PackageService : IPackageService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public PackageService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }
        public async Task<PackageResponseDTO> Add(PackageRequestDTO requestDTO)
        {
            var product = mapper.Map<Package>(requestDTO);
            var productResponse = await this.repositoryWrapper.PackageRepository.CreateAsync(product);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<PackageResponseDTO>(productResponse);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await this.repositoryWrapper.PackageRepository.GetById(id);
            if (entity == null)
            {
                return false;
            }

            var result = await this.repositoryWrapper.PackageRepository.DeleteAsync(entity);
            await this.repositoryWrapper.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<PackageResponseDTO>> GetAll()
        {
            var productList = await this.repositoryWrapper.PackageRepository.GetAllAsync();
            var productResponseDTO = mapper.Map<IEnumerable<PackageResponseDTO>>(productList);
            return productResponseDTO;
        }

        public async Task<PackageResponseDTO> GetById(int id)
        {
            var gymWallet = await this.repositoryWrapper.PackageRepository.GetById(id);
            var result = mapper.Map<PackageResponseDTO>(gymWallet);
            return result;
        }

        public async Task<PackageResponseDTO?> Update(int id, PackageRequestDTO requestDTO)
        {
            var product = await this.repositoryWrapper.PackageRepository.GetById(id);
            if (product == null)
            {
                return null;
            }
            mapper.Map(requestDTO, product);
            await this.repositoryWrapper.PackageRepository.UpdateAsync(product);
            await this.repositoryWrapper.SaveAsync();

            var result = mapper.Map<PackageResponseDTO>(product);
            return result;
        }
    }
}
