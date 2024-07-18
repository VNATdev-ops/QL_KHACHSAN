using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    public class CNhanVien
    {
        private int nhanvienID;
        private string tenNhanVien;
        private string viTri;
        private decimal luong;

        public CNhanVien()
        {
        }

        public CNhanVien(int nhanvienID, string tenNhanVien, string viTri, decimal luong)
        {
            this.nhanvienID = nhanvienID;
            this.tenNhanVien = tenNhanVien;
            this.viTri = viTri;
            this.luong = luong;
        }

        public int NhanvienID { get => nhanvienID; set => nhanvienID = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string ViTri { get => viTri; set => viTri = value; }
        public decimal Luong { get => luong; set => luong = value; }

        public override bool Equals(object obj)
        {
            return obj is CNhanVien vien &&
                   nhanvienID == vien.nhanvienID &&
                   tenNhanVien == vien.tenNhanVien &&
                   viTri == vien.viTri &&
                   luong == vien.luong;
        }

        public override int GetHashCode()
        {
            int hashCode = -1277412765;
            hashCode = hashCode * -1521134295 + nhanvienID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(tenNhanVien);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(viTri);
            hashCode = hashCode * -1521134295 + luong.GetHashCode();
            return hashCode;
        }
    }
}
