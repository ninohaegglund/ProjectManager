using ProjectManager.Business.Interfaces;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;

namespace ProjectManager.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Dependency injection
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserEntity CreateUser(UserEntity userEntity)
        {
            _userRepository.Add(userEntity);
            return userEntity;
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public UserEntity GetUserById(long id)
        {
            return _userRepository.GetById(id);
        }

        public UserEntity GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public UserEntity UpdateUser(UserEntity userEntity)
        {
            _userRepository.Update(userEntity);
            return userEntity;
        }

    }
}
