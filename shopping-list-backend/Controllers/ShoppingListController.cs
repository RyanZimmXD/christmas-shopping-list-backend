using Microsoft.AspNetCore.Mvc;
using shopping_list_backend.Models;
using System.Security.Cryptography;
using System.Text;

namespace shopping_list_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListController:ControllerBase
    {
        readonly ShoppingListDBContext dbContext;

        public ShoppingListController(ShoppingListDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "TESTINGS")]
        public ActionResult<User> GetUsers()
        {
            return Ok(dbContext.Users.AsEnumerable().ToArray());
        }


        [HttpPost]  
        public ActionResult AddUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else
            {

               using (var sha256 = SHA256.Create())
                {
                    //Basic hashing cause this is for kids and honestly if they can to brute force it they deserve it.
                    //https://www.steve-bang.com/blog/secure-password-hashing-in-dotnet-best-practices

                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordHash));
                    string hash = Convert.ToBase64String(bytes);
                    user.PasswordHash = hash;
                }

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return Ok();
            }
        }
    }
}
