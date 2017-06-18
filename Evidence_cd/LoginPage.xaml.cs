using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Evidence_cd
{
    /// <summary>
    /// Interakční logika pro LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        TodoItemUser currentUserLogin;
        TodoItemUser currentUserMain;
        public LoginPage(TodoItemUser currentUser)
        {
            InitializeComponent();
            currentUserLogin = currentUser;
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            checkUser();
        }

        public async void checkUser()
        {
            currentUserLogin = new TodoItemUser();
            
            currentUserLogin.Username = inputName.Text;
            currentUserLogin.Password = inputPassword.Text;
            var result = await App.Database.GetItemsNotDoneAsyncUser();
            foreach (TodoItemUser todoItemUser in result)
            {
                if (currentUserLogin.Password == todoItemUser.Password)
                {
                    currentUserMain = new TodoItemUser();
                    currentUserMain = currentUserLogin;
                    MainWindow main = new MainWindow(currentUserMain);
                    main.Show();
                }
                else
                {
                   // echo.Text = "Wrong username or password.";
                }
            }
        }
    }
}
