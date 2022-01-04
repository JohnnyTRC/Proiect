using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MeniuModel
{
    public partial class MeniuEntitiesModel : DbContext
    {
        public MeniuEntitiesModel()
            : base("name=MeniuEntitiesModel")
        {
        }

        public virtual DbSet<Clienti> Clientis { get; set; }
        public virtual DbSet<Comenzi> Comenzis { get; set; }
        public virtual DbSet<Meniu> Menius { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clienti>()
                .Property(e => e.NumeClient)
                .IsFixedLength();

            modelBuilder.Entity<Clienti>()
                .Property(e => e.PrenumeClient)
                .IsFixedLength();

            modelBuilder.Entity<Clienti>()
                .Property(e => e.NrTelefon)
                .IsFixedLength();

            modelBuilder.Entity<Meniu>()
                .Property(e => e.Descriere)
                .IsUnicode(false);
        }
    }
}
