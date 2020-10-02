using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pix.Application.ViewModels.AppSettings;
using Pix.Application.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace API.Controllers
{
    public abstract class LoginBase : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettingsJwt _appSettings;

        protected LoginBase(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<AppSettingsJwt> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        protected async Task<IdentityResult> CriarUsuario(string email, string senha)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            return await _userManager.CreateAsync(user, senha);
        }

        protected async Task<SignInResult> Logar(string email, string senha)
        {
            return await _signInManager.PasswordSignInAsync(email, senha, false, true);
        }

        protected async Task<List<UsuarioResponse>> ObterUsuarios()
        {
            return MontarUsuarioResponse(await _userManager.Users.ToListAsync());
        }

        protected async Task<LoginResponse> GerarJwtAsync(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = await BuscarClaimsAsync(email),
                Expires = DateTime.UtcNow.AddSeconds(_appSettings.ExpiracaoSegundos),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return MontarLoginResponse(tokenHandler.WriteToken(token));
        }

        private async Task<ClaimsIdentity> BuscarClaimsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private List<UsuarioResponse> MontarUsuarioResponse(List<IdentityUser> usuarios)
        {
            return usuarios.Select(u => new UsuarioResponse
            {
                Email = u.Email,
                Id = u.Id
            }).ToList();
        }

        private LoginResponse MontarLoginResponse(string encodedToken)
        {
            var response = new LoginResponse
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromSeconds(_appSettings.ExpiracaoSegundos).TotalSeconds,
            };
            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
