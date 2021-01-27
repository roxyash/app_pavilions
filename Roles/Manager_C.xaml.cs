using System;
using PavileniDB.ShoppingMall;
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

namespace PavileniDB.Roles
{
    /// <summary>
    /// Логика взаимодействия для Manager_C.xaml
    /// </summary>
    public partial class Manager_C : Window
    {
        public Manager_C()
        {
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Visibility = Visibility.Visible;
            this.Close();
        }

        private void SverProgramm(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ExitProgramm(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ShoppingMall(object sender, RoutedEventArgs e)
        {
            ShoppingMallWindow shoppingMallWindow = new ShoppingMallWindow();
            shoppingMallWindow.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
