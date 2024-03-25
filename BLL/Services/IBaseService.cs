namespace GymManagement.BLL.Services
{
    public interface IBaseService<TRequestDTO, TResponseDTO>
    {
        Task<TResponseDTO> Add(TRequestDTO requestDTO);
        Task<IEnumerable<TResponseDTO>> GetAll();
        Task<TResponseDTO> GetById(int id);

        Task<bool> Delete(int id);

        Task<TResponseDTO?> Update(int id, TRequestDTO requestDTO);
    }
    public class IBaseService
    {
    }
}
