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

    public partial class Quiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quiz()
        {
            this.ch_db = new HashSet<ch_db>();
        }
    
        public int MaCauHoi { get; set; }
        public Nullable<int> MaMon { get; set; }
		[Display(Name = "Câu hỏi")]
		public string CauHoi { get; set; }
		[Display(Name = "Hình ảnh")]
		public byte[] Picture { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
		[Display(Name = "Đáp án")]
		public string DapAn { get; set; }
		public bool table_records { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ch_db> ch_db { get; set; }
        public virtual MonThi MonThi { get; set; }
    }
}
