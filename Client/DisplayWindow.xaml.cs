using Client.CowService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DisplayWindow.xaml
    /// </summary>
    public partial class DisplayWindow : Window
    {
        CowServiceClient CowServiceClient;
        public ObservableCollection<Cow> Cows { get; set; }
        public DisplayType displayType { get; set; }
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        public DisplayWindow(IList<Cow> cows, DisplayType displayType)
        {
            InitializeComponent();
            this.CowServiceClient = new CowServiceClient();
            this.Cows = new ObservableCollection<Cow>();
            this.displayType = displayType;
            foreach (var item in cows)
            {
                Cows.Add(item);
            }
            CowsGrid.ItemsSource = Cows;
        }

        private void RemoveCowClick(object sender, RoutedEventArgs e)
        {
            var currentCow = (Cow)CowsGrid.SelectedItem;
            CowServiceClient.RemoveCow(currentCow.Id);
            RefreshGrid();
        }
        private void UpdateCowClick(object sender, RoutedEventArgs e)
        {
            var currentCow = (Cow)CowsGrid.SelectedItem;
            UpdateCowWindow displayWindow = new UpdateCowWindow(currentCow.Id)
            {
                DataContext = this,
                Owner = mainWindow
            };
            displayWindow.ShowDialog();
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            IList<Cow> cows = null;
            switch (displayType)
            {
                case DisplayType.All:
                    cows = CowServiceClient.GetAllCows();
                    break;
                case DisplayType.Calving:
                    cows = CowServiceClient.GetAllCows();
                    break;
                case DisplayType.DryOff:
                    cows = CowServiceClient.GetAllCows();
                    break;
                default:
                    break;
            }
            Cows.Clear();
            foreach (var item in cows)
            {
                Cows.Add(item);
            }
            CowsGrid.ItemsSource = Cows;
        }
    }
}
