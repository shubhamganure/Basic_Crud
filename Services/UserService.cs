using System;
using Microsoft.EntityFrameworkCore;

namespace Basic_Crud
{
    public class UserService: IUserService
    {
        public readonly EmployeeDbContextClass _dbContext;

        public UserService(EmployeeDbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserModel> login(LoginModel obj)
        {
            var isExist = await _dbContext.UserModels.SingleOrDefaultAsync(m => m.email == obj.email && m.password == obj.password);
            return isExist;
        }

        public async Task<UserModel> updatePassword(UpdatePasswordModel obj)
        {
            var user = await _dbContext.UserModels.FindAsync(obj.userId);
            if(user != null && user.password == obj.password)
            {
                user.password = obj.newPassword;
                await _dbContext.SaveChangesAsync();
                return user;
            }
            else
            {
                return null;
            }
            
        }

    }
}
