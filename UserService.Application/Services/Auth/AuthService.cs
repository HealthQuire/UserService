﻿using AutoMapper;
using BC = BCrypt.Net.BCrypt;
using UserService.Application.Dtos;
using UserService.Application.Interfaces;

namespace UserService.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public AuthService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public UserDto Login(string email, string password)
    {
        var user = _repository.GetUserByEmail(email);

        var verifyState = BC.Verify(password, user.Password);
        if (!verifyState) throw new Exception("Wrong password");
        
        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}