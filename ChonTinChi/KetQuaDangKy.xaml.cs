using System;
using System.Collections.Generic;
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

namespace ChonTinChi
{
    /// <summary>
    /// Interaction logic for KetQuaDangKy.xaml
    /// </summary>
    public partial class KetQuaDangKy : Page
    {
        private int masv;
        private SinhVien sinhVien;
        public KetQuaDangKy()
        {
            InitializeComponent();
        }
        public KetQuaDangKy(int masv)
        {
            InitializeComponent();
            this.masv = masv;
            sinhVien = new SinhVien(masv);
            resetDG();
        }
        public void resetDG()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Thứ 2");
            dt.Columns.Add("Thứ 3");
            dt.Columns.Add("Thứ 4");
            dt.Columns.Add("Thứ 5");
            dt.Columns.Add("Thứ 6");
            dt.Columns.Add("Thứ 7");
            dt.Columns.Add("Chủ nhật");
            DataRow dr;
            dr = dt.NewRow();
            for (int j = 0; j < sinhVien.lichhoctapList.Count; j++)
            {
                String temp = "";
                temp += sinhVien.lichhoctapList[j].tenhocphan + ": "
                            + sinhVien.lichhoctapList[j].tietbatdau.ToString() + "-" +
                            sinhVien.lichhoctapList[j].tietketthuc.ToString() + "\n";
                dr[sinhVien.lichhoctapList[j].ngayhoc] += temp;
            }
            dt.Rows.Add(dr);
            KetQuaDangKyTamThoiDG.ItemsSource = dt.DefaultView;
        }
    }
}
