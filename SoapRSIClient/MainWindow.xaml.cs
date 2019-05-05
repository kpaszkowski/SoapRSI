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

namespace SoapRSIClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Cow_Button_Click(object sender, RoutedEventArgs e)
        {
            CowAddWindow wnd = new CowAddWindow();
            wnd.Show();
            
            this.Close();
        }

        private void Edit_Cow_Button_Click(object sender, RoutedEventArgs e)
        {
            CowEditWindow wnd = new CowEditWindow();
            wnd.Show();
            this.Close();
        }
    }
}
