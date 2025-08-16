using Microsoft.IdentityModel.Tokens;
using SportSchedule.Context;
using SportSchedule.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportSchedule.Services.Users
{
    public class GenerateJwtToken
    {
        private readonly ContextDB _context;

        public GenerateJwtToken(ContextDB context)
        {
            _context = context;
        }
        public string generate(AccountModel? account, IConfiguration config)
        {
            var jwtSettings = config.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account!.UserName!),
                new Claim(ClaimTypes.Role, account!.User!.Role!.Name!.ToString())
            };

            var permissions = (from a in _context.Accounts
                              join u in _context.Users on a.UserId equals u.UserId
                              join r in _context.Roles on u.RoleId equals r.Id
                              join rp in _context.RolePermissions on r.Id equals rp.RoleId
                              join p in _context.Permissions on rp.PermissionId equals p.PermissionId
                              where a.AccountId == account.AccountId
                              select p.PermisstionName).ToList();

            //Them permission
            foreach(var permission in permissions)
            {
                claims.Add(new Claim("permission", permission));
            }

            var token = new JwtSecurityToken
            (
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims:claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiresInMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
