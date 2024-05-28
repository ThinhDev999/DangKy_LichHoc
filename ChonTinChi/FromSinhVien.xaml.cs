using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using static ChonTinChi.FromSinhVien;


namespace ChonTinChi
{
    /// <summary>
    /// Interaction logic for FromSinhVien.xaml
    /// </summary>
    public partial class FromSinhVien : Page
    {
        int msv;
        //Constructor
        public FromSinhVien()
        {
            InitializeComponent();
        }

        public FromSinhVien(int maSV)
        {
            msv= maSV;
            InitializeComponent();
        }

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

            FromDataGrid.Content = new HomePage(msv);
            Tg_Btn2.IsChecked = false;
            Tg_Btn3.IsChecked = false;
            DangKyHoc_ToggleButton.IsChecked = false;
            KetQuaDangKy_ToggleButton.IsChecked = false;
            LichHoc_ToggleButton.IsChecked = false;
            LichCanNhan_ToggleButton.IsChecked = false;

        }

        private void DangKyTrucTuyen_ToggleButton_CLick(object sender, RoutedEventArgs e)
        {
            HomePage_ToggleButton.IsChecked = false;
            Tg_Btn3.IsChecked = false;
            LichHoc_ToggleButton.IsChecked = false;
            LichCanNhan_ToggleButton.IsChecked = false;
        }

        private void ThoiKhoaBieu_ToggleButton_CLick(object sender, RoutedEventArgs e)
        {
            HomePage_ToggleButton.IsChecked = false;
            Tg_Btn2.IsChecked = false;
            DangKyHoc_ToggleButton.IsChecked = false;
            KetQuaDangKy_ToggleButton.IsChecked = false;
        }
        private void ToggleButton_Click_DangKyHoc(object sender, RoutedEventArgs e)
        {

            FromDataGrid.Content = new DangKyHoc(msv);
            KetQuaDangKy_ToggleButton.IsChecked = false;
            HomePage_ToggleButton.IsChecked = false;
            Tg_Btn3.IsChecked = false;
            LichHoc_ToggleButton.IsChecked = false;
            LichCanNhan_ToggleButton.IsChecked = false;


        }
        private void ToggleButton_Click_KetQuaDangKy(object sender, RoutedEventArgs e)
        {
            FromDataGrid.Content = new KetQuaDangKy(msv);
            DangKyHoc_ToggleButton.IsChecked = false;
            HomePage_ToggleButton.IsChecked = false;
            Tg_Btn3.IsChecked = false;
            LichHoc_ToggleButton.IsChecked = false;
            LichCanNhan_ToggleButton.IsChecked = false;

        }

        private void ToggleButton_Click_LichHoc(object sender, RoutedEventArgs e)
        {

            FromDataGrid.Content = new LichHoc(msv);
            HomePage_ToggleButton.IsChecked = false;
            Tg_Btn2.IsChecked = false;
            DangKyHoc_ToggleButton.IsChecked = false;
            KetQuaDangKy_ToggleButton.IsChecked = false;
            LichCanNhan_ToggleButton.IsChecked = false;
        }
        private void ToggleButton_Click_LichCaNhan(object sender, RoutedEventArgs e)
        {
            FromDataGrid.Content = new LichCaNhan(msv);
            HomePage_ToggleButton.IsChecked = false;
            Tg_Btn2.IsChecked = false;
            DangKyHoc_ToggleButton.IsChecked = false;
            KetQuaDangKy_ToggleButton.IsChecked = false;
            LichHoc_ToggleButton.IsChecked = false;

        }
    }
    

   
}
