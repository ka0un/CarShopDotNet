using AutoMapper;
using CarShopDotNet.Application.Dtos;
using CarShopDotNet.Application.Services.Interfaces;
using CarShopDotNet.Domain.Entities;
using CarShopDotNet.Domain.Interfaces;

namespace CarShopDotNet.Application.Services.Implementaion;

public class OwnerService(IRepository<Owner> ownerRepository, IMapper mapper) : IOwnerService
{
    public async Task<OwnerDto> GetOwnerByIdAsync(int id)
    {
        var owner = await ownerRepository.GetByIdAsync(id);
        return mapper.Map<OwnerDto>(owner);
    }

    public async Task<IEnumerable<OwnerDto>> GetAllOwnersAsync()
    {
        var owners = await ownerRepository.GetAllAsync();
        return mapper.Map<IEnumerable<OwnerDto>>(owners);
    }

    public async Task<OwnerDto> CreateOwnerAsync(CreateOwnerDto ownerDto)
    {
        var owner = mapper.Map<Owner>(ownerDto);
        await ownerRepository.AddAsync(owner);
        await ownerRepository.SaveChangesAsync();
        return mapper.Map<OwnerDto>(owner);
    }

    public async Task<OwnerDto> UpdateOwnerAsync(int id, CreateOwnerDto ownerDto)
    {
        var existingOwner = await ownerRepository.GetByIdAsync(id);
        if (existingOwner == null)
            throw new KeyNotFoundException($"Owner with ID {id} not found.");
        
        mapper.Map(ownerDto, existingOwner);
        existingOwner.UpdatedAt = DateTime.UtcNow;
        ownerRepository.Update(existingOwner);
        await ownerRepository.SaveChangesAsync();
        
        return mapper.Map<OwnerDto>(existingOwner);
    }

    public async Task DeleteOwnerAsync(int id)
    {
        var owner = await ownerRepository.GetByIdAsync(id);
        if (owner == null)
            throw new KeyNotFoundException($"Owner with ID {id} not found.");
        
        ownerRepository.Remove(owner);
        await ownerRepository.SaveChangesAsync();
    }
    
}