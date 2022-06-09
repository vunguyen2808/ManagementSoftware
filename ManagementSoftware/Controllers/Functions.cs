using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.Controllers
{
    public class Functions
    {
        //Phương thức lấy dữ liệu từ câu lệnh SQL
        public static void FillCombo(string sql, ComboBox cbo, string ten, string ma)
        {
            Database dt = new Database();
            SqlConnection con = new SqlConnection(dt.stringConnect);
            con.Open();
            cbo.DataSource = Database.Singleton.LoadData(sql);           
            cbo.DisplayMember = ten; //Trường hiển thị
            cbo.ValueMember = ma; //Trường giá trị
            con.Close();
        }

        //Có tác dụng thực hiện câu lệnh truy vấn SQL
        public static DataTable GetDataToTable(string sql)
        {
            Database dt = new Database();
            SqlConnection con = new SqlConnection(dt.stringConnect);
            con.Open();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            con.Close();
            return table;          
        }

        //Phương thức lấy dữ liệu từ câu lệnh SQL
        public static string GetFieldValues(string sql)
        {           
            string ma = "";
            Database dt = new Database();
            SqlConnection con = new SqlConnection(dt.stringConnect);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            con.Close();
            return ma;           
        }

        //Có tác dụng thực hiện câu lệnh truy vấn SQL
        public static void RunSQL(string sql)
        {
            Database dt = new Database();                      
            SqlConnection con = new SqlConnection(dt.stringConnect);            
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            con.Close();
        }

        //Hàm kiểm tra khoá trùng
        public static bool CheckKey(string sql)
        {
            Database dt = new Database();
            SqlConnection con = new SqlConnection(dt.stringConnect);
            con.Open();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }     
        }

        //Hàm chuyển từ kiểu int sang string
        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            sNumber = sNumber.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1;
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i)
                    switch ((mLen - i) % 9)
                    {
                        case 6:
                            mTemp = mTemp + " triệu";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        case 3:
                            mTemp = mTemp + " nghìn";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        default:
                            switch ((mLen - i) % 3)
                            {
                                case 2:
                                    mTemp = mTemp + " trăm";
                                    break;
                                case 1:
                                    mTemp = mTemp + " mươi";
                                    break;
                            }
                            break;
                    }
            }
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", ""); 
            mTemp = mTemp.Replace("không mươi ", "linh ");
            mTemp = mTemp.Replace("mươi không", "mươi");
            mTemp = mTemp.Replace("một mươi", "mười");
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            mTemp = mTemp.Trim();
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " (VNĐ)";
            return mTemp;
        }

        //Hàm tạo khóa có dạng: AAANgaythangnam_giophutgiay
        public static string CreateKey(string a)
        {
            string key = a;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }

        //Chuyển đổi từ PM sang dạng 24h
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        public static int ConvertDay(int day)
        {
            if (day > 31)
            {
                int d = 0;
                switch (day)
                {
                    case 32:
                        d = 1;
                        break;
                    case 33:
                        d = 2;
                        break;
                    case 34:
                        d = 3;
                        break;
                    case 35:
                        d = 4;
                        break;
                    case 36:
                        d = 5;
                        break;
                    case 37:
                        d = 6;
                        break;
                    case 38:
                        d = 7;
                        break;
                }
                return d;
            }
            return day;
        }
    }
}
