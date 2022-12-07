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
using data_editor.Services;
using data_editor.Pages;

namespace data_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            frame.Navigate(new PageMain(null));
        }

        private void ButtonRead_Click(object sender, RoutedEventArgs e)
        {
            if (frame.Content.GetType().Name == "PageMain")
            {
                var pageMain = (PageMain)frame.Content;

                pageMain.ReadFromJson();

                frame.Refresh();
            }
        }

        private void ButtonWrite_Click(object sender, RoutedEventArgs e)
        {
            if (frame.Content.GetType().Name == "PageMain")
            {
                var pageMain = (PageMain)frame.Content;

                pageMain.WriteToJson();

                frame.Refresh();
            }
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (frame.Content.GetType().Name == "PageMain")
            {
                frame.Refresh();
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new PageAdd());
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (frame.Content.GetType().Name == "PageMain")
            {
                var pageMain = (PageMain)frame.Content;

                pageMain.ButtonDeleteImplementation();

                frame.Refresh();
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (frame.Content.GetType().Name == "PageMain")
            {
                var pageMain = (PageMain)frame.Content;

                pageMain.ButtonEditImplementation();

                frame.Refresh();
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonConnecrionString_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new PageConnectionString());
        }

        private void ButtonFonts_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new PageFonts());
        }
    }
}
