using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CDatDichVu
    {
        private int datDichVuID;
        private CDichvu dichVuID;
        private CPhong datPhongID;
        private DateTime ngayDat;

       

        public int DatDichVuID { get => datDichVuID; set => datDichVuID = value; }
        internal CDichvu DichVuID { get => dichVuID; set => dichVuID = value; }
        internal CPhong DatPhongID { get => datPhongID; set => datPhongID = value; }
        public DateTime NgayDat { get => ngayDat; set => ngayDat = value; }

        public CDatDichVu(int datDichVuID, CDichvu dichVuID, CPhong datPhongID, DateTime ngayDat)
        {
            this.datDichVuID = datDichVuID;
            this.dichVuID = dichVuID;
            this.datPhongID = datPhongID;
            this.ngayDat = ngayDat;
        }
        public CDatDichVu() 
        {

        }
        public override bool Equals(object obj)
        {
            return obj is CDatDichVu vu &&
                   datDichVuID == vu.datDichVuID;
        }

        public override int GetHashCode()
        {
            return 1077831890 + datDichVuID.GetHashCode();
        }
    }
}
