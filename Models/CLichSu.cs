using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CLichSu
    {
        private int LichSuID;
        private int KhachHangID;
        private int PhongID;
        private DateTime NgayNhan;
        private DateTime NgayTra;
        public CLichSu()
        {
        }

        public CLichSu(int lichSuID, int khachHangID, int phongID, DateTime ngayNhan, DateTime ngayTra)
        {
            LichSuID = lichSuID;
            KhachHangID = khachHangID;
            PhongID = phongID;
            NgayNhan = ngayNhan;
            NgayTra = ngayTra;
        }

        public int LichSuID1 { get => LichSuID; set => LichSuID = value; }
        public int KhachHangID1 { get => KhachHangID; set => KhachHangID = value; }
        public int PhongID1 { get => PhongID; set => PhongID = value; }
        public DateTime NgayNhan1 { get => NgayNhan; set => NgayNhan = value; }
        public DateTime NgayTra1 { get => NgayTra; set => NgayTra = value; }

        public override bool Equals(object obj)
        {
            return obj is CLichSu su &&
                   LichSuID == su.LichSuID &&
                   KhachHangID == su.KhachHangID &&
                   PhongID == su.PhongID &&
                   NgayNhan == su.NgayNhan &&
                   NgayTra == su.NgayTra;
        }

        public override int GetHashCode()
        {
            int hashCode = -1818766339;
            hashCode = hashCode * -1521134295 + LichSuID.GetHashCode();
            hashCode = hashCode * -1521134295 + KhachHangID.GetHashCode();
            hashCode = hashCode * -1521134295 + PhongID.GetHashCode();
            hashCode = hashCode * -1521134295 + NgayNhan.GetHashCode();
            hashCode = hashCode * -1521134295 + NgayTra.GetHashCode();
            return hashCode;
        }
    }
}
