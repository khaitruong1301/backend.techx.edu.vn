//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinimaServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhoaHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoaHoc()
        {
            this.HocVienKhoaHocs = new HashSet<HocVienKhoaHoc>();
        }
    
        public string MaKhoaHoc { get; set; }
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> LuotXem { get; set; }
        public string NguoiTao { get; set; }
        public string HinhAnh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocVienKhoaHoc> HocVienKhoaHocs { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
