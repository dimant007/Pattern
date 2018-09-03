namespace EFN.Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee :BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        public int? City { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }
    }
}
