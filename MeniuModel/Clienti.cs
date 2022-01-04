namespace MeniuModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clienti")]
    public partial class Clienti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clienti()
        {
            Comenzis = new HashSet<Comenzi>();
        }

        [Key]
        public int ClientId { get; set; }

        [Required]
        [StringLength(10)]
        public string NumeClient { get; set; }

        [Required]
        [StringLength(10)]
        public string PrenumeClient { get; set; }

        [Required]
        [StringLength(10)]
        public string NrTelefon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comenzi> Comenzis { get; set; }
    }
}
