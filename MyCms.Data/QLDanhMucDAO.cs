using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace MyCms.Data
{
    public class QLDanhMucDAO : SqlDataProvider
    {

        #region Lấy ra danh sách tất cả danh mục
        /// <summary>
        /// Lấy ra danh sách tất cả danh mục
        /// </summary>
        /// <returns></returns>
        public DataTable ThongtinDM()
        {
            SqlCommand cmd = new SqlCommand("sp_ThongtinDM");
            cmd.CommandType = CommandType.StoredProcedure;
            return SqlDataProvider.GetData(cmd);
        }
        #endregion

        #region Lấy ra thông tin danh mục theo id danh mục cha
        /// <summary>
        /// Lấy ra thông tin danh mục theo id danh mục cha
        /// <para name="MaDMCha">Mã danh mục cha cần lấy thông tin</para>
        /// </summary>
        /// <returns></returns>
        public DataTable ThongtinDMCha(string MaDMCha)
        {
            SqlCommand cmd = new SqlCommand("sp_ThongtinDMCha");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDMCha", MaDMCha);
            return SqlDataProvider.GetData(cmd);
        }
        #endregion

        #region Lấy ra thông tin danh mục theo id danh mục
        /// <summary>
        /// Lấy ra thông tin danh mục theo id danh mục
        /// <para name="MaDMCha">Mã danh mục cần lấy thông tin</para>
        /// </summary>
        /// <returns></returns>
        public DataTable ThongtinDMMaDM(string MaDM)
        {
            SqlCommand cmd = new SqlCommand("sp_ThongtinDMMaDM");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDM", MaDM);
            return SqlDataProvider.GetData(cmd);
        }
        #endregion

        #region Thêm danh mục mới
        /// <summary>
        /// Thêm danh mục mới
        /// </summary>
        public bool DanhMuc_Insert(QLDanhMuc DanhMuc)
        {
            SqlCommand cmd = new SqlCommand("sp_DanhMuc_insert",GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDM", DanhMuc.TenDM1);
            cmd.Parameters.AddWithValue("@ThuTu", DanhMuc.ThuTu1);
            cmd.Parameters.AddWithValue("@MaDMCha", DanhMuc.MaDMCha1);
            cmd.Parameters.AddWithValue("@HienThi", DanhMuc.HienThi1);
            cmd.Parameters.AddWithValue("@ret", DanhMuc.Ret);
            cmd.ExecuteNonQuery();
            return true;
        }
        #endregion

        #region Sửa danh mục
        /// <summary>
        /// Sửa danh mục mới
        /// </summary>
        public bool DanhMuc_Update(string madm, string tendm, string thutu, string madmcha, string hienthi)
        {
            SqlCommand cmd = new SqlCommand("sp_DanhMuc_Update", GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDM", madm);
            cmd.Parameters.AddWithValue("@TenDM", tendm);
            cmd.Parameters.AddWithValue("@ThuTu", thutu);
            cmd.Parameters.AddWithValue("@MaDMCha", madmcha);
            cmd.Parameters.AddWithValue("@HienThi", hienthi);
            cmd.ExecuteNonQuery();
            return true;
        }
        #endregion

        #region Xóa danh mục
        /// <summary>
        /// Xóa danh mục
        /// </summary>
        public void DanhMuc_Delete(string MaDM)
        {
            SqlCommand cmd = new SqlCommand("sp_DanhMuc_Delete", GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDM", MaDM);
            cmd.ExecuteNonQuery();
        }
        #endregion
    }
}