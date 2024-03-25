using AutoMapper;
using AutoMapper.Execution;
using GymManagement.BLL.Services;
using GymManagementWebAPI.BLL.DTOs.Requests;
using GymManagementWebAPI.BLL.DTOs.Responses;
using GymManagementWebAPI.DAL.Entities;
using GymManagementWebAPI.DAL.Repository;

namespace GymManagementWebAPI.BLL.Services
{
    public interface IGymWalletService : IBaseService<GymWalletRequestDTO, GymWalletResponseDTO>
    {
        public IEnumerable<GymWalletResponseDTO> GetWithMemberId(int id);
        public Task<GymWalletResponseDTO?> UpdatePackageWithMemberId(int id, int packageId, string transactionNo, int price);
    }
    public class GymWalletService : IGymWalletService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public GymWalletService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<GymWalletResponseDTO> Add(GymWalletRequestDTO requestDTO)
        {
            var product = mapper.Map<GymWallet>(requestDTO);
            var productResponse = await this.repositoryWrapper.GymWalletRepository.CreateAsync(product);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<GymWalletResponseDTO>(productResponse);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await this.repositoryWrapper.GymWalletRepository.GetById(id);
            if (entity == null)
            {
                return false;
            }

            var result = await this.repositoryWrapper.GymWalletRepository.DeleteAsync(entity);
            await this.repositoryWrapper.SaveAsync();

            return true;
        }
        public async Task<GymWalletResponseDTO> GetById(int id)
        {
            var gymWallet = await this.repositoryWrapper.GymWalletRepository.GetById(id);
            var result = mapper.Map<GymWalletResponseDTO>(gymWallet);
            return result;
        }
        public IEnumerable<GymWalletResponseDTO> GetWithMemberId(int id)
        {
            var membersWallet = this.repositoryWrapper.GymWalletRepository.GetGymWalletByMemberId(id);
            var result = mapper.Map<IEnumerable<GymWalletResponseDTO>>(membersWallet);
            return result;
        }

        public async Task<GymWalletResponseDTO?> Update(int id, GymWalletRequestDTO requestDTO)
        {
            var product = await this.repositoryWrapper.GymWalletRepository.GetById(id);
            if (product == null)
            {
                return null;
            }
            mapper.Map(requestDTO, product);
            await this.repositoryWrapper.GymWalletRepository.UpdateAsync(product);
            await this.repositoryWrapper.SaveAsync();

            var result = mapper.Map<GymWalletResponseDTO>(product);
            return result;
        }

        public async Task<IEnumerable<GymWalletResponseDTO>> GetAll()
        {
            var productList = await this.repositoryWrapper.GymWalletRepository.GetAllAsync("Member","Package");
            var productResponseDTO = mapper.Map<IEnumerable<GymWalletResponseDTO>>(productList);
            return productResponseDTO;
        }



        public async Task<GymWalletResponseDTO?> UpdatePackageWithMemberId(int id, int packageId, string transactionNo, int price)
        {
            var wallet = this.repositoryWrapper.GymWalletRepository.GetGymWalletByMemberIdforPackage(id);
            if (wallet is not null)
            {
                wallet.PackageId = packageId;
                wallet.CreatedAt = DateTime.Now;
                wallet.TransactionNo = transactionNo;
                wallet.Price = price;
                var result = this.repositoryWrapper.GymWalletRepository.UpdateAsync(wallet);
                await this.repositoryWrapper.SaveAsync();
                var responseResult = this.mapper.Map<GymWalletResponseDTO?>(result);
                return responseResult;
            }
            return null;
        }
    }
}
