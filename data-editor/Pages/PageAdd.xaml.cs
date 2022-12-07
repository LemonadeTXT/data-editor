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
    /// Interaction logic for PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        private readonly UserService _userService;

        public PageAdd()
        {
            _userService = new UserService();

            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(textboxUserName.Text) ||
                string.IsNullOrEmpty(textboxPassword.Text)))
            {
                _userService.Add(textboxUserName.Text, textboxPassword.Text);

                ButtonBack_Click(null, null);
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMain(null));
        }
    }
}
