using System.Windows;
using data_editor.Pages;

namespace data_editor
{
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
