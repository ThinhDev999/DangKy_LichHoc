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

namespace ChonTinChi
{
    /// <summary>
    /// Interaction logic for FromAdmin.xaml
    /// </summary>
    public partial class FromAdmin : Page
    {
        public FromAdmin()
        {
            InitializeComponent();
        }
        /*
      private void Border_MouseDown(object sender, MouseButtonEventArgs e)
      {

          if (e.ChangedButton == MouseButton.Left)
          {
              this.DragMove();
          }
      }
      private bool IsMaximized = false;

      private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
          if (e.ClickCount == 2)
          {
              if (IsMaximized)
              {
                  this.WindowState = WindowState.Normal;
                  this.Width = 1080;
                  this.Height = 720;

                  IsMaximized = false;


              }
              else
              {
                  this.WindowState = WindowState.Normal;

                  IsMaximized = true;

              }
          }
      }
      */


        private void Logout_click(object sender, RoutedEventArgs e)
        {
            // Environment.Exit(1);
            Application.Current.MainWindow.Close();
        }

        private void App_Minimize_Click(object sender, RoutedEventArgs e)
        {
            // Minimize the Window 
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void App_Maximize_Click(object sender, RoutedEventArgs e)
        {
            // Maximize / Normal Window State

            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;



            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;



            }
            /*
            if (WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;

            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;

                }
            }
            */
        }


        private void ToggleButton_Click_Home_Page(object sender, RoutedEventArgs e)
        {
            FromDataGrid.Content = new HomePage();
            Tg_Btn2.IsChecked = false;
            Class_ToggleButton.IsChecked = false;
            Student_ToggleButton.IsChecked = false;
            Subject_ToggleButton.IsChecked = false;
        }

        private void Manage_ToggleButton_CLick(object sender, RoutedEventArgs e)
        {
            HomePage_ToggleButton.IsChecked = false;
        }
        private void ToggleButton_Click_Subject(object sender, RoutedEventArgs e)
        {
            FromDataGrid.Content = new Subject();
            Class_ToggleButton.IsChecked = false;
            Student_ToggleButton.IsChecked = false;
        }
        private void ToggleButton_Click_Class(object sender, RoutedEventArgs e)
        {
            FromDataGrid.Content = new Class();
            Subject_ToggleButton.IsChecked = false;
            Student_ToggleButton.IsChecked = false;

        }

        private void ToggleButton_Click_Student(object sender, RoutedEventArgs e)
        {
            FromDataGrid.Content = new Student();
            Subject_ToggleButton.IsChecked = false;
            Class_ToggleButton.IsChecked = false;
        }
    }
}
