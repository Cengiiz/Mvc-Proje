namespace LibraryDAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [Key]
        public int Identity { get; set; }

        public int? Authorldentity { get; set; }

        public int? CategoryIdentity { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PublishYear { get; set; }

        public int? Status { get; set; }

        public byte? StockQuantity { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }
    }
}
