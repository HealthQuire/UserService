using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Exceptions;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly DataContext _context;
    
    public OrganizationRepository(DataContext context)
    {
        _context = context;
    }

    public List<Organization> GetOrganizations() => _context.Organizations.ToList();

    public Organization? GetOrganization(string id) => 
        _context.Organizations.SingleOrDefault(organization => organization.Id == id);
    
    public Organization? GetOrganizationByName(string name) => 
        _context.Organizations.SingleOrDefault(organization => organization.Name == name);

    public void AddOrganization(Organization organization)
    {
        _context.Add(organization);
        _context.SaveChanges();
    }

    public void EditOrganization() =>
        _context.SaveChanges();

    public void DeleteOrganization(string id)
    {
        var organization = GetOrganization(id);
        if (organization == null) throw new NotFoundException("Organization do not exists");
        
        _context.Organizations.Remove(organization);
        _context.SaveChanges();
    }
}