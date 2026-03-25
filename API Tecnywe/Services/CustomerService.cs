using API_Tecnywe.Entities;
using API_Tecnywe.Exceptions;
using API_Tecnywe.Repositories.Interfaces;
using API_Tecnywe.Services.Interface;
using AutoMapper;
using static API_Tecnywe.DTO.Customer;

namespace API_Tecnywe.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetByIdAsync(string id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer is null)
                throw new NotFoundException($"No se encontró el cliente con id {id}.");

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
        {
            var exists = await _repository.GetByEmailAsync(dto.Email);

            if (exists is not null)
                throw new BadRequestException("Ya existe un cliente con ese correo.");

            var customer = _mapper.Map<Customer>(dto);
            customer.Id = Guid.NewGuid().ToString();

            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
