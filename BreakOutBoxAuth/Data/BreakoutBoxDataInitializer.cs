using System.Security.Claims;
using System.Threading.Tasks;
using BreakOutBoxAuth.Models;
using Microsoft.AspNetCore.Identity;

namespace BreakOutBoxAuth.Data
{
    public class BreakoutBoxDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;


        public BreakoutBoxDataInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                await CreateUser("Jari", "P@ssword1!", "Admin");
                _dbContext.SaveChanges();
            }
            
            
        }
        
        private async Task CreateUser(string userName, string password, string role)
        {
            var user = new ApplicationUser { UserName = userName};
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }
    }
}