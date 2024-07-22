using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Models
{
    internal class CBaoCaoSuCo
    {
        private int suCoID;
        private CPhong phongID;
        private CNhanVien nhanVienID;
        private string moTa;
        private DateTime ngayBaoCao;

        public CBaoCaoSuCo()
        {
        }

        public CBaoCaoSuCo(int suCoID, CPhong phongID, CNhanVien nhanVienID, string moTa, DateTime ngayBaoCao)
        {
            this.suCoID = suCoID;
            this.phongID = phongID;
            this.nhanVienID = nhanVienID;
            this.moTa = moTa;
            this.ngayBaoCao = ngayBaoCao;
        }

        public int SuCoID { get => suCoID; set => suCoID = value; }
        public CNhanVien NhanVienID { get => nhanVienID; set => nhanVienID = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public DateTime NgayBaoCao { get => ngayBaoCao; set => ngayBaoCao = value; }
        internal CPhong PhongID { get => phongID; set => phongID = value; }

        public override bool Equals(object obj)
        {
            return obj is CBaoCaoSuCo co &&
                   suCoID == co.suCoID &&
                   EqualityComparer<CPhong>.Default.Equals(phongID, co.phongID) &&
                   EqualityComparer<CNhanVien>.Default.Equals(nhanVienID, co.nhanVienID) &&
                   moTa == co.moTa &&
                   ngayBaoCao == co.ngayBaoCao;
        }

        public override int GetHashCode()
        {
            int hashCode = 643033650;
            hashCode = hashCode * -1521134295 + suCoID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<CPhong>.Default.GetHashCode(phongID);
            hashCode = hashCode * -1521134295 + EqualityComparer<CNhanVien>.Default.GetHashCode(nhanVienID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(moTa);
            hashCode = hashCode * -1521134295 + ngayBaoCao.GetHashCode();
            return hashCode;
        }
    }
}
