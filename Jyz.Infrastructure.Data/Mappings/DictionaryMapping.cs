using Jyz.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jyz.Infrastructure.Data.Mappings
{
    public class DictionaryMapping : IEntityTypeConfiguration<Dictionary>
    {
        public void Configure(EntityTypeBuilder<Dictionary> builder)
        {
            builder.HasQueryFilter(x => x.IsEnable);
            builder.Property(x => x.Category).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Code).HasMaxLength(50);
            builder.Property(x => x.Value).HasMaxLength(50);
            builder.Property(x => x.Remark).HasMaxLength(500);
        }
    }
}
