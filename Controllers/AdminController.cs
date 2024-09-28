using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Models;
using System.Linq;
using System.Threading.Tasks;

[Authorize]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: /Admin/Users
    [HttpGet]
    public IActionResult Users()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }

    // POST: /Admin/Block
    [HttpPost]
    public async Task<IActionResult> Block(string[] userIds)
    {
        foreach (var userId in userIds)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsBlocked = true;
                await _userManager.UpdateAsync(user);
            }
        }
        return RedirectToAction("Users");
    }

    // POST: /Admin/Unblock
    [HttpPost]
    public async Task<IActionResult> Unblock(string[] userIds)
    {
        foreach (var userId in userIds)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsBlocked = false;
                await _userManager.UpdateAsync(user);
            }
        }
        return RedirectToAction("Users");
    }

    // POST: /Admin/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(string[] userIds)
    {
        foreach (var userId in userIds)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
        return RedirectToAction("Users");
    }
}
