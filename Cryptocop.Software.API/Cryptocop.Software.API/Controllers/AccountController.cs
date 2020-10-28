using System;
using System.Collections.Generic;
using System.Linq;
using Cryptocop.Software.API.Exceptions;
using Cryptocop.Software.API.Helpers;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;


namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("register", Name = "Register")]
        public IActionResult Register([FromBody] RegisterInputModel register)
        {
            if (!ModelState.IsValid)
            {
                ErrorHandler.GetModelErrors(ModelState);
            }
            var user = _accountService.CreateUser(register);
            return CreatedAtRoute("Register", new { id = user.Id}, null);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin", Name = "SignIn")]
        public IActionResult SignIn([FromBody] LoginInputModel login)
        {
            if (!ModelState.IsValid)
            {
                ErrorHandler.GetModelErrors(ModelState);
            }
            var user = _accountService.AuthenticateUser(login);
            if (user == null) { throw new UnauthorizedException("Invalid login Credentials"); }

            return Ok(_tokenService.GenerateJwtToken(user));
        }

        [HttpPost]
        [Route("signout", Name = "SignOut")]
        public IActionResult SignOut()
        {
            
            int.TryParse(ClaimsHelper.GetClaim(User, "tokenId"), out var tokenId);
            _accountService.Logout(tokenId);
            return NoContent();
        }
    }
}