using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCms.Data
{
    public class QLDanhMuc
    {
        private string TenDM;
        private string ThuTu;
        private string MaDMCha;
        private string HienThi;
        private string ret;

        public string TenDM1
        {
            get
            {
                return TenDM;
            }

            set
            {
                TenDM = value;
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

        public string MaDMCha1
        {
            get
            {
                return MaDMCha;
            }

            set
            {
                MaDMCha = value;
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

        public string Ret
        {
            get
            {
                return ret;
            }

            set
            {
                ret = value;
            }
        }
        public QLDanhMuc(string ptenDM, string pthuTu, string pmaDMCha, string phienThi, string pret)
        {
            this.TenDM = ptenDM;
            this.ThuTu = pthuTu;
            this.MaDMCha = pmaDMCha;
            this.HienThi = phienThi;
            this.ret = pret;
        }
    }
}