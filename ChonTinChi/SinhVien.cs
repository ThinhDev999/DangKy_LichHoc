using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using static ChonTinChi.FromSinhVien;
using static ChonTinChi.SinhVien;
using static ChonTinChi.Student;
using static System.Net.Mime.MediaTypeNames;

namespace ChonTinChi
{
    internal class SinhVien
    {
        //DEFINE
        //public const string ConnectionString = "Data Source=DESKTOP-BV9FQL0\\SQLEXPRESS;Initial Catalog=DANGKITINCHI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public const string ConnectionString = "Data Source=DESKTOP-CQME86L;Initial Catalog=DANGKITINCHI;Integrated Security=True";
        public SqlConnection con = new SqlConnection(ConnectionString);
        public int masv;
        public List<lophoc> res = new List<lophoc>();
        public List<lichcanhan> lichcanhanList = new List<lichcanhan>();
        public List<lophoc> lichhoctapList = new List<lophoc>();
        public List<List<probType>> multiComboLich = new List<List<probType>>();
        public List<List<probType>> tempMultiComboLich = new List<List<probType>>();
        public List<probType> ConvertedRes = new List<probType>();
        public sinhvien curSinhVien;
        //private DangKyHoc dangKyHoc;
        public class lophoc
        {
            public String mahocphan;
            public String tenhocphan;
            public int sotinchi;
            public String tenlop;
            public int tietbatdau;
            public int tietketthuc;
            public String ngayhoc;
            public String phonghoc;
            public String manganh;
            public int id;
        }
        public class lichcanhan
        {
            public String congviec;
            public int tietbatdau;
            public int tietketthuc;
            public int thu;
        }
        public class probType
        {
            public String value;
            public int bd;
            public int kt;
            public int i;
            public int sotinchi;
            public int check;
            public int id;
        }
        public struct preaf
        {
            public int pre;
            public int af;
        };
        public class sinhvien
        {
            public int msv;
            public string name;
            public string khoahoc;
            public string manganh;
        }

 
        public SinhVien(int maSV)
        {
            masv = maSV;
            curSinhVien = new sinhvien();
            curSinhVien.msv = maSV;
            GetSinhVien();
            GetLichHoc();
            DanhSachLichCaNhan();
            //dangKyHoc = new DangKyHoc(masv);
        }
        /**/
        public void GetSinhVien()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from sinhvien where masinhvien='" + masv
                    + "'", con);
                con.Open();
                var sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    curSinhVien.manganh = sdr.GetString(5);
                    curSinhVien.khoahoc = sdr.GetString(4);
                    curSinhVien.name=sdr.GetString(3);
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetLichHoc()
        {
            lichhoctapList.Clear();
            try
            {
                String sql = "SELECT * from lophoc LEFT JOIN lichhoc ON Masinhvien = '" + masv + "' WHERE lophoc.Idlophoc=lichhoc.Idlophoc";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    lophoc a = new lophoc();
                    a.mahocphan = sdr.GetString(0);
                    a.tenhocphan = sdr.GetString(1);
                    a.sotinchi = sdr.GetInt32(2);
                    a.tenlop = sdr.GetString(3);
                    a.tietbatdau = sdr.GetInt32(4);
                    a.tietketthuc = sdr.GetInt32(5);
                    a.ngayhoc = sdr.GetString(6);
                    a.phonghoc = sdr.GetString(7);
                    a.manganh = sdr.GetString(8);
                    a.id = sdr.GetInt32(9);
                    lichhoctapList.Add(a);
                }
                con.Close();
                /*String test = "";
                for (int i = 0; i < lichhoctapList.Count; i++)
                {
                    test += lichhoctapList[i].tenlop + "\n";
                }
                MessageBox.Show(test);*/
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
                //MessageBox.Show("11");
            }
        }
        public void DanhSachLichCaNhan()
        {
            try
            {
                lichcanhanList.Clear();
                String sql = " select * from LICHCANHAN where LICHCANHAN.Masinhvien =" + masv;
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    String tg = "";
                    tg += "Thứ "+sdr.GetInt32(3).ToString() + "  Thời gian (Tiết):" + sdr.GetInt32(1).ToString() + "-" + sdr.GetInt32(2).ToString();
                    lichcanhan a = new lichcanhan();
                    a.congviec = sdr.GetString(4);
                    a.tietbatdau = sdr.GetInt32(1);
                    a.tietketthuc = sdr.GetInt32(2);
                    a.thu = sdr.GetInt32(3);
                    lichcanhanList.Add(a);
                }
                con.Close();
            }
            catch (SqlException err)
            {
                //MessageBox.Show(err.ToString());
                MessageBox.Show("12");
            }
        }

        public List<lophoc> GetClassList()
        {
            var classList = new List<lophoc>();
            try
            {
                con.Open();
                String sql = "select * from lophoc where manganh ='" + curSinhVien.manganh + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    lophoc a = new lophoc();
                    a.mahocphan = sdr.GetString(0);
                    a.tenhocphan = sdr.GetString(1);
                    a.sotinchi = sdr.GetInt32(2);
                    a.tenlop = sdr.GetString(3);
                    a.tietbatdau = sdr.GetInt32(4);
                    a.tietketthuc = sdr.GetInt32(5);
                    a.ngayhoc = sdr.GetString(6);
                    a.phonghoc = sdr.GetString(7);
                    a.manganh = sdr.GetString(8);
                    a.id = sdr.GetInt32(9);
                    classList.Add(a);
                }
                con.Close();
                return classList;
            }
            catch (SqlException err)
            {
                //MessageBox.Show(err.ToString());
                MessageBox.Show("13");
                return null;
            }
            // HocPhan_ComboBox.Items.Clear();
        }

        public bool CheckTrungLich(List<probType> q)
        {
            q.Sort();
            bool check = true;
            for (int i = 1; i < q.Count(); i++)
            {
                if (res[q[i].i].tietbatdau < res[q[i - 1].i].tietketthuc)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
        public void recTimComboLich()
        {
            ConvertedRes.Clear();
            preaf[] preAf=new preaf[1000];
            int[] check = new int[1000];
            int n = res.Count;
            int dem = 1;
            //Khoi tao
            for (int i = 0; i <n; i++)
            {
                probType a=new probType();
                a.value = res[i].mahocphan;
                a.bd = ConvertToTime(res[i].ngayhoc,res[i].tietbatdau);
                a.kt = ConvertToTime(res[i].ngayhoc, res[i].tietketthuc);
                a.i = i;
                a.sotinchi = res[i].sotinchi;
                a.check = 0;
                a.id = res[i].id;
                ConvertedRes.Add(a);
                preAf[i].pre = -1;
                preAf[i].af = -1;
            }
            for (int i = 1; i <= 100; i++)
            {
                check[i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                if (ConvertedRes[i].check == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (ConvertedRes[j].value == ConvertedRes[i].value)
                        {
                            ConvertedRes[j].check = dem;
                        }
                    }
                    dem++;
                }
            }
            //Tim lop khong trung gan nhat o truoc va sau
            for (int i=0;i<n;i++)
            {
                for(int j = i - 1; j >= -1; j--)
                {
                    if (j == -1)
                        preAf[i].pre = -1;
                    else
                    {
                        if (ConvertedRes[i].bd>ConvertedRes[j].kt)
                        {
                            preAf[i].pre=j;
                            break;
                        }
                    }
                }
                for(int j=i+1;j<=n;j++)
                {
                    if (j == n)
                        preAf[i].af = -1;
                    else
                    {
                        if (ConvertedRes[i].kt < ConvertedRes[j].bd)
                        {
                            preAf[i].af = j;
                            break;
                        }
                    }
                }
            }
            int[] data;
            int start = 6;
            while (true)
            {
                for (int i = 1; i <= 100; i++)
                {
                    check[i] = 0;
                }
                data = new int[1000];
                //MessageBox.Show(multiComboLich.Count.ToString());
                Combination(ConvertedRes, preAf, n, start, 0, data, check, 0);
                //MessageBox.Show(multiComboLich.Count.ToString());
                if (tempMultiComboLich.Count == 0)
                    break;
                else
                    if (tempMultiComboLich.Count > 0)
                {
                    multiComboLich.Clear();
                    for (int k = 0; k < tempMultiComboLich.Count; k++)
                    {
                            multiComboLich.Add(tempMultiComboLich[k]);
                        //if(tempMultiComboLich[k].Count==9)
                            //MessageBox.Show(tempMultiComboLich[k].Count.ToString());
                    }
                    //MessageBox.Show(multiComboLich.Count.ToString());
                    tempMultiComboLich.Clear();
                    start++;
                }
            }

            /*String test = "";
            for(int i=0;i<ConvertedRes.Count;i++)
            {
                test +=ConvertedRes[i].value+" "
                +ConvertedRes[i].bd.ToString() + " "
                +ConvertedRes[i].kt.ToString()+" "
                +ConvertedRes[i].i.ToString()+" "
                +ConvertedRes[i].check.ToString()+"\n";
            }
            test += multiComboLich.Count.ToString()+"\n";
            for (int i = 0; i < multiComboLich.Count; i++)
            {
                for (int j = 0; j < multiComboLich[i].Count; j++)
                {
                    test += multiComboLich[i][j].value + " ";
                }
                test += "\n";
            }
            MessageBox.Show(test);*/
        }
        
        public void Combination(List<probType> a, preaf[] b, int n, int r,
                    int index, int[] data, int[] check, int i)
        {
            if (index == r)
            {
                List<probType> temp=new List<probType>();
                int sum = 0;
                for(int k=0; k<r;k++)
                {
                    temp.Add(ConvertedRes[data[k]]);
                    sum += temp[k].sotinchi;
                }
                if(sum >= 12 && sum<=24)
                    tempMultiComboLich.Add(temp);
                return;
            }
            if (i >= n || i == -1)
                return;
            data[index] = i;
            check[a[i].check]++;
            int ite = b[i].af;
            if(0<=ite&& ite<n)
                while (check[a[ite].check] > 0)
                {
                    ite++;
                    if (0 >= ite || ite >= n)
                       break;
                }
            Combination(a,b, n, r, index + 1, data, check, ite);
            check[a[i].check] = 0;
            Combination(a,b, n, r, index, data, check, ite);
        }
        /*
        public void Combination(List<probType> a, preaf[] b, int n, int r,
                    int index, int[] data, int[] check, int i)
        {
            if (index == r)
            {
                List<probType> temp = new List<probType>();
                int sum = 0;
                for (int k = 0; k < r; k++)
                {
                    temp.Add(ConvertedRes[data[k]]);
                    sum += temp[k].sotinchi;
                }
                if (sum >= 12 && sum <= 24)
                    tempMultiComboLich.Add(temp);
                return;
            }
            if (i >= n || i == -1)
                return;
            int ite1 = i + 1;
           
            while (check[a[ite1].check] > 0)
            {
                ite1++;
                if (0 >= ite1 || ite1 >= n)
                    break;
            }
            Combination(a, b, n, r, index, data, check, ite1);
            data[index] = i;
            check[a[i].check]++;
            int ite2 = b[i].af;
            while(check[a[ite2].check] > 0)
            {
                 ite2++;
                 if (0 >= ite2 || ite2 >= n)
                    break;
            }
            Combination(a, b, n, r, index + 1, data, check, ite2);
            check[a[i].check] = 0;
        }
        */
        public int ConvertToTime(String thu, int time)
        {
            int resu;
            resu = 0;
            switch (thu)
            {
                case "Thứ 2":
                    resu = time;
                    break;
                case "Thứ 3":
                    resu = 12 + time;
                    break;
                case "Thứ 4":
                    resu = 24 + time;
                    break;
                case "Thứ 5":   
                    resu = 36 + time;
                    break;
                case "Thứ 6":
                    resu = 48 + time;
                    break;
                case "Thứ 7":
                    resu = 60 + time;
                    break;
                case "Chủ nhật":
                    resu = 72 + time;
                    break;
            }
            return resu;
        }
    }
}
