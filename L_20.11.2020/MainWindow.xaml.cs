using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace L_20._11._2020
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."+
                    " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."+
                    " Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."+
                     "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";


        List<Brush> BrushColection;
        public MainWindow()
        {
            InitializeComponent();
          
            for (var i = 16; i < 30; i++)
            {
                ComboboxFontSize.Items.Add((double)i);
            }
            ComboBoxColor.ItemsSource = typeof(Colors).GetProperties();

        
        }

        private void butBold_Click(object sender, RoutedEventArgs e)
        {
            this.ParagrafText.FontWeight = FontWeights.Bold;
        }

        private void ButtonItalic(object sender, RoutedEventArgs e)
        {
            this.ParagrafText.FontStyle = FontStyles.Italic;
        }

        private void buttonUnderline(object sender, RoutedEventArgs e)
        {
            this.ParagrafText.TextDecorations = TextDecorations.Underline;
        }

        private void buttonClear(object sender, RoutedEventArgs e)
        {
            this.ParagrafText.FontWeight = FontWeights.Normal;
            this.ParagrafText.FontStyle = FontStyles.Normal;
            this.ParagrafText.TextDecorations = null;
           

        }

      

        private void ComboboxFontSize_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {        
            string value = ComboboxFontSize.SelectedItem.ToString();
       
             this.ParagrafText.FontSize = Convert.ToDouble(value);
        }

        private void ComboBoxColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(ComboBoxColor.SelectedItem as PropertyInfo).GetValue(null, null);

            this.ParagrafText.Background = new SolidColorBrush(selectedColor);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void TextBoxEnd_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in ParagrafText.Inlines)
            {
                if (i > Convert.ToInt32(TextBoxStart.Text) && i < Convert.ToInt32(TextBoxEnd.Text))
                {
                    item.Foreground = Brushes.Orange;
                    item.FontSize = 20;
                    item.FontStyle = FontStyles.Italic;
                    item.TextDecorations = TextDecorations.Underline;
                    item.FontWeight = FontWeights.Bold;
                }
                i++;
            }
        }
    }
}
