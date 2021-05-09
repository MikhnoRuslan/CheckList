using CheckList.DAL;
using CheckList.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace CheckList
{
    public class DataSeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly List<User> _users;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly CheckListContext _context;
        private readonly List<Category> _categories;

        public DataSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, CheckListContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;

            _users = new List<User>
            {
                new User
                {
                    Login = "Admin",
                    Email = "r.mikhno92@gmail.com",
                    UserName = "r.mikhno92@gmail.com",
                    FirstName = "Bob",
                    LastName = "Brown",
                }
            };

            _categories = new List<Category>
            {
                new Category {Name = "Тумба"},
                new Category {Name = "Шкаф"},
                new Category {Name = "Кровать"},
                new Category {Name = "Стол"},
                new Category {Name = "Комод"},
                new Category {Name = "Экран"},
            };
        }

        public async System.Threading.Tasks.Task SeedDataAsync()
        {

            if (await _roleManager.FindByNameAsync(Constants.Administrator) == null)
                await _roleManager.CreateAsync(new IdentityRole(Constants.Administrator));

            if (await _roleManager.FindByNameAsync(Constants.Сonstructor) == null)
                await _roleManager.CreateAsync(new IdentityRole(Constants.Сonstructor));

            if (await _roleManager.FindByNameAsync(Constants.Employee) == null)
                await _roleManager.CreateAsync(new IdentityRole(Constants.Employee));

            if (await _roleManager.FindByNameAsync(Constants.User) == null)
                await _roleManager.CreateAsync(new IdentityRole(Constants.User));

            if (await _userManager.FindByNameAsync(Constants.Email) == null)
            {
                var result = await _userManager.CreateAsync(_users[0], Constants.Password);
                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(_users[0], Constants.Administrator);
            }

            if (!_context.Categories.Any())
                await _context.Categories.AddRangeAsync(_categories);

            await _context.SaveChangesAsync();
        }
    }
}
