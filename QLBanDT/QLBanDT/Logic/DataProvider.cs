using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanDT.Logic
{
    public class DataProvider
    {
        private static DataProvider instance;
        private string connectionSTR = @"Data Source=LAPTOP-Q68M8JRM\SQLEXPRESS;Initial Catalog=DATA_DT;Integrated Security=True";

        public static DataProvider Instance {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        // ExecuteQuery Trả ra những dòng kết quả là 1 dataBase
        public DataTable ExecuteQuery(string query, object[] parameter = null) // cái này có thể null, chỉ dược phép đưa váo các Parameter ở cuối cùng, là 1 danh sách những thg bị null liên tiếp nhau
        {
            // cách linh hoạt:"đổ ra dataTable"
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR)) // khi chạy hết sẽ được giải phóng
            {
                /*SqlConnection connection = new SqlConnection(connectionSTR);*/  // kết nói từ client xuống sever

                // Mở connection(dữ liêu) ra mới sài được
                connection.Open();

                // Thực thi "query" trên "connection"
                SqlCommand command = new SqlCommand(query, connection); // câu truy vấn thực thi

                //command.Parameters.Add("@userName", id); // dữ liệu đưa vào là id

                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); //tách theo khoảng trắng, có thể bị vướng dấu ","
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@")) // tìm thấy parameter == @, tức là tìm câu truy vấn có dấu @
                                                // contains kiểm tra chuổi này có nằm trong chuỗi khách không
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }

                //Trung gian thực hiện câu truy vấn lấy dữ liệu ra 
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                //đóng connection lại, tránh tính trạng dữ liệu cùng đổ về 1 lần
                connection.Close();
            }

            return data;
        }

        // ExecuteNoneQuery trả về int, dùng cho insert, delete, update
        public int ExecuteNoneQuery(string query, object[] parameter = null) // cái Parameter có thể null, chỉ dược phép đưa váo các Parameter ở cuối cùng, là 1 danh sách những thg bị null liên tiếp nhau
        {
            int data = 0; // bien trang thai kiem tra thanh cong hay that bai

            using (SqlConnection connection = new SqlConnection(connectionSTR)) // khi chạy hết sẽ được giải phóng
            {
                /*SqlConnection connection = new SqlConnection(connectionSTR);*/  // kết nói từ client xuống sever

                // Mở connection(dữ liêu) ra mới sài được
                connection.Open();

                // Thực thi "query" trên "connection"
                SqlCommand command = new SqlCommand(query, connection); // câu truy vấn thực thi

                //command.Parameters.Add("@userName", id); // dữ liệu đưa vào là id

                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); //tách theo khoảng trắng, có thể bị vướng dấu ","
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@")) // tìm thấy parameter == @, tức là tìm câu truy vấn có dấu @
                                                // contains kiểm tra chuổi này có nằm trong chuỗi khách không
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }

                data = command.ExecuteNonQuery();

                //đóng connection lại, tránh tính trạng dữ liệu cùng đổ về 1 lần
                connection.Close();
            }

            return data;
        }

        // ExecuteScalar trả về object, dùng cho muốn truy cứu dòng riêng lẻ hoặc dòng đầu tiên
        public object ExecuteScalar(string query, object[] parameter = null) // cái Parameter có thể null, chỉ dược phép đưa váo các Parameter ở cuối cùng, là 1 danh sách những thg bị null liên tiếp nhau
        {
            object data = 0; // bien trang thai kiem tra thanh cong hay that bai

            using (SqlConnection connection = new SqlConnection(connectionSTR)) // khi chạy hết sẽ được giải phóng
            {
                /*SqlConnection connection = new SqlConnection(connectionSTR);*/  // kết nói từ client xuống sever

                // Mở connection(dữ liêu) ra mới sài được
                connection.Open();

                // Thực thi "query" trên "connection"
                SqlCommand command = new SqlCommand(query, connection); // câu truy vấn thực thi

                //command.Parameters.Add("@userName", id); // dữ liệu đưa vào là id

                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); //tách theo khoảng trắng, có thể bị vướng dấu ","
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@")) // tìm thấy parameter == @, tức là tìm câu truy vấn có dấu @
                                                // contains kiểm tra chuổi này có nằm trong chuỗi khách không
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }

                data = command.ExecuteScalar();

                //đóng connection lại, tránh tính trạng dữ liệu cùng đổ về 1 lần
                connection.Close();
            }

            return data;
        }
    }
}
