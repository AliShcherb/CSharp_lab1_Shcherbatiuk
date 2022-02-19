using System.Windows;
using CSharp_lab1_Shcherbatiuk.ViewModels;

namespace CSharp_lab1_Shcherbatiuk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AnalyzerViewModel();
        }
    }
}
