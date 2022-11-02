using Firebase.Auth;
using MoneyLog.BLL;
using MoneyLog.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyLog.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        public static string loggedIn;

        private void pboxClose_Click(object sender, EventArgs e)
        {
            //Code to close this form
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            l.username = txtUsername.Text.Trim();
            l.password = txtPassword.Text.Trim();

            //Checking the login credentials


            var _firebaseAuthProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyDCBz5x5BL1VO6SaG4Ryc-70HZzv15N_S0"));
            try
            {
                //create the user
                try
                {
                    await _firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(l.username, l.password);
                }catch(Exception ex){
                    MessageBox.Show("User has been registered. Will login");
                }

                EmailUtil.SendEmail("Create a new user!", "Create a new user!", "regea.wang@gmail.com");

                //log in the new user
                var gmailAuthLink = await _firebaseAuthProvider
                                .SignInWithEmailAndPasswordAsync(l.username, l.password);
                string token = gmailAuthLink.FirebaseToken;
                if (token != null)
                {
                    frmAdminDashboard admin = new frmAdminDashboard();
                    admin.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed. Try Again");
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
