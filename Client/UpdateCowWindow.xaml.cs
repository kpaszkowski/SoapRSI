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
    /// Interaction logic for UpdateCowWindow.xaml
    /// </summary>
    public partial class UpdateCowWindow : Window
    {
        CowServiceClient CowServiceClient;
        public int UpdateId { get; set; }
        public UpdateCowWindow(int id)
        {
            InitializeComponent();
            this.CowServiceClient = new CowServiceClient();
            CowBread.ItemsSource = Enum.GetValues(typeof(CowBreed)).Cast<CowBreed>();
            this.UpdateId = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.CowServiceClient.UpdateCow(UpdateId, Name.Text, (CowBreed)Enum.Parse(typeof(CowBreed), CowBread.Text),
                DateTime.Parse(birth.Text), DateTime.Parse(calving.Text), TagNumber.Text);
            this.Close();
        }
    }
}
