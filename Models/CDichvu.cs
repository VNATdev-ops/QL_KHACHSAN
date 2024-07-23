using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CDichvu
    {
        private int DichVuID;
        private string TenDichVu;
        private double GiaTien;

        public int DichVuID1 { get => DichVuID; set => DichVuID = value; }
        public string TenDichVu1 { get => TenDichVu; set => TenDichVu = value; }
        public double GiaTien1 { get => GiaTien; set => GiaTien = value; }

        public CDichvu(int DichVuID, string TenDichVu, double GiaTien)
        {
            this.DichVuID = DichVuID;
            this.TenDichVu = TenDichVu;
            this.GiaTien = GiaTien;

        }
        public CDichvu()
        { }



        public override bool Equals(object obj)
        {
            return obj is CDichvu dichvu &&
                   DichVuID == dichvu.DichVuID;
        }

        public override int GetHashCode()
        {
            return 136591833 + DichVuID.GetHashCode();
        }
        public override string ToString()
        {
            return TenDichVu1 + "(" + DichVuID + ")";
        }

    }

}
