using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CPhong
    {
        private int phongId;
        private string soPhong;
        private string loaiPhong;
        private decimal giaTien;
        private string tinhTrang;


        public CPhong()
        {
        }

       

        public CPhong(int phongId, string soPhong, string loaiPhong, decimal giaTien, string tinhTrang)
        {
            this.phongId = phongId;
            this.soPhong = soPhong;
            this.loaiPhong = loaiPhong;
            this.giaTien = giaTien;
            this.tinhTrang = tinhTrang;
        }

        public int PhongId { get => phongId; set => phongId = value; }
        public string SoPhong { get => soPhong; set => soPhong = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
        public decimal GiaTien { get => giaTien; set => giaTien = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        public override bool Equals(object obj)
        {
            return obj is CPhong phong && phongId == phong.phongId;
        }

        public override int GetHashCode()
        {
            return phongId.GetHashCode();
        }
    }
}
