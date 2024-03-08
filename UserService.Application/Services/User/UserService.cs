using AutoMapper;
using BC = BCrypt.Net.BCrypt;
using UserService.Application.Dtos;
using UserService.Application.Interfaces;

namespace UserService.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public List<UserDto> GetUsers()
    {
        var users = _mapper.Map<List<UserDto>>(_repository.GetUsers());
    
        return users;
    }

    public UserDto GetUser(string id)
    {
        var user = _mapper.Map<UserDto>(_repository.GetUser(id));

        return user;
    }

    public UserDto AddUser(
        string email,
        string password,
        int role,
        string phone,
        string avatarUrl,
        string status)
    {
        var user = new Domain.Entities.User
        {
            Email = email,
            Password = BC.HashPassword(password),
            Role = role,
            Phone = phone,
            AvatarUrl = avatarUrl,
            Status = status
        };
        
        // BC.Verify(password, passwordHash);
        
        _repository.AddUser(user);

        return _mapper.Map<UserDto>(user);
    }
}