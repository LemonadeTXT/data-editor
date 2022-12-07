using data_editor.Models;
using data_editor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace data_editor.Pages
{
    /// <summary>
    /// Interaction logic for PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        private readonly FontFamily _font;

        private readonly UserService _userService;

        private readonly DataStorageJson _dataStorageJson;

        public PageMain(FontFamily font)
        {
            _userService = new UserService();

            _font = font;

            _dataStorageJson = new DataStorageJson();

            InitializeComponent();

            dataGrid.ItemsSource = _userService.GetAllUsers();

            if (_font != null)
            {
                dataGrid.FontFamily = _font;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAdd());
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            ButtonDeleteImplementation();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            ButtonEditImplementation();
        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = _userService.Find(textboxFind.Text);
        }

        public void ButtonDeleteImplementation()
        {
            if (dataGrid.SelectedItems != null)
            {
                var records = dataGrid.SelectedItems.OfType<User>().ToList();

                _userService.Delete(records);

                dataGrid.ItemsSource = _userService.GetAllUsers();
            }
        }

        public void ButtonEditImplementation()
        {
            if (dataGrid.SelectedItem != null)
            {
                var record = (User)dataGrid.SelectedItem;

                NavigationService.Navigate(new PageEdit(record));
            }
        }

        public void ReadFromJson()
        {
            _userService.AddFullUsers(_dataStorageJson.Read());

            dataGrid.ItemsSource = _userService.GetAllUsers();
        }

        public void WriteToJson()
        {
            if (dataGrid.SelectedItems != null)
            {
                var records = dataGrid.SelectedItems.OfType<User>().ToList();

                _dataStorageJson.Write(records);
            }
        }

        public void RefreshAll()
        {
            if (dataGrid.SelectedItems != null)
            {
                var records = dataGrid.SelectedItems.OfType<User>().ToList();

                _dataStorageJson.Write(records);
            }
        }
    }
}