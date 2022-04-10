using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eTuristickaAgencija.API.Database
{
    public partial class TuristickaAgencijaContext : DbContext
    {
        public TuristickaAgencijaContext()
        {
        }

        public TuristickaAgencijaContext(DbContextOptions<TuristickaAgencijaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clan> Clan { get; set; }
        public virtual DbSet<Destinacija> Destinacija { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Karta> Karta { get; set; }
        public virtual DbSet<Kontinent> Kontinent { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Ocjena> Ocjena { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Termin> Termin { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Uposlenik> Uposlenik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost, 1433;Initial Catalog=TuristickaAgencija; user=sa; Password=ASas.,12");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumRegistracije).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Clan_korisnik");
            });

            modelBuilder.Entity<Destinacija>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Destinacija)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK_Grad_Destinacija");
            });

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KontinentId).HasColumnName("KontinentID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Kontinent)
                    .WithMany(p => p.Drzava)
                    .HasForeignKey(d => d.KontinentId)
                    .HasConstraintName("FK_Kontinent_Drzava");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grad)
                    .HasForeignKey(d => d.DrzavaId)
                    .HasConstraintName("FK_Grad_Drzava");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Hotel)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK_Grad1");
            });

            modelBuilder.Entity<Karta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumKreiranja).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.TerminId).HasColumnName("TerminID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Karta)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("fk_Korisnik_Karta");

                entity.HasOne(d => d.Termin)
                    .WithMany(p => p.Karta)
                    .HasForeignKey(d => d.TerminId)
                    .HasConstraintName("FK_Karta_Termin");
            });

            modelBuilder.Entity<Kontinent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnikoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash).IsRequired();

                entity.Property(e => e.LozinkaSalt).IsRequired();

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.UlogaId)
                    .HasConstraintName("FK_Korisnik_Uloga");
            });

            modelBuilder.Entity<Ocjena>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DestinacijaId).HasColumnName("DestinacijaID");

                entity.Property(e => e.Komentar).HasColumnType("text");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Destinacija)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.DestinacijaId)
                    .HasConstraintName("fk_Destinacija");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("fk_Korisnik");
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.DatumRezervacije).HasColumnType("datetime");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Rezervacija_Hotel");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Rezervacija_Korisnik");
            });

            modelBuilder.Entity<Termin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.CijenaPopust).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.DatumDolaska).HasColumnType("datetime");

                entity.Property(e => e.DatumPolaska).HasColumnType("datetime");

                entity.Property(e => e.DestinacijaId).HasColumnName("DestinacijaID");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.HasOne(d => d.Destinacija)
                    .WithMany(p => p.Termin)
                    .HasForeignKey(d => d.DestinacijaId)
                    .HasConstraintName("FK_Termin_Destinacija");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Termin)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK_Termin_Grad");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Termin)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Angazman_Hotel");
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Uposlenik>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumZaposlenja).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Uposlenik)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Uposlenik_korisnik");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
