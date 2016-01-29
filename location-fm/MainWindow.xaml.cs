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

namespace location_fm
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

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (SharedState.Authorizer == null)
                new OAuth().Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var type = Type.GetType((sender as MenuItem).Tag as string);
            Window formInst = (Window)Activator.CreateInstance(type);

            formInst.Show();
        }
    }
}
