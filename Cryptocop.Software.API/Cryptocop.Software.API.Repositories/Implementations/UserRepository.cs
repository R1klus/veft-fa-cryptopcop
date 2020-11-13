using System;
using System.Collections;
using System.Linq;
using AutoMapper;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Exceptions;
using Cryptocop.Software.API.Repositories.Helpers;
using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    
    public class UserRepository : IUserRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;
        

        public UserRepository(CryptocopDbContext dbContext, IMapper mapper, ITokenRepository tokenRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
        }

        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            var user = _dbContext.Users.FirstOrDefault(u => inputModel.Email == u.Email);
            if (user != null) {throw new ResourceAlreadyExistsException();}
            var entity = _mapper.Map<User>(inputModel);
            
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();

            var token = _tokenRepository.CreateNewToken();
            
            var userDto = _mapper.Map<UserDto>(entity);
            userDto.TokenId = token.Id;
            
            return userDto;
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == loginInputModel.Email && HashingHelper.HashPassword(loginInputModel.Password) == u.HashedPassword);
            if (user == null) { return null; }
            
            var token = _tokenRepository.CreateNewToken();
            var userDto = _mapper.Map<UserDto>(user);
            userDto.TokenId = token.Id;
            return userDto;
        }
    }
}