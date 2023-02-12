using ParkingSystem.DTO.CustomerModule;

namespace ParkingSystem.BLL.Repositories.CustomerModule
{
	public interface ICustomerRepository
	{
		Task<CustomerDTO> Create(CustomerDTO customerDTO);
		Task<CustomerDTO> Update(CustomerDTO customerDTO);
		Task<List<CustomerDTO>> GetAll();
		Task<CustomerDTO> GetById(Guid Id);
		Task<bool> Delete(Guid Id);
	}
}