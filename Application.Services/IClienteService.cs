using DTOs;

namespace Application.Services
{
    public interface IClienteService
    {
        Task<ClienteDTO> AddAsync(ClienteDTO dto);
        
        Task<bool> DeleteWithPasswordAsync(int id, string currentPassword);
        Task<ClienteDTO?> GetAsync(int id);
        Task<IEnumerable<ClienteDTO>> GetByCriteriaAsync(ClienteCriteriaDTO criteria);
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<bool> UpdateAsync(ClienteDTO dto);
        

        public Task<bool> DeactivateByAdminAsync(int id);
        Task ChangePasswordAsync(int id, string currentPassword, string newPassword);

    }
}
