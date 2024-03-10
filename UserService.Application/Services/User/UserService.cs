using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using BC = BCrypt.Net.BCrypt;
using UserService.Application.Dtos;
using UserService.Application.Interfaces;
using UserService.Domain.Exceptions;

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
        var user = _repository.GetUser(id);
        if (user == null) throw new NotFoundException("User do not exists");
        
        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }

    public UserDto AddUser(
        string email,
        string password,
        int role,
        string phone,
        string avatarUrl,
        string status)
    {
        var user = _repository.GetUserByEmail(email);
        if (user != null) throw new Exception("User with this email is already exists");

        if (role is < 0 or > 6) throw new Exception("Role value can be only in 1-6 interval");
        
        var newUser = new Domain.Entities.User
        {
            Email = email,
            Password = BC.HashPassword(password),
            Role = role,
            Phone = phone,
            AvatarUrl = avatarUrl,
            Status = status
        };
        
        _repository.AddUser(newUser);

        return _mapper.Map<UserDto>(newUser);
    }

    public UserDto EditUser(string id, JsonPatchDocument<Domain.Entities.User> patchDoc)
    {
        var user = _repository.GetUser(id);
        if (user == null) throw new NotFoundException("User do not exists");
        
        var prevPasswordHash = user.Password;
        
        patchDoc.ApplyTo(user);
        if (prevPasswordHash != user.Password)
            user.Password = BC.HashPassword(user.Password);
        
        if (user.Role is < 0 or > 6) throw new Exception("Role value can be only in 1-6 interval");
        
        _repository.EditUser();
        
        return _mapper.Map<UserDto>(user);
    }

    public void DeleteUser(string id)
    {
        var user = _repository.GetUser(id);
        if (user == null) throw new NotFoundException("User do not exists");
        
        _repository.DeleteUser(user);
    }
}