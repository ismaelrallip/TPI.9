using DTOs;

namespace Application.Services
{
    public interface IClienteService
    {
        Task<ClienteDTO> AddAsync(ClienteDTO dto);
        Task<bool> DeleteAsync(int id);
        // Eliminar con verificación de contraseña
        Task<bool> DeleteWithPasswordAsync(int id, string currentPassword);
        Task<ClienteDTO?> GetAsync(int id);
        Task<IEnumerable<ClienteDTO>> GetByCriteriaAsync(ClienteCriteriaDTO criteria);
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<bool> UpdateAsync(ClienteDTO dto);
        // Cambiar contraseña verificada
        Task ChangePasswordAsync(int id, string currentPassword, string newPassword);

    }
}
