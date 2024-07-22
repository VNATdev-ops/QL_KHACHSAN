using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CDatPhong
    {
        private int datPhongID;
        private int phongID;
        private int khachHangID;
        private DateTime NgayDat;
        private DateTime NgayNhan;
        private DateTime NgayTra;
        private string TinhTrang;

        public CDatPhong()
        {
        }

        public CDatPhong(int datPhongID, int phongID, int khachHangID, DateTime ngayDat, DateTime ngayNhan, DateTime ngayTra, string tinhTrang)
        {
            this.datPhongID = datPhongID;
            this.phongID = phongID;
            this.khachHangID = khachHangID;
            NgayDat = ngayDat;
            NgayNhan = ngayNhan;
            NgayTra = ngayTra;
            TinhTrang = tinhTrang;
        }

        public int DatPhongID { get => datPhongID; set => datPhongID = value; }
        public int PhongID { get => phongID; set => phongID = value; }
        public int KhachHangID { get => khachHangID; set => khachHangID = value; }
        public DateTime NgayDat1 { get => NgayDat; set => NgayDat = value; }
        public DateTime NgayNhan1 { get => NgayNhan; set => NgayNhan = value; }
        public DateTime NgayTra1 { get => NgayTra; set => NgayTra = value; }
        public string TinhTrang1 { get => TinhTrang; set => TinhTrang = value; }

        public override bool Equals(object obj)
        {
            return obj is CDatPhong phong &&
                   datPhongID == phong.datPhongID &&
                   phongID == phong.phongID &&
                   khachHangID == phong.khachHangID &&
                   NgayDat == phong.NgayDat &&
                   NgayNhan == phong.NgayNhan &&
                   NgayTra == phong.NgayTra &&
                   TinhTrang == phong.TinhTrang;
        }

        public override int GetHashCode()
        {
            int hashCode = -102085159;
            hashCode = hashCode * -1521134295 + datPhongID.GetHashCode();
            hashCode = hashCode * -1521134295 + phongID.GetHashCode();
            hashCode = hashCode * -1521134295 + khachHangID.GetHashCode();
            hashCode = hashCode * -1521134295 + NgayDat.GetHashCode();
            hashCode = hashCode * -1521134295 + NgayNhan.GetHashCode();
            hashCode = hashCode * -1521134295 + NgayTra.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TinhTrang);
            return hashCode;
        }
    }
}
