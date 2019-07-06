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
using System.Data.SqlClient;
using System.Data;

namespace Management_Application.Dotctor
{
    /// <summary>
    /// DoctorMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DoctorMainWindow : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        string dno, pno, RXno, RXdate, RXtime;
        bool state = true;
        public DoctorMainWindow(string _Dno)
        {
            InitializeComponent();
            dno = _Dno;
            Dno.Content = dno;
        }
        private void setGrid()
        {
            string gridsql = "";//查看处方药品的sql语句
            con.BindDataGrid(RXM, gridsql);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Mname.SelectedItem == null) 
            {
                MessageBox.Show("请选择药物", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                sql = "";//添加药品名称数量...
                con.OperateData(sql);
            }
            setGrid();
        }
      
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (state)
            {
                LoadNextPatient();
                state = false;
            }
            else
            {
                EndThisPatient();
                LoadNextPatient();
            }
        }
        private void LoadNextPatient()
        {
            sql = "SELECT * FROM Register WHERE Dno="+dno+"AND ";//加载下一个病人
            ds = con.Getds(sql);
            //显示操作
        }
        private void EndThisPatient()
        {
            sql = "";//结束该病人的就诊
            ds = con.Getds(sql);
        }
    }
}
