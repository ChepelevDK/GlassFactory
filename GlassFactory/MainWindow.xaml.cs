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

namespace GlassFactory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("укуси меня пчОла, я не помню когда спал");
        }

        private void simplexButton_Click(object sender, RoutedEventArgs e)
        {
            SimplexMethod simplex = new SimplexMethod();
            simplex.Show();
        }

        private void transportButton_Click(object sender, RoutedEventArgs e)
        {
            TransportEx transport = new TransportEx();
            transport.Show();
        }
    }
}
