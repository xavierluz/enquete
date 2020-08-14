using app_enquete.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_enquete.Maps
{
    public sealed class EnqueteMap
    {
        private EnqueteMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poll>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.Description).HasName("IDX_POLL_DESCRIPTION");
                b.ToTable("Poll");
                b.Property(u => u.Id).ValueGeneratedOnAdd();
                b.Property(u => u.Description).HasMaxLength(100);

                b.HasMany(x => x.Options).WithOne(x => x.Poll).HasForeignKey(x => x.PollId);
                b.HasOne(x => x.Vote).WithOne(x => x.Poll).HasForeignKey<Vote>(x => x.PollId);
                b.HasOne(x => x.View).WithOne(x => x.Poll).HasForeignKey<View>(x => x.PollId);
            });

            modelBuilder.Entity<Option>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.Description).HasName("IDX_OPTION_DESCRIPTION");
                b.ToTable("Option");
                b.Property(u => u.Id).ValueGeneratedOnAdd();
                b.Property(u => u.Description).HasMaxLength(100);


                b.HasOne(x => x.Vote).WithOne(x => x.Option).HasForeignKey<Vote>(x => x.OptionId);
            });

            modelBuilder.Entity<View>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);
                b.HasIndex(u => new { u.PollId, u.Id }).HasName("IDX_VIEW_POLL_ID");
                b.ToTable("View");
                b.Property(u => u.Id).ValueGeneratedOnAdd();
                b.Property(u => u.PollId).IsRequired();
            });

            modelBuilder.Entity<Vote>(b =>
            {
                // Primary key
                b.HasKey(u => new {u.PollId, u.OptionId });
                b.ToTable("Vote");
                b.Property(u => u.PollId).IsRequired();
                b.Property(u => u.OptionId).IsRequired();

                
            });


        }
        internal static EnqueteMap Create(ModelBuilder modelBuilder)
        {
            return new EnqueteMap(modelBuilder);
        }
    }
}
