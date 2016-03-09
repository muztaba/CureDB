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
        public bool checkUserAuthentication(User user)
        {
            IUserServiceDAL userServiceDal = new UserServiceDAL();
            User retriveUser = userServiceDal.GetUserInfo(user);

            if (retriveUser == null)
            {
                return false;
            } else if (retriveUser.UserPassword.Equals(user.UserPassword))
            {
                return true;
            }

            return false;
        }
    }
}
