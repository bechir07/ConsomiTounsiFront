namespace ConsomiTounsiFront.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class consomitounsiEntities : DbContext
    {
        public consomitounsiEntities()
            : base("name=consomitounsi")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        //public virtual DbSet<addview> addview { get; set; }
        public virtual DbSet<bill> bill { get; set; }
        //public virtual DbSet<category> category { get; set; }
        //public virtual DbSet<chariot> chariot { get; set; }
        public virtual DbSet<command> command { get; set; }
        public virtual DbSet<command_line> command_line { get; set; }
        public virtual DbSet<comment> comment { get; set; }
        //public virtual DbSet<coupon> coupon { get; set; }
        public virtual DbSet<Delivery> delivery { get; set; }
        /*public virtual DbSet<delivery_men> delivery_men { get; set; }
        public virtual DbSet<don_chariot> don_chariot { get; set; }*/
        public virtual DbSet<Donation> donation { get; set; }
       /* public virtual DbSet<@event> @event { get; set; }
        public virtual DbSet<event_usersevent> event_usersevent { get; set; }
        public virtual DbSet<exchange> exchange { get; set; }
        public virtual DbSet<jackpot> jackpot { get; set; }
        public virtual DbSet<like_add> like_add { get; set; }
        public virtual DbSet<participation> participation { get; set; }*/
        public virtual DbSet<payment> payment { get; set; }
        public virtual DbSet<Product> product { get; set; }
       // public virtual DbSet<pub> pub { get; set; }
       // public virtual DbSet<rating> rating { get; set; }
        //public virtual DbSet<rayon> rayon { get; set; }
        //public virtual DbSet<reclamation> reclamation { get; set; }
        //public virtual DbSet<remboursement> remboursement { get; set; }
        //public virtual DbSet<reparation> reparation { get; set; }
        public virtual DbSet<Role> role { get; set; }
       // public virtual DbSet<Like_add> like_add { get; set; }
        //public virtual DbSet<Stock> stock { get; set; }
        public virtual DbSet<subject> subject { get; set; }
        public virtual DbSet<User> user { get; set; }
       // public virtual DbSet<User_roles> user_roles { get; set; }
    }
}