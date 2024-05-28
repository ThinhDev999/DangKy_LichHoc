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
using IronXL;
//using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace ChonTinChi
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public const string ConnectionString = "Data Source=DESKTOP-CQME86L;Initial Catalog=DANGKITINCHI;Integrated Security=True";
        public SqlConnection con = new SqlConnection(ConnectionString);
        private int msv;
        private String masvStr;
        private List<lophoc> list = new List<lophoc>();

        public class lophoc
        {
             public String mahocphan;
             public String tenhocphan;
             public String sotinchi;
             public String tenlop;
             public String tietbatdau;
             public String tietketthuc;
             public String ngayhoc;
             public String phonghoc;
             public String manganh;
             public String id;
        }
        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(int msv)
        {
            this.msv = msv;
            masvStr=msv.ToString();
            //MessageBox.Show(masvStr);
            InitializeComponent();
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile= new OpenFileDialog();
            openFile.DefaultExt = ".xlsx";

            var browseFile= openFile.ShowDialog();
            if (browseFile==true)
            {
                txtFilePath.Text = openFile.FileName;
                //WorkBook workBook=WorkBook.Load(txtFilePath.Text);
                //WorkSheet sheet = workBook.GetWorkSheet("Lophoc");
                //var cell = sheet["A1:A10"];
                //MessageBox.Show(cell.Value.ToString());
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wp = app.Workbooks.Open(txtFilePath.Text.ToString(),0,true,5,"","",true,
                        Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,"\t",false,false,0,true,1,0);
                Microsoft.Office.Interop.Excel.Worksheet excelSheet=(Microsoft.Office.Interop.Excel.Worksheet)wp.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range range= excelSheet.UsedRange;
                string strCellData = "";
                double douCellData=0;
                int rowCnt = 0;
                int colCnt = 0;

                DataTable dt = new DataTable();

                for(colCnt=1;colCnt<=range.Columns.Count;colCnt++)
                {
                    string strCol = "";
                    strCol = (string)(range.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                    dt.Columns.Add(strCol,typeof(string));
                }
               for(int i=2;i<=range.Rows.Count;i++)
                {
                    string strData = "";
                    lophoc a = new lophoc();
                    int option;
                    for (int j=1;j<=range.Columns.Count;j++)
                    {
                        try
                        {
                            strCellData = (string)(range.Cells[i,j] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += strCellData + "|";
                            option = 1;
                        }
                        catch (Exception ex)
                        {
                            douCellData = (range.Cells[i,j] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += douCellData.ToString() + "|";
                            option = 2;
                        }
                        
                        switch(j)
                        {
                            case 1:
                                if(option == 1)
                                a.mahocphan = strCellData;
                                else if(option == 2)
                                    a.mahocphan=douCellData.ToString();
                                break;
                            case 2:
                                if (option == 1)
                                    a.tenhocphan = strCellData;
                                else if (option == 2)
                                    a.tenhocphan = douCellData.ToString();
                                break;
                            case 3:
                                if (option == 1)
                                    a.sotinchi = strCellData;
                                else if (option == 2)
                                    a.sotinchi = douCellData.ToString();
                                break;
                            case 4:
                                if (option == 1)
                                    a.tenlop = strCellData;
                                else if (option == 2)
                                    a.tenlop = douCellData.ToString();
                                break;
                            case 5:
                                if (option == 1)
                                    a.tietbatdau = strCellData;
                                else if (option == 2)
                                    a.tietbatdau = douCellData.ToString();
                                break;
                            case 6:
                                if (option == 1)
                                    a.tietketthuc = strCellData;
                                else if (option == 2)
                                    a.tietketthuc = douCellData.ToString();
                                break;
                            case 7:
                                if (option == 1)
                                    a.ngayhoc = strCellData;
                                else if (option == 2)
                                    a.ngayhoc = douCellData.ToString();
                                break;
                            case 8:
                                if (option == 1)
                                    a.phonghoc = strCellData;
                                else if (option == 2)
                                    a.phonghoc = douCellData.ToString();
                                break;
                            case 9:
                                if (option == 1)
                                    a.manganh = strCellData;
                                else if (option == 2)
                                    a.manganh = douCellData.ToString();
                                break;
                            case 10:
                                if (option == 1)
                                    a.id = strCellData;
                                else if (option == 2)
                                    a.id = douCellData.ToString();
                                break;
                        }
                    }
                    strData = strData.Remove(strData.Length - 1, 1);
                    dt.Rows.Add(strData.Split('|'));
                    if(a!=null)
                        list.Add(a);
                }

                
                importedExcel.ItemsSource = dt.DefaultView;
                wp.Close(true,null,null);
                app.Quit();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            String s = "";
            try
            {
                String sql = "delete from lophoc "
                    + "  WHERE masv = '"
                    + masvStr + "'";
                //result += sql + "\n";
                //MessageBox.Show(sql);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                
                //MessageBox.Show(msv);
                //MessageBox.Show(sql2);
                for (int i = 0; i < list.Count; i++)
                {
                    String sql2 = "INSERT INTO lophoc VALUES ('"
                    + list[i].mahocphan + "',N'"
                    + list[i].tenhocphan + "','"
                    + list[i].sotinchi + "',N'"
                    + list[i].tenlop + "','"
                    + list[i].tietbatdau + "','"
                    + list[i].tietketthuc + "',N'"
                    + list[i].ngayhoc + "','"
                    + list[i].phonghoc + "','"
                    + list[i].manganh + "','"
                    + list[i].id + "','"
                    + masvStr + "')";
                    cmd = new SqlCommand(sql2, con);
                    //MessageBox.Show(sql);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    //result += sql2 + "\n";
                }
                con.Close();
                MessageBox.Show("Lưu dữ liệu thành công!");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
