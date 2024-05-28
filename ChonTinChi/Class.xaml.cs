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

namespace ChonTinChi
{
    /// <summary>
    /// Interaction logic for Class.xaml
    /// </summary>
    public partial class Class : Page
    {
        public Class()
        {
            InitializeComponent();


            InitializeComponent();
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            members.Add(new Member
            {
                MaHocPhan = "..",
                TenHocPhan = "........................................shgsdd",
                SoTinChi = 1,
                TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx",
                TietBatDau = 1,
                TietKetThuc = 2,
                NgayHoc = "03/45/32",
                PhongHoc = "abc-846",
                MaNganh = "it"
            });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1, TenLop = "chunghiaxxxxxxxxxxxxxxxxxxxxxxxxx", TietBatDau = 1, TietKetThuc = 2, NgayHoc = "03/45/32", PhongHoc = "abc-846", MaNganh = "it" });





            membersDataGrid.ItemsSource = members;
        }


        public class Member
        {
            public String MaHocPhan { get; set; }

            public String TenHocPhan { get; set; }
            public Int32 SoTinChi { get; set; }
            public String TenLop { get; set; }

            public Int32 TietBatDau
            { get; set; }
            public Int32 TietKetThuc
            { get; set; }
            public String NgayHoc
            { get; set; }
            public String PhongHoc
            { get; set; }
            public String MaNganh

            { get; set; }





        }
    }


}
