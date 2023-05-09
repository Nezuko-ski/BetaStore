using BetaStore.Core.DTOs;

namespace BetaStore.Core.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDTO<bool>> CreateCustomerAsync(CreateCustomerDTO dTO);
        Task<ResponseDTO<UserDTO>> GetCustomerByIdAsync(string Id);
        Task<ResponseDTO<UserDTO>> GetCustomerByNameAsync(string name);
        Task<ResponseDTO<IEnumerable<UserDTO>>> GetAllCustomers();

    }
}
