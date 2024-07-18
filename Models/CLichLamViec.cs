using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CLichLamViec
    {
        private int lichLamViecID;
        private CNhanVien nhanVienID;
        private DateTime ngayLam;
        private string caLam;

        public CLichLamViec()
        {
        }

        public CLichLamViec(int lichLamViecID, CNhanVien nhanVienID, DateTime ngayLam, string caLam)
        {
            this.lichLamViecID = lichLamViecID;
            this.nhanVienID = nhanVienID;
            this.ngayLam = ngayLam;
            this.caLam = caLam;
        }

        public int LichLamViecID { get => lichLamViecID; set => lichLamViecID = value; }
        public CNhanVien NhanVienID { get => nhanVienID; set => nhanVienID = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
        public string CaLam { get => caLam; set => caLam = value; }

        public override bool Equals(object obj)
        {
            return obj is CLichLamViec viec &&
                   lichLamViecID == viec.lichLamViecID &&
                   EqualityComparer<CNhanVien>.Default.Equals(nhanVienID, viec.nhanVienID) &&
                   ngayLam == viec.ngayLam &&
                   caLam == viec.caLam;
        }

        public override int GetHashCode()
        {
            int hashCode = 886358403;
            hashCode = hashCode * -1521134295 + lichLamViecID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<CNhanVien>.Default.GetHashCode(nhanVienID);
            hashCode = hashCode * -1521134295 + ngayLam.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(caLam);
            return hashCode;
        }
    }
}
