using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLCHMT
{
    public partial class Form1 : Form
    {
        string chuoiketnoi = "Data Source=DESKTOP-162Q5GP\\SQLEXPRESS;" +
            "Initial Catalog=QLCHMT;" +
            "Integrated Security=True";
        SqlConnection conn = null;
        public Form1()
        {
            InitializeComponent();
        }
        void HienThi1()
        {
            string sql = "Select * from KhachHang";
            SqlDataAdapter daSV = new SqlDataAdapter(sql, conn);
            DataTable dtSV = new DataTable();
            daSV.Fill(dtSV);
            dataGridView1.DataSource = dtSV;
        }
        void HienThi2()
        {
            string sql = "Select * from MayTinh";
            SqlDataAdapter daSV = new SqlDataAdapter(sql, conn);
            DataTable dtSV = new DataTable();
            daSV.Fill(dtSV);
            dataGridView2.DataSource = dtSV;
        }
        void HienThi3()
        {
            string sql = "Select * from ThongKe";
            SqlDataAdapter daSV = new SqlDataAdapter(sql, conn);
            DataTable dtSV = new DataTable();
            daSV.Fill(dtSV);
            dataGridView3.DataSource = dtSV;
        }
        void showCB()
        {
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string sql_addcombox = "Select MaMT from MayTinh";
            SqlCommand cmd = new SqlCommand(sql_addcombox, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);
            }
        }
        void showKH()
        {
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string sql_addcombox = "Select MaKH from KhachHang";
            SqlCommand cmd = new SqlCommand(sql_addcombox, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox2.Items.Add(DR[0]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            HienThi1();
            HienThi2();
            HienThi3();
            showCB();
            showKH();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "Delete from KhachHang where MaKH = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            HienThi1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = "Delete from MayTinh where MaMT = '" + textBox7.Text + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            HienThi2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = "Update MayTinh set TenMT = N'" + textBox8.Text + "', " +
                "SoLuong = " + Convert.ToInt32(textBox9.Text) + 
                ", GiaBan = " + Convert.ToInt32(textBox6.Text) + 
                " where MaMT = '" + textBox7.Text + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            HienThi2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str = "Insert into MayTinh values('" + textBox7.Text + "',N'" + textBox8.Text + "','" + textBox9.Text + "',N'" + textBox6.Text + "')";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            HienThi2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Insert into KhachHang values('" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox4.Text + "',N'" + comboBox1.Text + "',N'" + textBox5.Text + "')";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            HienThi1();
        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            string str = "Update KhachHang set TenKH = N'" + textBox2.Text + "', " +
                "SDT = '" + textBox4.Text +
                "', ThanhToan = " + float.Parse(textBox5.Text) +
                " where MaKH = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(str, conn);  
            cmd.ExecuteNonQuery();
            HienThi1();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
            textBox8.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
            textBox9.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
            textBox6.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string str = "Insert into ThongKe values('" + textBox10.Text + "',N'" + dateTimePicker1.Text + "',N'" + comboBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            HienThi3();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string str = "Update ThongKe set MaKH = N'" + comboBox2.Text + "', " +"NgayBan = '" + dateTimePicker1.Value +"' where SoPhieu = N'" + textBox10.Text + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            HienThi3();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string str = "Delete from ThongKe where SoPhieu = '" + textBox10.Text + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            HienThi3();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Items.Clear();
            textBox4.Text = "";
            textBox5.Text = "";
            showCB();
            comboBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox6.Text = "";

        }
          
        private void button12_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            comboBox2.Items.Clear();
            dateTimePicker1.Text = "";
            showKH();
            comboBox2.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
