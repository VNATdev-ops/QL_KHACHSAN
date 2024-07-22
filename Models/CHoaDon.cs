using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CHoaDon
    {
        private int iDHoaDon;
        private CDatPhong idDatphong;
        private DateTime ngayLap;
        private decimal tongTien;

        public CHoaDon()
        {
        }

        public CHoaDon(int iDHoaDon, CDatPhong idDatphong, DateTime ngayLap, decimal tongTien)
        {
            this.iDHoaDon = iDHoaDon;
            this.idDatphong = idDatphong;
            this.ngayLap = ngayLap;
            this.tongTien = tongTien;
        }

        public int IDHoaDon { get => iDHoaDon; set => iDHoaDon = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        internal CDatPhong IdDatphong { get => idDatphong; set => idDatphong = value; }

        public override bool Equals(object obj)
        {
            return obj is CHoaDon don &&
                   iDHoaDon == don.iDHoaDon &&
                   EqualityComparer<CDatPhong>.Default.Equals(idDatphong, don.idDatphong) &&
                   ngayLap == don.ngayLap &&
                   tongTien == don.tongTien;
        }

        public override int GetHashCode()
        {
            int hashCode = -257023770;
            hashCode = hashCode * -1521134295 + iDHoaDon.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<CDatPhong>.Default.GetHashCode(idDatphong);
            hashCode = hashCode * -1521134295 + ngayLap.GetHashCode();
            hashCode = hashCode * -1521134295 + tongTien.GetHashCode();
            return hashCode;
        }
    }
}
