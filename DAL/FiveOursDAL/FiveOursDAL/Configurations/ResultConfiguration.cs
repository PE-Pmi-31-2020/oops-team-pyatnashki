using FiveOursDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiveOursDAL.Configurations
{
    class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("Results");

            builder.Property(e => e.ResultId)
                .HasColumnName("result_id")
                .UseIdentityColumn();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(e => e.Time)
                .IsRequired()
                .HasColumnName("time");

            builder.Property(e => e.NumberOfMoves)
                .IsRequired()
                .HasColumnName("number_of_moves");
        }
    }
}
