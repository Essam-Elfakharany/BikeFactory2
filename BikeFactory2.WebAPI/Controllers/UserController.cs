using BikeFactory2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BikeFactory2.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    public UserController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    [Route("userandpasswordarevalid")]
    public async Task<bool> UserAndPasswordAreValid(User user)
    {
        var identityUser = await _userManager.FindByEmailAsync(user.Email);
        var result = await _userManager.CheckPasswordAsync(identityUser,
        user.Password);
        return result;
    }
    [HttpPost]
    [Route("register")]
    public async Task<List<string>> Register(User user)
    {
        var listOfErrors = new List<string>();
        var identityUser = new IdentityUser(user.Email);
        identityUser.Email = user.Email;
        var createResult = await _userManager.CreateAsync(identityUser,
        user.Password);
        if (!createResult.Succeeded)
        {
            foreach (var error in createResult.Errors)
            {
                listOfErrors.Add(error.Description);
            }
        }
        return listOfErrors;
    }
}
