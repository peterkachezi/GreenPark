

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.DAL.DbContext;
using ParkingSystem.DAL.Models;
using ParkingSystem.DTO.CustomerModule;

namespace ParkingSystem.BLL.Repositories.CustomerModule
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly ApplicationDbContext context;

		private IMapper mapper;
		public CustomerRepository(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;

			this.mapper = mapper;
		}
		public async Task<CustomerDTO> Create(CustomerDTO customerDTO)
		{
			try
			{
				var isCustomerExist = await context.Customers.AnyAsync(x => x.PhoneNumber == customerDTO.PhoneNumber || x.Email == customerDTO.Email);

				if (isCustomerExist == false)
				{
					customerDTO.Id = Guid.NewGuid();

					customerDTO.CreateDate = DateTime.Now;

					var data = mapper.Map<Customer>(customerDTO);

					context.Customers.Add(data);

					await context.SaveChangesAsync();

					return customerDTO;
				}

				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

				return null;
			}

		}
		public async Task<CustomerDTO> Update(CustomerDTO customerDTO)
		{
			try
			{
				var getCustomer = await context.Customers.FindAsync(customerDTO.Id);

				if (getCustomer != null)
				{
					using (var transaction = context.Database.BeginTransaction())
					{
						getCustomer.FirstName = customerDTO.FirstName;

						getCustomer.LastName = customerDTO.LastName;

						getCustomer.Email = customerDTO.Email;

						getCustomer.PhoneNumber = customerDTO.PhoneNumber;

						getCustomer.CarRegNo = customerDTO.CarRegNo;

						getCustomer.UpdatedBy = customerDTO.UpdatedBy;

						getCustomer.ModifiedDate = DateTime.Now;

						transaction.Commit();
					}

					await context.SaveChangesAsync();

					return customerDTO;
				}

				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

				return null;
			}
		}
		public async Task<List<CustomerDTO>> GetAll()
		{
			try
			{
				var data = await context.Customers.AsNoTracking().ToListAsync();

				var list = mapper.Map<List<CustomerDTO>>(data);

				return list;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

				return null;
			}
		}
		public async Task<CustomerDTO> GetById(Guid Id)
		{
			try
			{
				var data = await context.Customers.FindAsync(Id);

				var list = mapper.Map<CustomerDTO>(data);

				return list;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

				return null;
			}
		}
		public async Task<bool> Delete(Guid Id)
		{
			try
			{
				bool result = false;

				var getCustomer = await context.Customers.FindAsync(Id);

				if (getCustomer != null)
				{
					context.Customers.Remove(getCustomer);

					await context.SaveChangesAsync();

					result = true;
				}

				return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

				return false;
			}
		}
	}
}
