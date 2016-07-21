namespace ReqMVC.Models.Domian
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class HdEntities : DbContext
	{
		public HdEntities()
			: base("name=HdEntities")
		{
		}

		public virtual DbSet<deviceinfo> deviceinfos { get; set; }
		public virtual DbSet<devicetype> devicetypes { get; set; }
		public virtual DbSet<log> logs { get; set; }
		public virtual DbSet<news> news { get; set; }
		public virtual DbSet<postoffice> postoffices { get; set; }
		public virtual DbSet<post> posts { get; set; }
		public virtual DbSet<region> regions { get; set; }
		public virtual DbSet<request> requests { get; set; }
		public virtual DbSet<service> services { get; set; }
		public virtual DbSet<status> statuses { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
		public virtual DbSet<user> users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<deviceinfo>()
				.Property(e => e.model)
				.IsUnicode(false);

			modelBuilder.Entity<deviceinfo>()
				.Property(e => e.serial_number)
				.IsUnicode(false);

			modelBuilder.Entity<deviceinfo>()
				.Property(e => e.type)
				.IsUnicode(false);

			modelBuilder.Entity<deviceinfo>()
				.Property(e => e.mfr)
				.IsUnicode(false);

			modelBuilder.Entity<deviceinfo>()
				.Property(e => e.parent_active)
				.IsUnicode(false);

			modelBuilder.Entity<deviceinfo>()
				.Property(e => e.active)
				.IsUnicode(false);

			modelBuilder.Entity<deviceinfo>()
				.HasMany(e => e.requests)
				.WithOptional(e => e.deviceinfo)
				.HasForeignKey(e => e.deviceinfo_id);

			modelBuilder.Entity<deviceinfo>()
				.HasMany(e => e.requests1)
				.WithMany(e => e.deviceinfos)
				.Map(m => m.ToTable("request_deviceinfo"));

			modelBuilder.Entity<devicetype>()
				.Property(e => e.text)
				.IsUnicode(false);

			modelBuilder.Entity<devicetype>()
				.HasMany(e => e.deviceinfos)
				.WithOptional(e => e.devicetype)
				.HasForeignKey(e => e.devicetype_id);

			modelBuilder.Entity<log>()
				.Property(e => e.txt)
				.IsUnicode(false);

			modelBuilder.Entity<news>()
				.Property(e => e.text)
				.IsUnicode(false);

			modelBuilder.Entity<postoffice>()
				.Property(e => e.active_name)
				.IsUnicode(false);

			modelBuilder.Entity<postoffice>()
				.Property(e => e.priority)
				.IsUnicode(false);

			modelBuilder.Entity<postoffice>()
				.HasMany(e => e.deviceinfos)
				.WithOptional(e => e.postoffice)
				.HasForeignKey(e => e.ops_id);

			modelBuilder.Entity<postoffice>()
				.HasMany(e => e.requests)
				.WithOptional(e => e.postoffice)
				.HasForeignKey(e => e.ops_id);

			modelBuilder.Entity<post>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<post>()
				.HasMany(e => e.postoffices)
				.WithOptional(e => e.post)
				.HasForeignKey(e => e.idx_post);

			modelBuilder.Entity<post>()
				.HasMany(e => e.requests)
				.WithRequired(e => e.post)
				.HasForeignKey(e => e.post_id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<post>()
				.HasMany(e => e.users)
				.WithRequired(e => e.post)
				.HasForeignKey(e => e.post_id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<region>()
				.Property(e => e.number)
				.IsUnicode(false);

			modelBuilder.Entity<region>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<region>()
				.HasMany(e => e.posts)
				.WithOptional(e => e.region)
				.HasForeignKey(e => e.region_id);

			modelBuilder.Entity<request>()
				.Property(e => e.text)
				.IsUnicode(false);

			modelBuilder.Entity<request>()
				.Property(e => e.number)
				.IsUnicode(false);

			modelBuilder.Entity<request>()
				.Property(e => e.contact)
				.IsUnicode(false);

			modelBuilder.Entity<request>()
				.Property(e => e.shorttext)
				.IsUnicode(false);

			modelBuilder.Entity<request>()
				.Property(e => e.BF_NUMBER)
				.IsUnicode(false);

			modelBuilder.Entity<request>()
				.Property(e => e.bf_comment)
				.IsUnicode(false);

			modelBuilder.Entity<request>()
				.Property(e => e.inner_number)
				.IsUnicode(false);

			modelBuilder.Entity<service>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<service>()
				.HasMany(e => e.requests)
				.WithOptional(e => e.service)
				.HasForeignKey(e => e.service_id);

			modelBuilder.Entity<status>()
				.Property(e => e.text)
				.IsUnicode(false);

			modelBuilder.Entity<status>()
				.HasMany(e => e.requests)
				.WithOptional(e => e.status)
				.HasForeignKey(e => e.status_id);

			modelBuilder.Entity<user>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<user>()
				.Property(e => e.password)
				.IsUnicode(false);

			modelBuilder.Entity<user>()
				.Property(e => e.contact)
				.IsUnicode(false);

			modelBuilder.Entity<user>()
				.HasMany(e => e.requests)
				.WithRequired(e => e.user)
				.HasForeignKey(e => e.author_id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<user>()
				.HasMany(e => e.requests1)
				.WithOptional(e => e.user1)
				.HasForeignKey(e => e.solver_id);
		}
	}
}
