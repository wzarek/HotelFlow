using HotelFlow.Models.DTO;
using HotelFlow.Services.AuthServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomClaimsTransformation : IClaimsTransformation
{
    private readonly UserAuthService _userManager;
    private readonly HotelFlowContext _context;

    public CustomClaimsTransformation(UserAuthService userManager, HotelFlowContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var identity = principal.Identity as ClaimsIdentity;
        if (identity != null && identity.IsAuthenticated)
        {
            try
            {
                var user = await _userManager.GetUserAsync(principal);
                if (user != null)
                {
                    var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
                    if (role != null)
                    {
                        var existingClaim = identity.FindFirst(ClaimTypes.Role);
                        if (existingClaim != null)
                            identity.RemoveClaim(existingClaim);

                        identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        return principal;
    }
}