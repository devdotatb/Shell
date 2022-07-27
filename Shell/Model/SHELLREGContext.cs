using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shell.Model
{
    public partial class SHELLREGContext : DbContext
    {
        public SHELLREGContext()
        {
        }

        public SHELLREGContext(DbContextOptions<SHELLREGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorizeDocument> AuthorizeDocuments { get; set; } = null!;
        public virtual DbSet<AuthorizeDocumentUser> AuthorizeDocumentUsers { get; set; } = null!;
        public virtual DbSet<AuthorizeMenu> AuthorizeMenus { get; set; } = null!;
        public virtual DbSet<AuthorizeMenuDocument> AuthorizeMenuDocuments { get; set; } = null!;
        public virtual DbSet<AuthorizeMenuUser> AuthorizeMenuUsers { get; set; } = null!;
        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<CampaignProduct> CampaignProducts { get; set; } = null!;
        public virtual DbSet<CarTypeOil> CarTypeOils { get; set; } = null!;
        public virtual DbSet<ImportControl> ImportControls { get; set; } = null!;
        public virtual DbSet<ImportLog> ImportLogs { get; set; } = null!;
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
        public virtual DbSet<InvoiceHeader> InvoiceHeaders { get; set; } = null!;
        public virtual DbSet<InvoiceStatus> InvoiceStatuses { get; set; } = null!;
        public virtual DbSet<LogSendLine> LogSendLines { get; set; } = null!;
        public virtual DbSet<LogSystem> LogSystems { get; set; } = null!;
        public virtual DbSet<Lot> Lots { get; set; } = null!;
        public virtual DbSet<MatchField> MatchFields { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCarType> ProductCarTypes { get; set; } = null!;
        public virtual DbSet<ProductGroup> ProductGroups { get; set; } = null!;
        public virtual DbSet<ProductModel> ProductModels { get; set; } = null!;
        public virtual DbSet<ProductSub> ProductSubs { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<ProductUnit> ProductUnits { get; set; } = null!;
        public virtual DbSet<ShoppingDetail> ShoppingDetails { get; set; } = null!;
        public virtual DbSet<ShoppingHeader> ShoppingHeaders { get; set; } = null!;
        public virtual DbSet<TradeOwner> TradeOwners { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Integrated Security=SSPI;Initial Catalog=SHELL-REG;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CI_AS");

            modelBuilder.Entity<AuthorizeDocument>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("Authorize_Document");

                entity.Property(e => e.DocId)
                    .ValueGeneratedNever()
                    .HasColumnName("doc_id");

                entity.Property(e => e.ApprovePer)
                    .HasColumnName("approve_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatePer)
                    .HasColumnName("create_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DeletePer)
                    .HasColumnName("delete_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DocName)
                    .HasMaxLength(255)
                    .HasColumnName("doc_name")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocUsed)
                    .HasColumnName("doc_used")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EditPer)
                    .HasColumnName("edit_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExportPer)
                    .HasColumnName("export_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintPer)
                    .HasColumnName("print_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ViewPer)
                    .HasColumnName("view_per")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AuthorizeDocumentUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Authorize_Document_User");

                entity.HasIndex(e => e.UserId, "inx_UserID");

                entity.Property(e => e.ApprovePer)
                    .HasColumnName("approve_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatePer)
                    .HasColumnName("create_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DeletePer)
                    .HasColumnName("delete_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DocId).HasColumnName("doc_id");

                entity.Property(e => e.EditPer)
                    .HasColumnName("edit_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExportPer)
                    .HasColumnName("export_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintPer)
                    .HasColumnName("print_per")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ViewPer)
                    .HasColumnName("view_per")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AuthorizeMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("Authorize_Menu");

                entity.Property(e => e.MenuId)
                    .ValueGeneratedNever()
                    .HasColumnName("Menu_id");

                entity.Property(e => e.MenuMain)
                    .HasColumnName("Menu_Main")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(255)
                    .HasColumnName("Menu_Name")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MenuPosition)
                    .HasColumnName("Menu_Position")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AuthorizeMenuDocument>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Authorize_Menu_Document");

                entity.Property(e => e.AuthOrder)
                    .HasColumnName("auth_order")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DocId)
                    .HasColumnName("Doc_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuId)
                    .HasColumnName("Menu_id")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AuthorizeMenuUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Authorize_Menu_User");

                entity.HasIndex(e => e.UserId, "inx_UserID");

                entity.Property(e => e.MenuId).HasColumnName("Menu_id");

                entity.Property(e => e.MenuUsed)
                    .HasColumnName("Menu_Used")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.HasKey(e => e.CampaignCode);

                entity.ToTable("Campaign");

                entity.Property(e => e.CampaignCode).HasMaxLength(20);

                entity.Property(e => e.CampaignName).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasMaxLength(10);

                entity.Property(e => e.StartDate).HasMaxLength(10);

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.UserDate)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserEdit)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<CampaignProduct>(entity =>
            {
                entity.HasKey(e => new { e.CampaignCode, e.MaterialCode });

                entity.ToTable("CampaignProduct");

                entity.HasIndex(e => e.CampaignCode, "inx_CampaignCode");

                entity.HasIndex(e => e.MaterialCode, "inx_MaterialCode");

                entity.Property(e => e.CampaignCode).HasMaxLength(20);

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.AcodeUse).HasColumnName("ACodeUse");
            });

            modelBuilder.Entity<CarTypeOil>(entity =>
            {
                entity.HasKey(e => e.CarTypeOilCode);

                entity.ToTable("CarTypeOil");

                entity.Property(e => e.CarTypeOilCode).HasMaxLength(50);

                entity.Property(e => e.CarTypeOilName).HasMaxLength(50);
            });

            modelBuilder.Entity<ImportControl>(entity =>
            {
                entity.HasKey(e => e.ImportId);

                entity.ToTable("ImportControl");

                entity.Property(e => e.ImportId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ImportID");

                entity.Property(e => e.ImportDateTime).HasColumnType("numeric(14, 0)");

                entity.Property(e => e.ImportType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Result)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsrId)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("UsrID");
            });

            modelBuilder.Entity<ImportLog>(entity =>
            {
                entity.ToTable("ImportLog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImportId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ImportID");

                entity.Property(e => e.Remark).HasMaxLength(2000);
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("InvoiceDetail");

                entity.HasIndex(e => e.Deleted, "inx_Deleted");

                entity.HasIndex(e => new { e.InvoiceNo, e.MaterialCode }, "inx_Invoice01");

                entity.HasIndex(e => e.InvoiceNo, "inx_InvoiceNo");

                entity.HasIndex(e => e.MaterialCode, "inx_MaterialCode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddTime).HasMaxLength(10);

                entity.Property(e => e.AddUserId)
                    .HasMaxLength(50)
                    .HasColumnName("AddUserID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EditTime).HasMaxLength(10);

                entity.Property(e => e.EditUserId)
                    .HasMaxLength(50)
                    .HasColumnName("EditUserID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.MaterialCode)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductQty).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<InvoiceHeader>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo);

                entity.ToTable("InvoiceHeader");

                entity.HasIndex(e => e.Acode, "inx_ACode");

                entity.HasIndex(e => new { e.InvoiceNo, e.InvoiceDate, e.Acode, e.InvoiceStatusId }, "inx_InvoiceHeader01");

                entity.HasIndex(e => e.InvoiceNo, "inx_InvoiceNo")
                    .IsUnique();

                entity.HasIndex(e => e.InvoiceStatusId, "inx_InvoiceStatusID");

                entity.HasIndex(e => e.LotNo, "inx_LotNo");

                entity.HasIndex(e => e.ShoppingNo, "inx_ShoppingNo");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.Acode)
                    .HasMaxLength(10)
                    .HasColumnName("ACode")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddTime).HasMaxLength(10);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EditTime).HasMaxLength(10);

                entity.Property(e => e.EditUserId)
                    .HasMaxLength(50)
                    .HasColumnName("EditUserID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceDate).HasMaxLength(10);

                entity.Property(e => e.InvoiceStatusId).HasColumnName("InvoiceStatusID");

                entity.Property(e => e.LotNo)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShoppingNo).HasMaxLength(20);
            });

            modelBuilder.Entity<InvoiceStatus>(entity =>
            {
                entity.ToTable("InvoiceStatus");

                entity.Property(e => e.InvoiceStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("InvoiceStatusID");

                entity.Property(e => e.InvoiceStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<LogSendLine>(entity =>
            {
                entity.ToTable("LogSendLine");

                entity.HasIndex(e => e.LogType, "inx_LogType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LogDate).HasMaxLength(50);

                entity.Property(e => e.LogName).HasMaxLength(100);

                entity.Property(e => e.LogType).HasMaxLength(50);

                entity.Property(e => e.LogUid)
                    .HasMaxLength(100)
                    .HasColumnName("LogUID");
            });

            modelBuilder.Entity<LogSystem>(entity =>
            {
                entity.ToTable("LogSystem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(50)
                    .HasColumnName("IPaddress");

                entity.Property(e => e.LogDate).HasMaxLength(50);

                entity.Property(e => e.LogType).HasMaxLength(100);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<Lot>(entity =>
            {
                entity.HasKey(e => e.LotNo);

                entity.Property(e => e.LotNo).HasMaxLength(20);

                entity.Property(e => e.LotDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LotTime)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LotUserId)
                    .HasMaxLength(50)
                    .HasColumnName("LotUserID")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<MatchField>(entity =>
            {
                entity.HasKey(e => new { e.Fieldndex, e.FieldType });

                entity.ToTable("MatchField");

                entity.Property(e => e.FieldType).HasMaxLength(20);

                entity.Property(e => e.FieldData).HasMaxLength(100);

                entity.Property(e => e.FieldExcel).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.MaterialCode);

                entity.ToTable("Product");

                entity.HasIndex(e => new { e.MaterialCode, e.SalesTextCode, e.ProductName }, "inx_Product01");

                entity.HasIndex(e => e.ProductGroup, "inx_ProductGroup");

                entity.HasIndex(e => e.ProductName, "inx_ProductName");

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.AcodeUse)
                    .HasColumnName("ACodeUse")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BestSeller).HasDefaultValueSql("((0))");

                entity.Property(e => e.EndDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductCarType)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductDesc)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductGroup)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductModel)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductNameEn)
                    .HasMaxLength(200)
                    .HasColumnName("ProductNameEN")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductNameTh)
                    .HasMaxLength(200)
                    .HasColumnName("ProductNameTH")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductPerUnit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductPic)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductSize)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductSub)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductUnit)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductVis)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalesTextCode)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<ProductCarType>(entity =>
            {
                entity.HasKey(e => e.ProductCarType1);

                entity.ToTable("ProductCarType");

                entity.Property(e => e.ProductCarType1)
                    .HasMaxLength(50)
                    .HasColumnName("ProductCarType");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasKey(e => e.ProductGroup1);

                entity.ToTable("ProductGroup");

                entity.Property(e => e.ProductGroup1)
                    .HasMaxLength(50)
                    .HasColumnName("ProductGroup");
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasKey(e => e.ProductModel1);

                entity.ToTable("ProductModel");

                entity.Property(e => e.ProductModel1)
                    .HasMaxLength(50)
                    .HasColumnName("ProductModel");
            });

            modelBuilder.Entity<ProductSub>(entity =>
            {
                entity.HasKey(e => e.ProductSub1);

                entity.ToTable("ProductSub");

                entity.Property(e => e.ProductSub1)
                    .HasMaxLength(50)
                    .HasColumnName("ProductSub");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.ProductType1);

                entity.Property(e => e.ProductType1)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductType");

                entity.Property(e => e.ProductTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductUnit>(entity =>
            {
                entity.HasKey(e => e.ProductUnit1);

                entity.ToTable("ProductUnit");

                entity.Property(e => e.ProductUnit1)
                    .HasMaxLength(10)
                    .HasColumnName("ProductUnit");
            });

            modelBuilder.Entity<ShoppingDetail>(entity =>
            {
                entity.ToTable("ShoppingDetail");

                entity.HasIndex(e => new { e.ShoppingNo, e.MaterialCode }, "inx_Shopping01");

                entity.HasIndex(e => e.ShoppingNo, "inx_ShoppingNo");

                entity.HasIndex(e => new { e.ShoppingNo, e.MaterialCode }, "inx_ShoppingUnique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaterialCode)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShoppingNo).HasMaxLength(20);
            });

            modelBuilder.Entity<ShoppingHeader>(entity =>
            {
                entity.HasKey(e => e.ShoppingNo);

                entity.ToTable("ShoppingHeader");

                entity.HasIndex(e => e.Acode, "inx_ACode");

                entity.HasIndex(e => e.ShoppingUse, "inx_ShoppingUse");

                entity.Property(e => e.ShoppingNo).HasMaxLength(20);

                entity.Property(e => e.Acode)
                    .HasMaxLength(10)
                    .HasColumnName("ACode")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddTime).HasMaxLength(10);

                entity.Property(e => e.ShoppingUse).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TradeOwner>(entity =>
            {
                entity.HasKey(e => e.Acode);

                entity.ToTable("TradeOwner");

                entity.HasIndex(e => e.ContactName, "inx_ContactName");

                entity.HasIndex(e => e.Dsmid, "inx_DSMID");

                entity.HasIndex(e => e.Dsrid, "inx_DSRID");

                entity.HasIndex(e => e.Obamid, "inx_OBAMID");

                entity.HasIndex(e => e.ShopName, "inx_ShopName");

                entity.HasIndex(e => e.ShopType, "inx_ShopType");

                entity.HasIndex(e => e.Site, "inx_Site");

                entity.HasIndex(e => e.Tier, "inx_Tier");

                entity.Property(e => e.Acode)
                    .HasMaxLength(10)
                    .HasColumnName("ACode");

                entity.Property(e => e.Agree).HasDefaultValueSql("((0))");

                entity.Property(e => e.AgreeDate)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Brand)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClusterCode)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustShopType)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSubShopType)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dsmid)
                    .HasMaxLength(50)
                    .HasColumnName("DSMID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dsrid)
                    .HasMaxLength(50)
                    .HasColumnName("DSRID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GeoRegion)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineName)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineUid)
                    .HasMaxLength(100)
                    .HasColumnName("LineUID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Obamid)
                    .HasMaxLength(50)
                    .HasColumnName("OBAMID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RegisterCheck).HasDefaultValueSql("('')");

                entity.Property(e => e.RegisterDate)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShopName)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShopType)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Site)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SiteName)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tier)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserDate)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserEdit)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Fullname, "inx_Fullname");

                entity.HasIndex(e => e.Position, "inx_Position");

                entity.HasIndex(e => e.Username, "inx_Username")
                    .IsUnique();

                entity.HasIndex(e => new { e.Username, e.Password }, "inx_Users01");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineUid)
                    .HasMaxLength(100)
                    .HasColumnName("LineUID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RegisterCheck).HasDefaultValueSql("('')");

                entity.Property(e => e.RegisterDate)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserUse).HasDefaultValueSql("((0))");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
