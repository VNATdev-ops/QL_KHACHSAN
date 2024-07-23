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

  public CDichvu()
        { }
        public CDichvu(int DichVuID, string TenDichVu, double GiaTien)
        {
            this.DichVuID = DichVuID;
            this.TenDichVu = TenDichVu;
            this.GiaTien = GiaTien;

        }
        public int DichVuID1 { get => DichVuID; set => DichVuID = value; }
        public string TenDichVu1 { get => TenDichVu; set => TenDichVu = value; }
        public double GiaTien1 { get => GiaTien; set => GiaTien = value; }

      

        public override bool Equals(object obj)
        {
            return obj is CDichvu dichvu &&
                   DichVuID == dichvu.DichVuID &&
                   TenDichVu == dichvu.TenDichVu &&
                   GiaTien == dichvu.GiaTien;
        }

        public override int GetHashCode()
        {
            int hashCode = 1733738890;
            hashCode = hashCode * -1521134295 + DichVuID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TenDichVu);
            hashCode = hashCode * -1521134295 + GiaTien.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return DichVuID.ToString();
        }
    }

}
