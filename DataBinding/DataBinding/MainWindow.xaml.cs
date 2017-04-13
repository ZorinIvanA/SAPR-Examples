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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty SomethingProperty =
            DependencyProperty.RegisterAttached("Something", typeof(String), typeof(MainWindow),
                new FrameworkPropertyMetadata(String.Empty));

        public static void SetSomething(UIElement element, String value)
        {
            element.SetValue(SomethingProperty, value);
        }

        public static String GetSomething(UIElement element)
        {
            return (String)element.GetValue(SomethingProperty);
        }

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                this.FindResource("StringToColorConverter");
            }
            catch
            {

            }

        }
    }
}
