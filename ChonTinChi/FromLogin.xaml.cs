using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChonTinChi
{
    /// <summary>
    /// Interaction logic for FromLogin.xaml
    /// </summary>
    public partial class FromLogin : Page
    {
        public String tentaikhoan;
        public String matkhautaikhoan;
        public int MaSV;
        //public const string ConnectionString = "Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=DoAnCoSo;Integrated Security=True";//day la chuoi ket noi;
        //public const string ConnectionString = "Data Source=DESKTOP-BV9FQL0\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public const string ConnectionString = "Data Source=DESKTOP-CQME86L;Initial Catalog=DANGKITINCHI;Integrated Security=True";
        SqlConnection con = new SqlConnection(ConnectionString);
        public FromLogin()
        {
            InitializeComponent();
        }
        private void Text_TenDangNhap_MouseDown(object sender, MouseButtonEventArgs e)
        {/*
            Text_TenDangNhap.Focus();
            */
        }

        private void txt_TenDangNhap_TextChanged(object sender, TextChangedEventArgs e)
        {/*
            if (string.IsNullOrEmpty(txt_TenDangNhap.Text) && txt_TenDangNhap.Text.Length > 0)
            {
                txt_TenDangNhap.Visibility = Visibility.Collapsed;
            }
            else
            {
                txt_TenDangNhap.Visibility = Visibility.Visible;
            }*/
        }


        private void Text_MatKhau_MouseDown(object sender, MouseButtonEventArgs e)
        {

            txt_MatKhau.Focus();

        }

        private void txt_Matkhau_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MatKhau.Password) && txt_MatKhau.Password.Length > 0)
            {
                Text_MatKhau.Visibility = Visibility.Collapsed;
            }
            else
            {
                Text_MatKhau.Visibility = Visibility.Visible;
            }
        }

        private void DangNhap_Click(object sender, RoutedEventArgs e)
        {
            string tendangnhap = txt_TenDangNhap.Text;
            string matkhau = txt_MatKhau.Password;
            if (tendangnhap == "admin" && matkhau == "admin")
            {
                FROM_Frame.Content = new FromAdmin();
            }
            else
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from SINHVIEN where  Tendangnhap = '" + tendangnhap + "' and Matkhau ='" + matkhau + "'", con);//lay het du lieu trong bang firstTable,va truy van
                SqlDataReader sdr = cmd.ExecuteReader();//van chuyen du lieu

                if (sdr.Read())
                {
                    String TDN = sdr["Tendangnhap"].ToString();
                    String MK = sdr["Matkhau"].ToString();
                    if (tendangnhap == TDN && matkhau == MK)
                    {
                        MaSV = sdr.GetInt32(0);
                        FROM_Frame.Content = new FromSinhVien(MaSV);
                    }

                }
                else
                {
                    MessageBox.Show("Sai mật khẩu!");
                }
                con.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }
            


        }


    }
}