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
    /// Interakční logika pro RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        TodoItemUser user;
        TodoItemUser currentUser;
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        { 
            User();
            checkUser();
        }
        public void User()
        {
            user = new TodoItemUser();
            string admin = "admin";
            user.Username = inputName.Text;
            user.Password = inputPassword.Text;

            if (user.Username == admin)
            {
                user.Level = 1;
            }
            else
            {
                user.Level = 0;
            }
            

        }


        public async void checkUser()
        {
                var result = await App.Database.GetItemsNotDoneAsyncUser();
                foreach (TodoItemUser todoItemUser in result)
                {
                    if (user.Username != todoItemUser.Username)
                    {
                        echo.Text = "Registration succesful";
                        await App.Database.SaveItemAsyncUser(user);
                        currentUser = new TodoItemUser();
                        currentUser = user;

                }
                    else
                    {
                        echo.Text = "user already exists";
                    }
                  }

            }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage(currentUser));
        }
    }
}
