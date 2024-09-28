using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taleemz.Core.Entities;
using Taleemz.Core.Interfaces;
using Taleemz.Infrastructure.Data;

namespace Taleemz.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUserById(Guid id)
        {
            return await dbContext.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<UserEntity> AddUser(UserEntity user)
        {
            user.UserId = Guid.NewGuid();
            dbContext.Users.Add(user);

            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserEntity> UpdateUser(UserEntity user)
        {
            var dbuser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (dbuser != null)
            {
                user.FirstName = dbuser.FirstName;
                user.LastName = dbuser.LastName;
                user.EmailAddress = dbuser.EmailAddress;
            }

            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
