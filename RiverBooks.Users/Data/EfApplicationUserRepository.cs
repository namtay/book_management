using Microsoft.EntityFrameworkCore;
using RiverBooks.Users.UseCases;

namespace RiverBooks.Users.Data
{
    internal class EfApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UsersDbContext usersDbContext;

        public EfApplicationUserRepository(UsersDbContext usersDbContext) 
        {
            this.usersDbContext = usersDbContext;
        }
        public Task<ApplicationUser> GetUserWithCartByEmailAsync(string email)
        {
            return usersDbContext.ApplicationUsers
                .Include(user => user.CartItems)
                .SingleAsync(user => user.Email == email);
        }

        public Task SaveChangesAsync()
        {
            return usersDbContext.SaveChangesAsync();
        }
    }

}
