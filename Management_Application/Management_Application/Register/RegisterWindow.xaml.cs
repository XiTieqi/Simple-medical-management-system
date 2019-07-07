
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;


namespace Management_Application.Register
{
    /// <summary>
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        DataTable dept = new DataTable();
        DataTable doct = new DataTable();
        private string sql, Deptno;
        string pno;
        PatientWindow PaW;

        public RegisterWindow(string no,PatientWindow _PaW)
        {
            InitializeComponent();
            pno = no;
            PaW = _PaW;
            SetRegisterGrid();
            sql = "select Deptno as 科室编号,Deptname as 科室名称,Dnum as 医生数量 from Dept";
            ds = con.Getds(sql);
            dept = ds.Tables[0];
            DeptGrid.ItemsSource = dept.DefaultView;

        }
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            PaW.Visibility = Visibility.Visible;
            this.Close();
        }

        private void SetRegisterGrid()
        {
            sql = "select Rno as 挂号单 from Register where Pno =" + pno + " and Rstate = 0";//查询已知病人ID时的挂号单
            con.BindDataGrid(RegisterGrid, sql);
        }

        private void DGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)//选择医生挂号
        {
            sql = "";//挂号
            con.OperateData(sql);
            SetRegisterGrid();
        }

        private void ChooseDept(object sender, MouseButtonEventArgs e)
        {
            if (DeptGrid.SelectedIndex != -1)
            {
                Deptno = DeptGrid.SelectedItems[1].ToString();
                sql = "select Dno as 编号, Dname as 医生姓名,  Dsex as 性别, Dprot as 职称 from Doctor where Doctor.Deptno = " + Deptno;
                doct = con.Getds(sql).Tables[0];
                DGrid.ItemsSource = doct.DefaultView;
            }
        }
    }
}
