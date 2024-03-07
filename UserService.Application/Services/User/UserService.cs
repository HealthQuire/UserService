using Microsoft.AspNetCore.Identity;
using AutoMapper;
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
            Password = password,
            Role = role,
            Phone = phone,
            AvatarUrl = avatarUrl,
            Status = status
        };
        
        // var hasher = new PasswordHasher<Domain.Entities.User>();
        // string hashedPassword = hasher.HashPassword(user, password);
        //
        // user.Password = hashedPassword;
        //
        // var userWithoutPassword = user;
        // userWithoutPassword.Password = "";
        //
        // var res = hasher.VerifyHashedPassword(userWithoutPassword, user.Password, password);
        // Console.WriteLine(res);
        
        _repository.AddUser(user);

        return _mapper.Map<UserDto>(user);
    }
}