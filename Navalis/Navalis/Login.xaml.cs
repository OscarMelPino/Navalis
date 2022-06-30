using System;
using System.Data.SqlClient;
using System.Windows;

namespace Navalis
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        #region Methods
        public bool TryLogin()
        {
            bool loginSucess = false;
            string username = TbUsername.Text;
            string password = TbPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                _ = MessageBox.Show($"No puedes dejar campos vacíos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            using (var dbcontext = new SqlConnection())
            {
                try
                {
                    //login code
                    loginSucess = true;
                }
                catch (Exception ex)
                {
                    var temp = ex.Message;
                    loginSucess = false;
                }
            }

            return loginSucess;
        }
        #endregion

        #region Events
        public void TryLogin(object sender, RoutedEventArgs ev)
        {
            if (TryLogin())
                this.Close();
        }
        #endregion
    }
}
