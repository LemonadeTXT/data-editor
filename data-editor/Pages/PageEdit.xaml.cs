using data_editor.Models;
using data_editor.Services;
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

namespace data_editor.Pages
{
    /// <summary>
    /// Interaction logic for PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        private readonly UserService _userService;

        private readonly User _user;

        public PageEdit(User user)
        {
            _userService = new UserService();

            _user = user;

            InitializeComponent();

            textboxUserName.Text = user.UserName;
            textboxPassword.Text = user.Password;
            textboxStatus.Text = user.Status;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(textboxUserName.Text) ||
                string.IsNullOrEmpty(textboxPassword.Text) ||
                string.IsNullOrEmpty(textboxStatus.Text)))
            {
                _user.UserName = textboxUserName.Text;
                _user.Password = textboxPassword.Text;
                _user.Status = textboxStatus.Text;

                _userService.Edit(_user);

                ButtonBack_Click(null, null);
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMain(null));
        }
    }
}
