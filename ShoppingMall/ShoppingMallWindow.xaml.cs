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

namespace PavileniDB.ShoppingMall
{
    /// <summary>
    /// Логика взаимодействия для ShoppingMallWindow.xaml
    /// </summary>
    public partial class ShoppingMallWindow : Window
    {
        public ShoppingMallWindow()
        {
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Roles.Manager_C manager_C = new Roles.Manager_C();
            manager_C.Visibility = Visibility.Visible;
            this.Close();
        }

        private void ExitProgramm(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SverProgramm(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
