using ProjectManager.Business.Dtos;
using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;
using System.Linq.Expressions;

namespace ProjectManager.Business.Interfaces;

public interface ICustomerService
{
    Task<Customer> CreateCustomerAsync(CustomerDto dto);
    Task<bool> DeleteCustomerAsync(Customer customer);
    Task<IEnumerable<Customer>> GetAllCustomerAsync();
    Task<Customer> GetCustomerAsync(int id);
    Task<bool> UpdateCustomerAsync(CustomerUpdateDto dto);
}