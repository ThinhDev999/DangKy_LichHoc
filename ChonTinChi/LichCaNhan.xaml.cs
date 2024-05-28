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
using static ChonTinChi.SinhVien;

namespace ChonTinChi
{
    /// <summary>
    /// Interaction logic for LichCaNhan.xaml
    /// </summary>
    public partial class LichCaNhan : Page
    {
        public const string ConnectionString = "Data Source=DESKTOP-CQME86L;Initial Catalog=DANGKITINCHI;Integrated Security=True";
        //public const string ConnectionString = "Data Source=DESKTOP-BV9FQL0\\SQLEXPRESS;Initial Catalog=DANGKITINCHI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SqlConnection con = new SqlConnection(ConnectionString);
        int masv;
        SinhVien sinhVien;
        public LichCaNhan()
        {
            InitializeComponent();
        }
        public LichCaNhan(int maSV)
        {
            masv=maSV;
            sinhVien = new SinhVien(masv);
            InitializeComponent();
            DataGridLichCaNhan();
        }

        public void DataGridLichCaNhan()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nội dung công việc");
            dt.Columns.Add("Thời gian công việc");
            for(int i=0;i<sinhVien.lichcanhanList.Count;i++)
            {
                DataRow dr;
                dr = dt.NewRow();
                String tg = "";
                tg += sinhVien.lichcanhanList[i].thu.ToString() + "  Thời gian (Tiết):" + sinhVien.lichcanhanList[i].tietbatdau.ToString() + "-" + sinhVien.lichcanhanList[i].tietketthuc.ToString();
                dr["Nội dung công việc"] = sinhVien.lichcanhanList[i].congviec;
                dr["Thời gian công việc"] = tg;
                dt.Rows.Add(dr);
            }
            LichCaNhanDG.ItemsSource = dt.DefaultView;
        }
        private void Them_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String sql = "INSERT INTO LichCaNhan VALUES ('"
                    + masv + "','"
                    + txt_tietdau.Text + "','"
                    + txt_tietcuoi.Text + "', N'" +
                    txt_thu.Text + "',N'"
                    + Cong_viec.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                //MessageBox.Show(sql);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lichcanhan a = new lichcanhan();
                a.congviec = Cong_viec.Text;
                a.tietbatdau = Int32.Parse(txt_tietdau.Text);
                a.tietketthuc = Int32.Parse(txt_tietcuoi.Text);
                a.thu = Int32.Parse(txt_thu.Text);
                sinhVien.lichcanhanList.Add(a);
                DataGridLichCaNhan();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            if (LichCaNhanDG.SelectedIndex.ToString() != null)
            {
                try
                {
                    int index = LichCaNhanDG.SelectedIndex;
                    if (index > 0 && index < sinhVien.lichcanhanList.Count)
                    {
                        String sql = "update LichCaNhan set Masinhvien='"
                            + masv + "', Tiet_bat_dau = '"
                            + txt_tietdau.Text + "', Tiet_ket_thuc = '"
                            + txt_tietcuoi.Text + "', Thu = N'"
                            + txt_thu.Text + "',Cong_viec=N'"
                            + Cong_viec.Text
                            + "'  WHERE Masinhvien = '"
                            + masv + "' and Tiet_bat_dau='"
                            + sinhVien.lichcanhanList[index].tietbatdau.ToString() + "' and Tiet_ket_thuc='"
                            + sinhVien.lichcanhanList[index].tietketthuc.ToString()
                            + "' and Thu=N'"
                            + sinhVien.lichcanhanList[index].thu + "' and Cong_viec=N'"
                            + sinhVien.lichcanhanList[index].congviec + "'";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        sinhVien.DanhSachLichCaNhan();
                        DataGridLichCaNhan();
                    }
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            if (LichCaNhanDG.SelectedIndex.ToString() != null)
            {
                int index = LichCaNhanDG.SelectedIndex;
                if (index > 0 && index < sinhVien.lichcanhanList.Count)
                {
                    try
                    {
                        String sql = "delete from LichCaNhan "
                            + "  WHERE Masinhvien = '"
                            + masv + "' and Tiet_bat_dau='" + txt_tietdau.Text + "' and Tiet_ket_thuc='" + txt_tietcuoi.Text + "' and Thu=N'" + txt_thu.Text + "' and Cong_viec=N'" + Cong_viec.Text + "'";
                        //MessageBox.Show(sql);
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        sinhVien.lichcanhanList.RemoveAt(sinhVien.lichcanhanList.Count - 1);
                        DataGridLichCaNhan();
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
        }

        private void Choose_cong_viec(object sender, SelectionChangedEventArgs e)
        {
            if (LichCaNhanDG.SelectedIndex.ToString() != null)
            {
                int index = LichCaNhanDG.SelectedIndex;
                if (index >= 0 && index < sinhVien.lichcanhanList.Count)
                {

                    Cong_viec.Text = sinhVien.lichcanhanList[index].congviec;
                    txt_tietdau.Text = sinhVien.lichcanhanList[index].tietbatdau.ToString();
                    txt_tietcuoi.Text = sinhVien.lichcanhanList[index].tietketthuc.ToString();
                    txt_thu.Text = sinhVien.lichcanhanList[index].thu.ToString();
                }
            }
        }
    }
}
