namespace EFN.Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City : BaseEntity
    {
        //public int CityID { get; set; }

        [Required]
        public string CityName { get; set; }

        //public ICollection<Employee> Employees { get; set; }
    }
}
