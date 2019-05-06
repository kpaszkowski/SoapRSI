using Client.CowService;
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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for AddCowWindow.xaml
    /// </summary>
    public partial class AddCowWindow : Window
    {
        CowServiceClient CowServiceClient;
        public AddCowWindow()
        {
            InitializeComponent();
            this.CowServiceClient = new CowServiceClient();
            CowBread.ItemsSource = Enum.GetValues(typeof(CowBreed)).Cast<CowBreed>();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            this.CowServiceClient.AddCow(Name.Text, (CowBreed)Enum.Parse(typeof(CowBreed), CowBread.Text),
                DateTime.Parse(birth.Text), DateTime.Parse(calving.Text), TagNumber.Text);
            this.Close();
        }
    }
}
