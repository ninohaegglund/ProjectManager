using ProjectManager.Business.Dtos;
using ProjectManager.Business.Factories;
using ProjectManager.Business.Interfaces;
using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;
using ProjectManager.Data.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ProjectManager.Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    public async Task<Customer> CreateCustomerAsync(CustomerDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);

            var entity = CustomerFactory.Create(dto);
            if (entity == null)
                return null!;

            entity = await _customerRepository.AddAsync(entity);
            if (entity == null)
                return null!;

            var customer = CustomerFactory.Create(entity);
            return customer!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
    {
        var entities = await _customerRepository.GetAllAsync();
        var customers = entities.Select(CustomerFactory.Create);
        return customers;
    }

    public async Task<Customer> GetCustomerAsync(int id)
    {
        var entities = await _customerRepository.GetAsync(x => x.Id == id);
        if (entities == null)
            return null!;
        var customers = CustomerFactory.Create(entities);
        return customers;
    }

    public async Task<bool> UpdateCustomerAsync(CustomerUpdateDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);

            var entity = CustomerFactory.Create(dto);
            if (entity == null)
                return false;

            var result = await _customerRepository.UpdateAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public async Task<bool> DeleteCustomerAsync(Customer customer)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(customer);

            var entity = await _customerRepository.GetAsync(x => x.Id == customer.Id);

            if (entity == null)
                return false;

            var result = await _customerRepository.DeleteAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}

