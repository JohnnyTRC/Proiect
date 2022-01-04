namespace MeniuModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comenzi")]
    public partial class Comenzi
    {
        [Key]
        public int ComandaId { get; set; }

        public int ClientId { get; set; }

        public int ProdusId { get; set; }

        public int Cantitate { get; set; }

        public DateTime DataComanda { get; set; }

        public virtual Clienti Clienti { get; set; }

        public virtual Meniu Meniu { get; set; }
    }
}
