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
using data_editor.Connection;

namespace data_editor.Pages
{
    /// <summary>
    /// Interaction logic for PageConnectionString.xaml
    /// </summary>
    public partial class PageConnectionString : Page
    {
        private ConnectionDb _connectionDb;

        public PageConnectionString()
        {
            _connectionDb = new ConnectionDb();

            _connectionDb.ConnectionString = _connectionDb.GetConnectionStringFromFile();

            InitializeComponent();

            textboxConnString.Text = _connectionDb.ConnectionString;
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            _connectionDb.SetConnectionStringToFile(textboxConnString.Text);

            ButtonBack_Click(null, null);
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMain(null));
        }
    }
}
