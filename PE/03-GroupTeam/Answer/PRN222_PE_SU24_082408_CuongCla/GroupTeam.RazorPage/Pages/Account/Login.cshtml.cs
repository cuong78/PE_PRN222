using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using GroupTeam.Service;


namespace GroupTeam.RazorPage.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly AccountService _userAccountService;

        public LoginModel() => _userAccountService ??= new AccountService();

        [BindProperty]
        public string UserName { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {                        
            var userAccount = await _userAccountService.GetAccount(UserName, Password);

            if (userAccount != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, UserName),
                    new Claim(ClaimTypes.Role, userAccount.RoleId.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                Response.Cookies.Append("UserName", userAccount.UserName);

                //// After signing then redirect to default page
                return RedirectToPage("/Teams/Index");
                //return RedirectToPage("/Index");
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                TempData["Message"] = "Login fail, please check your account";
            }

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Page();
        }
    }    
}
