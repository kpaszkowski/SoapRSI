using Client.CowService;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
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
using Paragraph = iTextSharp.text.Paragraph;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CowServiceClient CowServiceClient;
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

        public MainWindow()
        {
            InitializeComponent();
            this.CowServiceClient = new CowServiceClient();
        }

        private void GetAllCowsButtonClick(object sender, RoutedEventArgs e)
        {
            DisplayWindow displayWindow = new DisplayWindow(CowServiceClient.GetAllCows(), DisplayType.All)
            {
                DataContext = this,
                Owner = mainWindow
            };
            displayWindow.ShowDialog();
        }
        private void GetCalvingCowsButtonClick(object sender, RoutedEventArgs e)
        {
            DisplayWindow displayWindow = new DisplayWindow(CowServiceClient.GetCowsNearToCalving(), DisplayType.Calving)
            {
                DataContext = this,
                Owner = mainWindow
            };
            displayWindow.ShowDialog();
        }
        private void GetDryOffCowsButtonClick(object sender, RoutedEventArgs e)
        {
            DisplayWindow displayWindow = new DisplayWindow(CowServiceClient.GetCowsNearToDryOff(), DisplayType.DryOff)
            {
                DataContext = this,
                Owner = mainWindow
            };
            displayWindow.ShowDialog();
        }
        private void AddCowButtonClick(object sender, RoutedEventArgs e)
        {
            AddCowWindow displayWindow = new AddCowWindow
            {
                DataContext = this,
                Owner = mainWindow
            };
            displayWindow.ShowDialog();
        }
        private void GetPdfButtonClick(object sender, RoutedEventArgs e)
        {
            IList<Cow> cows = CowServiceClient.GetAllCows();
            if (cows.Any())
            {
                Document doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc,new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+"\\Pdf.pdf", FileMode.Create));
                doc.Open();
                foreach (var item in cows)
                {
                    Paragraph paragraph = new Paragraph(item.Id+"\n"+ item.Name + "\n" + item.TagNumber + "\n" + item.DateOfBirth + "\n" + item.DateOfCalving + "\n\n");
                    doc.Add(paragraph);
                }
                doc.Close();
            }
        }
    }
}
