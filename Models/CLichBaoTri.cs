using QL_KHACHSAN.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CLichBaoTri
    {
        private int lichBaoTriID;
        private CPhong phongID;
        private CNhanVien nhanvienID;
        private DateTime ngayBaoTri;
        private string moTa;

        public CLichBaoTri()
        {
        }

        public CLichBaoTri(int lichBaoTriID, CPhong phongID, CNhanVien nhanvienID, DateTime ngayBaoTri, string moTa)
        {
            this.lichBaoTriID = lichBaoTriID;
            this.phongID = phongID;
            this.nhanvienID = nhanvienID;
            this.ngayBaoTri = ngayBaoTri;
            this.moTa = moTa;
        }

        public int LichBaoTriID { get => lichBaoTriID; set => lichBaoTriID = value; }
        public CNhanVien NhanvienID { get => nhanvienID; set => nhanvienID = value; }
        public DateTime NgayBaoTri { get => ngayBaoTri; set => ngayBaoTri = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        internal CPhong PhongID { get => phongID; set => phongID = value; }

        public override bool Equals(object obj)
        {
            return obj is CLichBaoTri tri &&
                   lichBaoTriID == tri.lichBaoTriID &&
                   EqualityComparer<CPhong>.Default.Equals(phongID, tri.phongID) &&
                   EqualityComparer<CNhanVien>.Default.Equals(nhanvienID, tri.nhanvienID) &&
                   ngayBaoTri == tri.ngayBaoTri &&
                   moTa == tri.moTa;
        }

        public override int GetHashCode()
        {
            int hashCode = 58493327;
            hashCode = hashCode * -1521134295 + lichBaoTriID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<CPhong>.Default.GetHashCode(phongID);
            hashCode = hashCode * -1521134295 + EqualityComparer<CNhanVien>.Default.GetHashCode(nhanvienID);
            hashCode = hashCode * -1521134295 + ngayBaoTri.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(moTa);
            return hashCode;
        }
    }
}
