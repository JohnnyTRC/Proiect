namespace MeniuModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Meniu")]
    public partial class Meniu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meniu()
        {
            Comenzis = new HashSet<Comenzi>();
        }

        [Key]
        public int ProdusId { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeProdus { get; set; }

        public double Pret { get; set; }

        [Column(TypeName = "text")]
        public string Descriere { get; set; }

        [Column(TypeName = "image")]
        public byte[] PozaProdus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comenzi> Comenzis { get; set; }
    }
}
