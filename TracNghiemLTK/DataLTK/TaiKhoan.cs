﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLTK
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            this.DeThis = new HashSet<DeThi>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }
        //[Compare("ConfirmPassword", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        //Confirm Password
        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        public Nullable<int> MaQuyen { get; set; }
        [Display(Name= "Họ Tên")]
        public string HoTen { get; set; }
        [Display(Name = "Giới Tính")]
        public Nullable<bool> GioiTinh { get; set; }
        [Display(Name = "Ngày Sinh")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "SĐT")]
        public Nullable<int> SDT { get; set; }
        public byte[] Image { get; set; }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeThi> DeThis { get; set; }
        public virtual Quyen Quyen { get; set; }
    }
}
