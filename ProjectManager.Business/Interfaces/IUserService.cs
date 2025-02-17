using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Interfaces
{
    public interface IUserService
    {
        UserEntity CreateUser(UserEntity userEntity);
        UserEntity GetUserByEmail(string email);
        UserEntity GetUserById(long id);
        IEnumerable<UserEntity> GetUsers();
        UserEntity UpdateUser(UserEntity userEntity);
    }
}