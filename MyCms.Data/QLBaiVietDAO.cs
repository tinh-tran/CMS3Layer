using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyCms.Data
{
    public class QLBaiVietDAO : SqlDataProvider
    {
        #region Thêm bài viết mới
        /// <summary>
        /// Thêm bài viết mới
        /// </summary>
        public bool BaiViet_Insert(QLBaiViet BaiViet)
        {
            SqlCommand cmd = new SqlCommand("sp_BaiViet_Insert", GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenBaiViet", BaiViet.TenBaiViet1);
            cmd.Parameters.AddWithValue("@NoiDung", BaiViet.NoiDung1);
            cmd.Parameters.AddWithValue("@TieuDe", BaiViet.TieuDe1);
            cmd.Parameters.AddWithValue("@Anh", BaiViet.Anh1);
            cmd.Parameters.AddWithValue("@ThuTu", BaiViet.ThuTu1);
            cmd.Parameters.AddWithValue("@HienThi", BaiViet.HienThi1);
            cmd.Parameters.AddWithValue("@MaDM", BaiViet.MaDM1);
            cmd.ExecuteNonQuery();
            return true;
        }
        #endregion

        #region Sửa bài viết
        /// <summary>
        /// Sửa bài viết
        /// </summary>
        public bool BaiViet_Update(QLBaiViet BaiViet, string MaBaiViet)
        {
            SqlCommand cmd = new SqlCommand("sp_BaiViet_Update", GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaBaiViet", MaBaiViet);
            cmd.Parameters.AddWithValue("@TenBaiViet", BaiViet.TenBaiViet1);
            cmd.Parameters.AddWithValue("@NoiDung", BaiViet.NoiDung1);
            cmd.Parameters.AddWithValue("@TieuDe", BaiViet.TieuDe1);
            cmd.Parameters.AddWithValue("@Anh", BaiViet.Anh1);
            cmd.Parameters.AddWithValue("@ThuTu", BaiViet.ThuTu1);
            cmd.Parameters.AddWithValue("@HienThi", BaiViet.HienThi1);
            cmd.Parameters.AddWithValue("@MaDM", BaiViet.MaDM1);
            cmd.ExecuteNonQuery();
            return true;
        }
        #endregion
        #region Xóa bài viết
        /// <summary>
        /// Xóa bài viết
        /// </summary>
        public void BaiViet_Delete(string MaBaiViet)
        {
            SqlCommand cmd = new SqlCommand("sp_BaiViet_Delete", GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaBaiViet", MaBaiViet);
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region Lấy ra danh sách tất cả bài viết
        /// <summary>
        /// Lấy ra danh sách tất cả bài viết
        /// </summary>
        /// <returns></returns>
        public DataTable ThongtinBV()
        {
            SqlCommand cmd = new SqlCommand("sp_ThongtinBaiViet");
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlDataProvider.GetData(cmd);
        }
        #endregion

        #region Lấy ra thông tin Bài viết theo mã
        /// <summary>
        /// Lấy ra thông tin Bài viết theo mã
        /// </summary>
        /// <returns></returns>
        public DataTable ThongtinBVMaBV(string MaBV)
        {
            SqlCommand cmd = new SqlCommand("sp_ThongTinBaiViet_MaBV");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaBaiViet", MaBV);
            return SqlDataProvider.GetData(cmd);
        }
        #endregion
    }
}