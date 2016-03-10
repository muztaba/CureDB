using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmachy
{
    class UserService : IUserService
    {
        private IUserServiceDAL userServiceDal;
        private UserStatus userStatus = UserStatus.Instance;
        private String environment = Environment.MachineName;
        private User retriveUser;
        public bool checkUserAuthentication(User user)
        {
            IUserServiceDAL userServiceDal = new UserServiceDAL();
            retriveUser = new User();
            retriveUser = userServiceDal.GetUserInfo(user);

            if (retriveUser == null)
            {
                return false;
            }
            
            if (retriveUser.UserPassword.Equals(user.UserPassword))
            {
                return true;
            }

            return false;
        }


        public User getUser()
        {
            return retriveUser;
        }

        public bool SaveCurrentUser()
        {
            userStatus.AddUser(environment, new User()
            {
                UserId = retriveUser.UserId,
                UserName = retriveUser.UserName
            });
            return true;
        }


        public User GetCurrentMachineUser()
        {
            User user = userStatus.GetUser(environment);
            return user;
        }
    }
}
