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
        SqlConnection sqlConn = new SqlConnection(@"server = TIEQIDEPAVILION\SQLEXPRESS; database = Medical_Data_Management_System; uid = Medical_Data_Management; pwd = 666666");
        
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        public DataSet Mcom = new DataSet();
        private string sql;
        string dno, pno, rno;
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
            comboxselect();
        }

        private void setGrid()
        {
            string gridsql = "SELECT Medicine.Mno AS 药品ID, Medicine.Mname AS 药品名, RXM.Mnum AS 用药数量 from RXM, Medicine where Medicine.Mno=RXM.Mno and RXM.RXno=" + rno;//查看处方药品的sql语句
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
                sql = "insert into RXM(RXno,Mno,Mnum) values('" + rno + "'," + Textno.Text + "," + Textnum.Text + ")";//添加药品名称数量...编号
                con.OperateData(sql);
                /*try
                {
                    con.OperateData(sql);
                }
                catch
                {
                    MessageBox.Show("请选接诊病人！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }*/
            }
            setGrid();
        }
        
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (state)
            {
                LoadNextPatient();
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
        private void comboxselect()
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
        }
        private void Mname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sql = "SELECT Mno FROM Medicine WHERE Mname='" + Mname.SelectedItem.ToString() + "'";//查看药物ID
            ds = con.Getds(sql);
            Textno.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        private void LoadNextPatient()
        {
            //读取挂号信息
            sql = "SELECT Patient.Pno as 病人ID ,Patient.Pname as 病人姓名, Doctor.Pnum as 剩余病人数量, Register.Rno as 处方ID, Register.Rtime_begin as 挂号时间" +
                  " from Prescription ,Patient ,Doctor,Register where Register.Dno=" + dno + " and Register.Rtime_begin=(select Min(Rtime_begin) from Register where Rstate=0 and Dno=" + dno + 
                  ") and Patient.Pno=Register.Pno and Doctor.Dno=" + dno +
                  " ";

            //ds = con.Getds(sql);

            sqlConn.Open();
            SqlCommand sqlComm = new SqlCommand(sql, sqlConn);
            SqlDataReader reader = sqlComm.ExecuteReader();

            if (!reader.Read()) 
            {
                MessageBox.Show("当前已无病人");
                state = true;
            }
            else
            {
                pno = reader["病人ID"].ToString();
                Pno.Content = pno;
                Pname.Content = reader["病人姓名"].ToString();
                Number.Content = reader["剩余病人数量"].ToString();
                rno = reader["处方ID"].ToString();
                RXno.Content = rno;
                RegisterTime.Content = reader["挂号时间"].ToString();
                sqlConn.Close();
                sql = "update Register set Rstate=1 where Register.Rno='" + rno + "'";
                con.OperateData(sql);
                setGrid();
                state = false;
            }

           
        }
        private void EndThisPatient()
        {
            string temp=DateTime.Now.ToLongTimeString().ToString();
            //结束该病人的就诊
            sql = "update Register set Rstate='2',Rtime_end='" + DateTime.Now.ToLongTimeString().ToString() +"' where Rno=" + rno + "";
            con.OperateData(sql);
            sql = "update Doctor set Pnum = Pnum - 1 where Doctor.Dno =" + dno;
            con.OperateData(sql);
        }
    }
}
