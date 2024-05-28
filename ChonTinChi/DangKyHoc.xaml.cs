using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Collections.ObjectModel;

namespace ChonTinChi
{
    /// <summary>
    /// Interaction logic for DangKyHoc.xaml
    /// </summary>
    public partial class DangKyHoc : Page
    {
        //DEFINE
        //public const string ConnectionString = "Data Source=DESKTOP-BV9FQL0\\SQLEXPRESS;Initial Catalog=DANGKITINCHI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public const string ConnectionString = "Data Source=DESKTOP-CQME86L;Initial Catalog=DANGKITINCHI;Integrated Security=True";
        public SqlConnection con = new SqlConnection(ConnectionString);
        int masv;
        SinhVien sinhVien;
        public List<int> tempLichHocTap = new List<int>();
        public int SelectedRow = -1;
        private ObservableCollection<TempLopType> Items = new ObservableCollection<TempLopType>();
        private ObservableCollection<TempLopType> Items1 = new ObservableCollection<TempLopType>();
        private int ItemsCount;
        private int Items1Count;

        public class TempLopType
        {
            public String TenLop;
            public String Thu;
            public String mon;
            public int TietBatDau;
            public int TietKetThuc;
            public int id;
            public override string ToString()
            {
                return this.TenLop + " || "+this.id+ " || " + this.Thu + " || Tiết:"+this.TietBatDau+"-"+this.TietKetThuc;
            }
        }
        public DangKyHoc()
        {
            InitializeComponent();
        }
        public DangKyHoc(int maSV)
        {
            masv = maSV;
            sinhVien = new SinhVien(masv);
            InitializeComponent();
            danhSachDaChonListView.ItemsSource = Items;
            danhSachLopConLaiListView.ItemsSource = Items1;
            //danhSachDaChonListView.
            PageReset();
            ItemsCount = sinhVien.lichhoctapList.Count;
            Items1Count =sinhVien.res.Count-sinhVien.lichhoctapList.Count;
        }

        private void PageReset()
        {
            Name.Text = sinhVien.curSinhVien.name;
            MASV.Text = masv.ToString();
            DataGridRe();
            fillComboBox();
            ClassFilter();
            FindCombos();
            ResetLichHocTapList();
        }
        private void DataGridRe()
        {
            try
            {
                String sql = "select * from lophoc " +
                    " where lophoc.masv ='" + sinhVien.masv + "'";
                SqlCommand cmd = new SqlCommand(sql, con);//lay het du lieu trong bang firstTable,va truy van

                DataTable dt = new DataTable();

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();//van chuyen du lieu
                                                        // SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                dt.Load(sdr);//tao kho du lieu
                             // sdr.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
                //MessageBox.Show("1");
            }
        }
        public void ResetLichHocTapList()
        {
            Items.Clear();
            Items1.Clear();
            String s = "";
            for (int i = 0; i < sinhVien.res.Count; i++)
            {
                int checkTonTai = 0;
                for (int j = 0; j < sinhVien.lichhoctapList.Count; j++)
                {
                    if (sinhVien.res[i].id == sinhVien.lichhoctapList[j].id)
                    {
                        checkTonTai = 1;
                    }
                }
                if (checkTonTai == 0)
                {
                    TempLopType a = new TempLopType();
                    a.TenLop = sinhVien.res[i].tenlop;
                    a.Thu = sinhVien.res[i].ngayhoc;
                    a.TietBatDau = sinhVien.res[i].tietbatdau;
                    a.TietKetThuc = sinhVien.res[i].tietketthuc;
                    a.id=sinhVien.res[i].id;
                    a.mon = sinhVien.res[i].tenhocphan;
                    Items1.Add(a);
                    //s += a.TenLop+" ";
                }
            }
            //s +="\n";
            for (int i=0;i<sinhVien.lichhoctapList.Count;i++)
            {
                TempLopType a = new TempLopType();
                a.TenLop =sinhVien.lichhoctapList[i].tenlop;
                a.Thu = sinhVien.lichhoctapList[i].ngayhoc;
                a.TietBatDau = sinhVien.lichhoctapList[i].tietbatdau;
                a.TietKetThuc = sinhVien.lichhoctapList[i].tietketthuc;
                a.id = sinhVien.lichhoctapList[i].id;
                a.mon = sinhVien.lichhoctapList[i].tenhocphan;
                Items.Add(a);
                //s += a.TenLop + " ";
            }
            //MessageBox.Show(s);
        }
        public void fillComboBox()
        {
            try
            {
                String sql = "select DISTINCT Tenhocphan from LOPHOC " +
                    "where manganh ='" + sinhVien.masv + "'";
                //MessageBox.Show(sql);
                SqlCommand cmd = new SqlCommand(sql, con);//lay het du lieu trong bang firstTable,va truy van
                con.Open();

                var sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    String THP = sdr.GetString(0);
                    HocPhan_ComboBox.Items.Add(THP);
                }


                sdr.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var HP = HocPhan_ComboBox.SelectedItem.ToString();
                con.Open();//mo ket noi
                String sql = "select * from LOPHOC WHERE Tenhocphan = N'" + HP + "' ";
                SqlCommand cmd = new SqlCommand(sql, con);

                DataTable dt = new DataTable();

                SqlDataReader sdr = cmd.ExecuteReader();

                dt.Load(sdr);

                datagrid.ItemsSource = dt.DefaultView;

                con.Close();
            }
            catch (SqlException err)
            {
                //MessageBox.Show(err.ToString());
                MessageBox.Show("2");
            }
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            PageReset();
        }

        private void ClassFilter()
        {
            int[,] loc = new int[10, 100];
            for (int i = 1; i <= 7; i++)
                for (int j = 1; j <= 12; j++)
                {
                    loc[i, j] = 0;
                }
            String sql = "select * from LICHCANHAN WHERE LICHCANHAN.Masinhvien = " + masv;
            var classList = new List<lophoc>();
            classList = sinhVien.GetClassList();
            sinhVien.res.Clear();
            //MessageBox.Show(classList.Count.ToString());
            //MessageBox.Show(sql);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    int lichcanhan_tietbatdau = sdr.GetInt32(1);
                    int lichcanhan_tietketthuc = sdr.GetInt32(2);
                    int lichcanhan_thu = sdr.GetInt32(3);
                    switch (lichcanhan_thu)
                    {
                        case 2:
                            for (int j = lichcanhan_tietbatdau; j <= lichcanhan_tietketthuc; j++)
                            {
                                loc[1, j] = 1;
                            }
                            break;
                        case 3:
                            for (int j = lichcanhan_tietbatdau; j <= lichcanhan_tietketthuc; j++)
                            {
                                loc[2, j] = 1;
                            }
                            break;
                        case 4:
                            for (int j = lichcanhan_tietbatdau; j <= lichcanhan_tietketthuc; j++)
                            {
                                loc[3, j] = 1;
                            }
                            break;
                        case 5:
                            for (int j = lichcanhan_tietbatdau; j <= lichcanhan_tietketthuc; j++)
                            {
                                loc[4, j] = 1;
                            }
                            break;
                        case 6:
                            for (int j = lichcanhan_tietbatdau; j <= lichcanhan_tietketthuc; j++)
                            {
                                loc[5, j] = 1;
                            }
                            break;
                        case 7:
                            for (int j = lichcanhan_tietbatdau; j <= lichcanhan_tietketthuc; j++)
                            {
                                loc[6, j] = 1;
                            }
                            break;
                        case 8:
                            for (int j = lichcanhan_tietbatdau; j <= lichcanhan_tietketthuc; j++)
                            {
                                loc[7, j] = 1;
                            }
                            break;
                    }
                }
                /*String checkLoc = "";
                for (int i = 1; i <= 7; i++)
                {
                    for (int j = 1; j <= 12; j++)
                        checkLoc += loc[i, j].ToString() + " ";
                    checkLoc += "\n";
                 }
                MessageBox.Show(checkLoc);*/

                for (int i = 0; i < classList.Count; i++)
                {
                    bool check = true;
                    switch (classList[i].ngayhoc)
                    {
                        case "Thứ 2":
                            for (int j = classList[i].tietbatdau; j <= classList[i].tietketthuc; j++)
                            {
                                if (loc[1, j] == 1)
                                {
                                    check = false;
                                }
                            }
                            break;
                        case "Thứ 3":
                            for (int j = classList[i].tietbatdau; j <= classList[i].tietketthuc; j++)
                            {
                                if (loc[2, j] == 1)
                                    check = false;
                            }
                            break;
                        case "Thứ 4":
                            for (int j = classList[i].tietbatdau; j <= classList[i].tietketthuc; j++)
                            {
                                if (loc[3, j] == 1)
                                    check = false;
                            }
                            break;
                        case "Thứ 5":
                            for (int j = classList[i].tietbatdau; j <= classList[i].tietketthuc; j++)
                            {
                                if (loc[4, j] == 1)
                                    check = false;
                            }
                            break;
                        case "Thứ 6":
                            for (int j = classList[i].tietbatdau; j <= classList[i].tietketthuc; j++)
                            {
                                if (loc[5, j] == 1)
                                    check = false;
                            }
                            break;
                        case "Thứ 7":
                            for (int j = classList[i].tietbatdau; j <= classList[i].tietketthuc; j++)
                            {
                                if (loc[6, j] == 1)
                                    check = false;
                            }
                            break;
                        case "Chủ nhật":
                            for (int j = classList[i].tietbatdau; j <= classList[i].tietketthuc; j++)
                            {
                                if (loc[7, j] == 1)
                                    check = false;
                            }
                            break;
                        default:
                            check = true;
                            break;
                    }
                    //MessageBox.Show(dem.ToString());
                    if (check)
                    {
                        sinhVien.res.Add(classList[i]);
                    }
                }
                //MessageBox.Show(sinhVien.res.Count.ToString());

                //Sap xep res
                sinhVien.res.Sort((x, y) => {
                    int check = x.ngayhoc.CompareTo(y.ngayhoc);
                    int check2 = x.tietbatdau.CompareTo(y.tietbatdau);
                    int check1 = x.tietketthuc.CompareTo(y.tietketthuc);
                    return (check != 0 ? check : check1) != 0 ? (check != 0 ? check : check1) : check2;
                });
                //Add vào datagrid
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã học phần");
                dt.Columns.Add("Tên học phần");
                dt.Columns.Add("Số tín chỉ");
                dt.Columns.Add("Tên lớp");
                dt.Columns.Add("Tiết bắt đầu");
                dt.Columns.Add("Tiết kết thúc");
                dt.Columns.Add("Ngày học");
                dt.Columns.Add("Phòng học");
                dt.Columns.Add("Mã ngành");
                DataRow dr = null;
                for (int i = 0; i < sinhVien.res.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["Mã học phần"] = sinhVien.res[i].mahocphan;
                    dr["Tên học phần"] = sinhVien.res[i].tenhocphan;
                    dr["Số tín chỉ"] = sinhVien.res[i].sotinchi.ToString();
                    dr["Tên lớp"] = sinhVien.res[i].tenlop;
                    dr["Tiết bắt đầu"] = sinhVien.res[i].tietbatdau.ToString();
                    dr["Tiết kết thúc"] = sinhVien.res[i].tietketthuc.ToString();
                    dr["Ngày học"] = sinhVien.res[i].ngayhoc;
                    dr["Phòng học"] = sinhVien.res[i].phonghoc;
                    dr["Mã ngành"] = sinhVien.res[i].manganh;
                    dt.Rows.Add(dr);

                }
                LichDaloc.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (SqlException err)
            {
                //MessageBox.Show(err.ToString());
                MessageBox.Show("3");
            }
        }
        private void FindCombos()
        {
            sinhVien.recTimComboLich();

            DataTable dt = new DataTable();
            dt.Columns.Add("Thứ 2");
            dt.Columns.Add("Thứ 3");
            dt.Columns.Add("Thứ 4");
            dt.Columns.Add("Thứ 5");
            dt.Columns.Add("Thứ 6");
            dt.Columns.Add("Thứ 7");
            dt.Columns.Add("Chủ Nhật");
            dt.Columns.Add("Tổng số tín chỉ");
            DataRow dr = null;
            //String test = "";
            for (int i = 0; i < sinhVien.multiComboLich.Count; i++)
            {
                dr = dt.NewRow();
                int sum = 0;
                for (int j = 0; j < sinhVien.multiComboLich[i].Count; j++)
                {
                    String temp = "";
                    temp += sinhVien.res[sinhVien.multiComboLich[i][j].i].tenhocphan + ": "
                            + sinhVien.res[sinhVien.multiComboLich[i][j].i].tietbatdau.ToString() + "-" +
                            sinhVien.res[sinhVien.multiComboLich[i][j].i].tietketthuc.ToString() + "\n";
                    dr[sinhVien.res[sinhVien.multiComboLich[i][j].i].ngayhoc] += temp;
                    sum += sinhVien.res[sinhVien.multiComboLich[i][j].i].sotinchi;
                    //test += temp;
                }
                dr["Tổng số tín chỉ"] =sum;
                //test += "\n\n";
                dt.Rows.Add(dr);
            }
            //MessageBox.Show(test);
            ComboLichDangKyDG.ItemsSource = dt.DefaultView;
        }

        private void ChonCombo_Click(object sender, RoutedEventArgs e)
        {
            //String result = "";
            if (ComboLichDangKyDG.SelectedIndex >= 0 && tempLichHocTap.Count > 0)
            {
                try
                {
                    String sql = "delete from Lichhoc "
                        + "  WHERE Masinhvien = '"
                        + masv + "'";
                    //result += sql + "\n";
                    //MessageBox.Show(sql);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i < tempLichHocTap.Count; i++)
                    {
                        String sql2 = "INSERT INTO Lichhoc VALUES ('"
                        + masv + "','"
                        + tempLichHocTap[i].ToString() + "')";
                        cmd = new SqlCommand(sql2, con);
                        //MessageBox.Show(sql);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        //result += sql2 + "\n";
                    }
                    con.Close();
                    sinhVien.GetLichHoc();
                    MessageBox.Show("Chọn kết quả thành công");
                    ResetLichHocTapList();
                }
                catch (SqlException err)
                {
                    //MessageBox.Show(err.ToString());
                    MessageBox.Show("4");
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn combo nào!");
        }

        private void ComboLichRowSelection(object sender, SelectionChangedEventArgs e)
        {
            //String result = "";
            if (ComboLichDangKyDG.SelectedIndex.ToString() != null)
            {
                SelectedRow = ComboLichDangKyDG.SelectedIndex;
                if (SelectedRow >= 0 && SelectedRow < sinhVien.multiComboLich.Count)
                {
                    tempLichHocTap.Clear();
                    for (int j = 0; j < sinhVien.multiComboLich[SelectedRow].Count; j++)
                    {
                        int Id = sinhVien.multiComboLich[SelectedRow][j].id;
                        tempLichHocTap.Add(Id);
                        //result += Id.ToString() + " ";
                    }
                }
            }
            //MessageBox.Show(result);
        }

        private void LuuLichHocThayDoi_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTrungLich(Items))
            {
                ItemsControl();
                sinhVien.GetLichHoc();
            }
            else
                MessageBox.Show("Lịch học không hợp lệ!");
            ResetLichHocTapList();
        }

        private void ItemsControl()
        {
            int good1 = 0;
            int good2 = 0;
            for (int i = 0; i < sinhVien.lichhoctapList.Count; i++)
            {
                int check = 0;
                for(int j=0;j<Items.Count; j++)
                {
                    if(sinhVien.lichhoctapList[i].id==Items[j].id)
                    {
                        check = 1;
                    }
                }
                if(check==0)
                {
                    good1 = 1;
                    try
                    {
                        String sql = "delete from LichHoc "
                            + "  WHERE idlophoc = '"
                            +sinhVien.lichhoctapList[i].id +"' and masinhvien='"+masv+"'";
                        //MessageBox.Show(sql);
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        good1 = 2;
                    }
                    catch (SqlException err)
                    {
                        good1 = -1;
                        //MessageBox.Show(err.ToString());
                        MessageBox.Show("5");
                    }
                }
            }

            for (int i = 0; i < Items.Count; i++)
            {
                int check = 0;
                for (int j = 0; j < sinhVien.lichhoctapList.Count; j++)
                {
                    if (sinhVien.lichhoctapList[j].id == Items[i].id)
                    {
                        check = 1;
                    }
                }
                if (check == 0)
                {
                    good2 = 1;
                    try
                    {
                        String sql = "INSERT INTO Lichhoc VALUES ('"
                            + masv + "','"
                            + Items[i].id + "')";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        good2=2;
                    }
                    catch (SqlException err)
                    {
                        good2 = -1;
                        //MessageBox.Show(err.ToString());
                        MessageBox.Show("6");
                    }
                }
            }
            if (good1>=0 && good2>=0)
                MessageBox.Show("Bạn đã thay đổi lịch thành công!");
            
        }
        private bool CheckTrungLich(ObservableCollection<TempLopType> Items)
        {
            for(int i = 0; i < Items.Count; i++)
                for(int j=0; j < Items.Count; j++)
                {
                    if(Items[i].mon == Items[j].mon && i != j)
                    {
                        return false;
                    }
                    if (Items[i].Thu == Items[j].Thu && i!=j)
                        if((Items[i].TietBatDau<=Items[j].TietKetThuc && Items[j].TietKetThuc <= Items[i].TietKetThuc)||
                            (Items[i].TietBatDau <= Items[j].TietBatDau && Items[j].TietBatDau <= Items[i].TietKetThuc)||
                            (Items[j].TietBatDau <= Items[i].TietKetThuc && Items[i].TietKetThuc <= Items[j].TietKetThuc) ||
                            (Items[j].TietBatDau <= Items[i].TietBatDau && Items[i].TietBatDau <= Items[j].TietKetThuc)
                            )
                        {
                            return false;
                        }
                }
            return true;
        }
    }
}
