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
using System.Text.RegularExpressions;

namespace Management_Application.Dotctor
{
    /// <summary>
    /// DoctorMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DoctorMainWindow : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        public DataSet Mcom = new DataSet();
        private string sql;
        string dno, pno, rxno;
        bool state = true;
        public DoctorMainWindow(string _Dno)
        {
            InitializeComponent();
            dno = _Dno;
            Dno.Content = dno;
            sql = "SELECT Mname FROM Medicine";//查询药品名称...
            ds = con.Getds(sql);
            Mcom = ds;
            Mname.ItemsSource = Mcom.Tables[0].Columns;
        }

        private void setGrid()
        {
            string gridsql = "SELECT Mdecine.Mno Mdicine.Mname RXM.Mnum from RXM Mdicine where Mdicine.Mno=RXM.Mno and RXM.RXno=" + rxno;//查看处方药品的sql语句
            con.BindDataGrid(RXM, gridsql);
        }

        //添加药物
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Mname.SelectedItem == null)
            {
                MessageBox.Show("请选择药物", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Regex.IsMatch(Textnum.Text, @"^[+-]?/d*[.]?/d*$")) 
            {
                MessageBox.Show("请输入正确的药物数量！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                sql = "insert into RXM(RXno,Mno,Mnum) values(" + rxno + "," + Textno.Text + "," + Textnum.Text + ")";//添加药品名称数量...编号
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
        private void Mname_KeyUp(object sender, KeyEventArgs e)
        {
            string s;
            List<string> ListAll = new List<string>();
            List<string> ListSelect = new List<string>();
            for (int i = 0; i < Mcom.Tables[0].Rows.Count; i++)
            {
                s = Mcom.Tables[0].Rows[i][0].ToString();
                ListAll.Add(s);
            }
            ListSelect.Clear();
            foreach (var item in ListAll)
            {
                if (item.Contains(Mname.Text.Trim()))
                {
                    ListSelect.Add(item);
                }
            }
            Mname.ItemsSource = ListSelect;
            Mname.IsDropDownOpen = true;
        }

        private void Mname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sql = "";//查看药物ID
            ds = con.Getds(sql);
            Textno.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        private void LoadNextPatient()
        {
            //读取挂号信息
            sql = "SELECT Prescription.Pno as 病人ID ,Patient.Pname as 病人姓名, Doctor.Pnum as 剩余病人数量, Prescription.RXno as 处方ID, Register.Rtime_begin as 挂号时间"+
                  "from Presciption Patient Doctor Register " +
                  "where Register.Dno=" + dno + "and Register.Rtime_begin=（selsect Min（Rtime_begin） from Register where Rstate=0 and Dno=+" + dno + "）" +
                  " and Patient.Pno=Register.Pno Docotor.Dno=" + dno +
                  "and Prescription.Dno=" + dno + " and Prescription.Pno=Register.Pno";
            ds = con.Getds(sql);
            //设置属性表
            pno = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            Pno.Content = pno;
            Pname.Content = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            Number.Content = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            rxno = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            RXno.Content = rxno;
            RegisterTime.Content = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            //更改就诊状态
            sql = "update Register" +
                "set Rstate=1  " +
                "where Register.Dno=" + dno + " and Register.Pno=" + pno;
            con.OperateData(sql);
            setGrid();
        }
        private void EndThisPatient()
        {
            //结束该病人的就诊
            sql = "update Register" +
                "set Rstate=2  Rtime_end=" + DateTime.Now.ToLongTimeString().ToString() +
            "where Register.Dno=" + dno + " and Register.Pno=" + pno;
            con.OperateData(sql);
            sql = "update Doctor set Pnum = Pnum - 1 where Doctor.Dno =" + dno;
            con.OperateData(sql);
        }
    }
}
