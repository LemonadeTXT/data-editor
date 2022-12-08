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
    /// Interaction logic for PageFonts.xaml
    /// </summary>
    public partial class PageFonts : Page
    {
        public PageFonts()
        {
            InitializeComponent();

            GetFonts();
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            var font = comboboxFonts.SelectedItem;

            if (font != null)
            {
                NavigationService.Navigate(new PageMain((FontFamily)font));
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMain(null));
        }

        private void GetFonts()
        {
            foreach (FontFamily font in Fonts.SystemFontFamilies)
            {
                comboboxFonts.Items.Add(font);
            }
        }

        private void comboboxFonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxFonts.SelectedItem != null)
            {
                textblockTest.FontFamily = (FontFamily)comboboxFonts.SelectedItem;
            }
        }
    }
}
