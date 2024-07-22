using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CKhachHang
    {
        private int KhachHangID;
        private string TenKhachHang;
        private string SoDienThoai;
        private string DiaChi;
        private string Email;

        public CKhachHang()
        {
        }

        public CKhachHang(int khachHangID, string tenKhachHang, string soDienThoai, string diaChi, string email)
        {
            KhachHangID = khachHangID;
            TenKhachHang = tenKhachHang;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            Email = email;
        }

        public int KhachHangID1 { get => KhachHangID; set => KhachHangID = value; }
        public string TenKhachHang1 { get => TenKhachHang; set => TenKhachHang = value; }
        public string SoDienThoai1 { get => SoDienThoai; set => SoDienThoai = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string Email1 { get => Email; set => Email = value; }

        public override bool Equals(object obj)
        {
            return obj is CKhachHang hang &&
                   KhachHangID == hang.KhachHangID &&
                   TenKhachHang == hang.TenKhachHang &&
                   SoDienThoai == hang.SoDienThoai &&
                   DiaChi == hang.DiaChi &&
                   Email == hang.Email;
        }

        public override int GetHashCode()
        {
            int hashCode = 1399371106;
            hashCode = hashCode * -1521134295 + KhachHangID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenKhachHang);
            hashCode = hashCode * -1521134295 + SoDienThoai.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DiaChi);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }
    }
}
