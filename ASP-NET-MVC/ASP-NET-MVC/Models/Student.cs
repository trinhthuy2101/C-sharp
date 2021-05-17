namespace ASP_NET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("webt2289_thuy.Student")]
    public partial class Student
    {
        [Key]
        [StringLength(8)]
        public string S_id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int? age { get; set; }

        [StringLength(3)]
        public string gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dob { get; set; }

        [Column("class")]
        [StringLength(6)]
        public string _class { get; set; }

        [StringLength(2)]
        public string dep { get; set; }

        public DateTime? create_date { get; set; }

        public virtual Class Class1 { get; set; }
    }
}
