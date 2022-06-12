using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_BLL.Interfaces;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AccountDB> _userManager;
        private readonly JwtHandler _jwtHandler;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<AccountDB> userManager, JwtHandler jwtHandler,
            IUserService userService, IMapper mapper)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<AuthResponse> LoginAsync(LoginModel model)
        {
            AccountDB user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new AuthResponse { ErrorMessage = "Invalid Authentication" };
            }

            string token = await GenerateTokenAsync(user);
            return new AuthResponse { IsAuthSuccessful = true, Token = token };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterModel model)
        {
            User profile = new User()
            {
                CountryId = model.CountryId,
                BirthDate = model.BirthDate,
                FullName = model.FullName,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,

            };
            var addedProfile = _userService.AddNewUser(profile);
            AccountDB user = new AccountDB()
            {
                UserName = model.Email,
                UserDBId = addedProfile.Id,
                BillAmount = 0,
                Email = model.Email,

            };
            await _userManager.CreateAsync(user, model.Password);

            string token = await GenerateTokenAsync(user);
            return new AuthResponse { IsAuthSuccessful = true, Token = token };
        }

        private async Task<string> GenerateTokenAsync(AccountDB user)
        {
            Microsoft.IdentityModel.Tokens.SigningCredentials signingCredentials = _jwtHandler.GetSigningCredentials();
            List<Claim> claims = _jwtHandler.GetClaims(user);
            var roles = await _userManager.GetRolesAsync(user);
            AddRolesToClaims(claims, roles);
            JwtSecurityToken tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private void AddRolesToClaims(List<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }
        }
    }
}
