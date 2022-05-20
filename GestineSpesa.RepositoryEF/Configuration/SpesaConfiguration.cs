using GestioneSpesa.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestineSpesa.RepositoryEF.Configuration
{
    public class SpesaConfiguration : IEntityTypeConfiguration<Spesa>
    {
        public void Configure(EntityTypeBuilder<Spesa> builder)
        {
            builder.ToTable("Spesa");
            builder.HasKey(s => s.Id);

            //relazione con categoria 
            //builder.HasMany(s => s.Categorie).WithOne
        }
    }
}
