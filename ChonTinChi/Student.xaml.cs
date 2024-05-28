using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.SqlClient;
using System.Data;


namespace ChonTinChi
{
    /// <summary>
    /// Interaction logic for Class.xaml
    /// </summary>
    public partial class Student : Page
    {
        //DoAnCoSoEntities1 SV = new DoAnCoSoEntities1();
        ObservableCollection<SINHVIEN> dssv = new ObservableCollection<SINHVIEN>();

        public const string ConnectionString = "Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=DoAnCoSo;Integrated Security=True";//day la chuoi ket noi
        SqlConnection con = new SqlConnection(ConnectionString);

        public Student()
        {
            InitializeComponent();
            DataGrid();
            //   membersDataGrid.ItemsSource = GetClassList();

        }
        public class SINHVIEN
        {
            private int _MSV;
            private string _TDN;
            private string _MK;
            private string _N;
            private string _KH;
            private string _MN;
            public int MSV { get { return _MSV; } set { _MSV = value; } }
            public string TDN { get { return _TDN; } set { _TDN = value; } }
            public string MK { get { return _MK; } set { _MK = value; } }
            public string N { get { return _N; } set { _N = value; } }
            public string KH { get { return _KH; } set { _KH = value; } }
            public string MN { get { return _MN; } set { _MN = value; } }
        }



        public ObservableCollection<SINHVIEN> GetClassList()
        {

            ObservableCollection<SINHVIEN> classList = new ObservableCollection<SINHVIEN>();
            try
            {
                con.Open();
                String sql = "select * from SINHVIEN";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SINHVIEN sv = new SINHVIEN();
                    sv.MSV = sdr.GetInt32(0);
                    sv.TDN = sdr.GetString(1);
                    sv.MK = sdr.GetString(2);
                    sv.N = sdr.GetString(3);
                    sv.KH = sdr.GetString(4);
                    sv.MN = sdr.GetString(5);
                    classList.Add(sv);
                }
                con.Close();
                return classList;
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
                return null;
            }
            // HocPhan_ComboBox.Items.Clear();

        }

        //public void Loadgrid()
        // {
        //     var data = from r in SV.SINHVIENs select r;
        //    membersDataGrid.ItemsSource = data.ToList();
        // }
        public void DataGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from SINHVIEN", con);//lay het du lieu trong bang firstTable,va truy van
            DataTable dt = new DataTable();

            con.Open();//mo ket noi
            SqlDataReader sdr = cmd.ExecuteReader();//van chuyen du lieu
                                                    // SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            dt.Load(sdr);//tao kho du lieu
                         // sdr.Fill(dt);
                         //dong ket noi
            con.Close();
            membersDataGrid.ItemsSource = dt.DefaultView;


        }
        /*
        private void NewStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO SINHVIEN VALUES (0,'NULL','NULL','NULL','NULL','NULL')", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DataGrid();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            
          
        }
        */
        //DataTable dt1 = new DataTable();
        // SqlDataAdapter sda = new SqlDataAdapter();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
                 con.Open();


                 SqlCommand com = new SqlCommand("SELECT * from SINHVIEN", con);

                 sda = new SqlDataAdapter(com);
                 dt1 = new DataTable();
                 sda.Fill(dt1);

                 membersDataGrid.ItemsSource = dt1.DefaultView;

                 con.Close();


                 */


        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            //int sv_msv = (membersDataGrid.SelectedItem as SINHVIEN).Ma_sinh_vien;
            //SINHVIEN sv = SV.SINHVIENs.Where(r => r.Ma_sinh_vien == sv_msv).Single();
            //  SV.SINHVIENs.Remove(sv);
            //  SV.SaveChanges();
            //  membersDataGrid.ItemsSource = SV.SINHVIENs.ToList();

            /* try
             // {

               //   if (membersDataGrid.SelectedItems.Count == 1)
                //  {
               //       int selectedIndex = membersDataGrid.SelectedIndex;
                //      var row = dataTable.Rows[selectedIndex];
                //      row.Delete();

                 //     dataAdapter.Update(dataTable);
                 // }
                  DataRowView row = (DataRowView)membersDataGrid.SelectedItem;

                  dt1.Rows.Remove(row.Row);
                  sda.Update(dt1);


              }
              catch(SqlException err)
              {
                  MessageBox.Show(err.ToString());
              }
            */
            //   int count = membersDataGrid.SelectedItems.Count;
            //   dssv.RemoveAt(count);
            //   membersDataGrid.ItemsSource = dssv;
            DataRowView dgs = (DataRowView)membersDataGrid.SelectedItem;
            string MSV = dgs["Ma_sinh_vien"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete" +
                " SINHVIEN " +
                "WHERE Ma_sinh_vien = '" + MSV + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            // membersDataGrid.ItemsSource = GetClassList();
            DataGrid();



        }


        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            /*  try
              {
                  var _emp = e.Row.Item as SINHVIEN;
             //     MessageBox.Show(
               //     _emp.TDN, _emp.MK);
              }catch(SqlException err)
              {
                  MessageBox.Show(err.ToString());
              }
             */

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
            if (membersDataGrid.SelectedIndex.ToString() != null)
            {
                DataRowView dgs = (DataRowView)membersDataGrid.SelectedItem;

                if (dgs != null)
                {
                    //     them_id_text.Text = dgs["ID"].ToString();
                  //  string a = dgs["Ma_sinh_vien"].ToString();
                  //  MessageBox.Show(a);


                }
            }*/
        }



        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedIndex.ToString() != null)
            {
                DataRowView dgs = (DataRowView)membersDataGrid.SelectedItem;

                string MSV = dgs["Ma_sinh_vien"].ToString();
                string TDN = dgs["Ten_dang_nhap"].ToString();
                string MK = dgs["Mat_khau"].ToString();
                string N = dgs["Name"].ToString();
                string KH = dgs["Khoa_hoc"].ToString();
                string MN = dgs["Ma_nganh"].ToString();

                con.Open();
                SqlCommand cmd = new SqlCommand("update SINHVIEN set Ten_dang_nhap = '" + TDN + "'," +
                "'" + MK + "'," +
                "'" + N + "'," +
                "'" + KH + "'," +
                "'" + MN + "'" +
                "WHERE Ma_sinh_vien = '" + MSV + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                DataGrid();

            }

        }

    }
}