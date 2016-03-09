using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmachy.From
{
    public partial class FrmLogin : Form
    {
        private IUserService userService;
        public FrmLogin()
        {
            InitializeComponent();
            userService = new UserService();
            txtUserPassword.PasswordChar = '*';

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = txtUserName.Text;
            user.UserPassword = txtUserPassword.Text;
            bool isValidUser = userService.checkUserAuthentication(user);

            if (isValidUser)
            {
                AuthinticationSuccess();
            }

        }

        private void AuthinticationSuccess()
        {
            PharmaMDI pharmaMdi = new PharmaMDI();
            pharmaMdi.Show();
            this.Hide();
        }
    }
}
