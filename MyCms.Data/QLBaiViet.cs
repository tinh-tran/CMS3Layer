using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCms.Data
{
    public class QLBaiViet
    {
        private string TenBaiViet;
        private string NoiDung;
        private string TieuDe;
        private string Anh;
        private string ThuTu;
        private string HienThi;
        private string MaDM;

       
        public string TenBaiViet1
        {
            get
            {
                return TenBaiViet;
            }

            set
            {
                TenBaiViet = value;
            }
        }

        public string NoiDung1
        {
            get
            {
                return NoiDung;
            }

            set
            {
                NoiDung = value;
            }
        }

        public string TieuDe1
        {
            get
            {
                return TieuDe;
            }

            set
            {
                TieuDe = value;
            }
        }

        public string Anh1
        {
            get
            {
                return Anh;
            }

            set
            {
                Anh = value;
            }
        }

        public string ThuTu1
        {
            get
            {
                return ThuTu;
            }

            set
            {
                ThuTu = value;
            }
        }

        public string HienThi1
        {
            get
            {
                return HienThi;
            }

            set
            {
                HienThi = value;
            }
        }

        public string MaDM1
        {
            get
            {
                return MaDM;
            }

            set
            {
                MaDM = value;
            }
        }
        public QLBaiViet(string pTenBaiViet, string pNoiDung, string pTieuDe, string pAnh, string pThuTu, string pHienThi, string pMaDM)
        {
            this.TenBaiViet = pTenBaiViet;
            this.NoiDung = pNoiDung;
            this.TieuDe = pTieuDe;
            this.Anh = pAnh;
            this.ThuTu = pThuTu;
            this.HienThi = pHienThi;
            this.MaDM = pMaDM;
        }

    }

}