//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanlyDontu
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblNhanvien
    {
        public tblNhanvien()
        {
            this.tblDontus = new HashSet<tblDontu>();
        }
    
        public int ID { get; set; }
        public string ma_nhan_vien { get; set; }
        public string mat_khau { get; set; }
        public string email { get; set; }
        public string ho_va_ten { get; set; }
        public Nullable<int> so_dien_thoai { get; set; }
        public Nullable<int> FK_PhongbanID { get; set; }
    
        public virtual ICollection<tblDontu> tblDontus { get; set; }
        public virtual tblPhongban tblPhongban { get; set; }
    }
}
