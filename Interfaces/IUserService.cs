using System;

namespace Basic_Crud
{
    public interface IUserService
    {
        Task<UserModel> login(LoginModel obj);
        Task<UserModel> updatePassword(UpdatePasswordModel obj);

    }
}
