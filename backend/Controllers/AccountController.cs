using backend.Configuration;
using backend.DTO;
using backend.Models;
using backend.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtBearerTokenSettings jwtBearerTokenSettings;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IOptions<JwtBearerTokenSettings> jwt, UserManager<AspNetUsers> manager, SignInManager<AspNetUsers> signIn,
                                   ApplicationDbContext context, IConfiguration configuration, ILogger<AccountController> logger) 
        {
            jwtBearerTokenSettings = jwt.Value;
            _userManager = manager;
            _signInManager = signIn;
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            if (!ModelState.IsValid || register == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }

            var identityUser = new AspNetUsers() { UserName = register.UserName, Email = register.Email };
            var result = await _userManager.CreateAsync(identityUser, register.Password);
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }

            return Ok(new { Message = "User Reigstration Successful" });
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if(login.Email != null && login.Password != null)
            {
                var token = GenerateAccessToken(login.Email);
                return Ok(new {Token =  token});
            }
            return Unauthorized("Invalid email or password.");
        }

        private string GenerateAccessToken(string email) 
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearerTokenSettings.SecretKey)); // Replace with a strong key
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, email)
        };

            var token = new JwtSecurityToken(
                issuer: jwtBearerTokenSettings.Issuer,
                audience: jwtBearerTokenSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        public IActionResult RefreshToken()
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var identityUser = _context.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id));

            // Get existing refresh token if it is valid and revoke it
            var existingRefreshToken = GetValidRefreshToken(token, identityUser);
            if (existingRefreshToken == null)
            {
                return new BadRequestObjectResult(new { Message = "Failed" });
            }

            existingRefreshToken.RevokedByIp = HttpContext.Connection.RemoteIpAddress.ToString();
            existingRefreshToken.RevokedOn = DateTime.UtcNow;

            // Generate new tokens
            var newToken = GenerateTokens(identityUser);
            return Ok(new { Token = newToken, Message = "Success" });
        }

        [HttpPost]
        [Route("RevokeToken")]
        public IActionResult RevokeToken(string token)
        {
            // If user found, then revoke
            if (RevokeRefreshToken(token))
            {
                return Ok(new { Message = "Success" });
            }

            // Otherwise, return error
            return new BadRequestObjectResult(new { Message = "Failed" });
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            // Revoke Refresh Token 
            RevokeRefreshToken();
            return Ok(new { Token = "", Message = "Logged Out" });
        }
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _context.Users
                .Include(jt => jt.JobUserTasks)
                .ThenInclude(jt => jt.Job)
                .Include(jt => jt.JobUserTasks)
                .ThenInclude(jt => jt.Task)
                .Include(jt => jt.JobUserNotes)
                .ThenInclude(jt => jt.Job)
                .Include(jt => jt.JobUserNotes)
                .ThenInclude(jt => jt.Notes)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) 
            {
                return NotFound("Cannot find user.");
            }
            return Ok(user);
        }
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<AspNetUsers>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        private RefreshToken GetValidRefreshToken(string token, AspNetUsers identityUser)
        {
            if (identityUser == null)
            {
                return null;
            }

            var existingToken = identityUser.RefreshTokens.FirstOrDefault(x => x.Token == token);
            return IsRefreshTokenValid(existingToken) ? existingToken : null;
        }

        private bool RevokeRefreshToken(string token = null)
        {
            token = token == null ? HttpContext.Request.Cookies["refreshToken"] : token;
            var identityUser = _context.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id));
            if (identityUser == null)
            {
                return false;
            }

            // Revoke Refresh token
            var existingToken = identityUser.RefreshTokens.FirstOrDefault(x => x.Token == token);
            existingToken.RevokedByIp = HttpContext.Connection.RemoteIpAddress.ToString();
            existingToken.RevokedOn = DateTime.UtcNow;
            _context.Update(identityUser);
            _context.SaveChanges();
            return true;
        }

        private async Task<AspNetUsers> ValidateUser(LoginDTO login)
        {
            var identityUser = await _userManager.FindByEmailAsync(login.Email);
            if (identityUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, login.Password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }

            return null;
        }

        private string GenerateTokens(AspNetUsers identityUser)
        {
            // Generate access token
            string accessToken = GenerateAccessToken(identityUser);

            // Generate refresh token and set it to cookie
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var refreshToken = GenerateRefreshToken(ipAddress, identityUser.Id);

            // Set Refresh Token Cookie
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            // Save refresh token to database
            if (identityUser.RefreshTokens == null)
            {
                identityUser.RefreshTokens = new List<RefreshToken>();
            }

            identityUser.RefreshTokens.Add(refreshToken);
            _context.Update(identityUser);
            _context.SaveChanges();
            return accessToken;
        }

        private string GenerateAccessToken(AspNetUsers identityUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, identityUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, identityUser.Email)
                }),

                Expires = DateTime.Now.AddMinutes(20),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = jwtBearerTokenSettings.Audience,
                Issuer = jwtBearerTokenSettings.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress, string userId)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    ExpiryOn = DateTime.UtcNow.AddDays(jwtBearerTokenSettings.RefreshTokenExpiryInDays),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByIp = ipAddress,
                    UserId = userId
                };
            }
        }

        private bool IsRefreshTokenValid(RefreshToken existingToken)
        {
            // Is token already revoked, then return false
            if (existingToken.RevokedByIp != null && existingToken.RevokedOn != DateTime.MinValue)
            {
                return false;
            }

            // Token already expired, then return false
            if (existingToken.ExpiryOn <= DateTime.UtcNow)
            {
                return false;
            }

            return true;
        }








        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var existingUser = await _userManager.FindByNameAsync(model.UserName);
        //    if (existingUser != null)
        //    {

        //        _logger.LogError("There was an error registering, please try again.");
        //        return BadRequest(new { Message = "Username is already taken." });
        //    }

        //    existingUser = await _userManager.FindByEmailAsync(model.Email);
        //    if (existingUser != null)
        //    {
        //        _logger.LogError("Email is taken, login or try another email.");
        //        return BadRequest(new { Message = "Email is already taken." });
        //    }
        //    var user = new AppUser
        //    {
        //        UserName = model.UserName,
        //        Email = model.Email,
        //        PasswordHash = model.Password
        //    };
        //    var result = await _userManager.CreateAsync(user, model.Password);

        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    _logger.LogInformation("User added, Email: " + model.Email + ", and Password: " + model.Password);
        //    return Ok("Created User");
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginDTO model)
        //{
        //    if (!ModelState.IsValid || model == null)
        //    {
        //        return new BadRequestObjectResult(new { Message = "Login Failed" });
        //    }
        //    var identityUser = await _userManager.FindByEmailAsync(model.Email);
        //    if (identityUser == null) 
        //    {
        //        return new BadRequestObjectResult(new { Message = "Login failed at identityUser check." });
        //    }
        //    var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, model.Password);
        //    if (result == PasswordVerificationResult.Failed)
        //    {
        //        _logger.LogError("Login was successful.");
        //        return new BadRequestObjectResult(new { Message = "Login failed at PasswordVerificationResult.Failed check." });
        //    }
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Email, identityUser.Email),
        //        new Claim(ClaimTypes.Name, identityUser.UserName)
        //    };
        //    var claimsIdentity = new ClaimsIdentity(
        //        claims, CookieAuthenticationDefaults.AuthenticationScheme
        //    );
        //    if (result == PasswordVerificationResult.Success) 
        //    {
        //        var token = GenerateJwtToken(identityUser);
        //        _logger.LogInformation("Token has been generated");
        //        return Ok(new { token });
        //    }
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

        //    return Ok(new { Message = "You are now logged in." });
        //}

        //private string GenerateJwtToken(AppUser user)
        //{
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(ClaimTypes.NameIdentifier, user.Id)
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        _configuration["Jwt:Issuer"],
        //        _configuration["Jwt:Issuer"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //[HttpPost("logout")]
        //public async Task<IActionResult> Logout(string message)
        //{
        //    await _signInManager.SignOutAsync();
        //    _logger.LogInformation("Signed out successfully");
        //    return Ok("User logged out successfully");
        //}

        
    }
}
