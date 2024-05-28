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
    /// Interaction logic for Subject.xaml
    /// </summary>
    public partial class Subject : Page
    {
        public Subject()
        {
            InitializeComponent();
            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            members.Add(new Member
            {
                MaHocPhan = "..",
                TenHocPhan = ".....ddffkfdkfdmkfdbhdskđfknfkfnfkgkgngknhgfkkgbfhddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddbhdffdhdfhdndhdfhfgudfhgdbhdhdhbdffdkfhdfdhbfdhbfhbfdhfdfhhdgdhgdhfdghfdgfdhfdhfdhfdhgfhfgdhhdfbhfdgfdhfdgfdhgfhfdghdgđsvhgsdssghdsfdsghsuhasfstyafssv",
                SoTinChi = 1
            });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });
            members.Add(new Member { MaHocPhan = "..", TenHocPhan = "...", SoTinChi = 1 });



            membersDataGrid.ItemsSource = members;

        }

        public class Member
        {
            public String MaHocPhan { get; set; }

            public String TenHocPhan { get; set; }
            public Int32 SoTinChi { get; set; }


        }

    }


}
