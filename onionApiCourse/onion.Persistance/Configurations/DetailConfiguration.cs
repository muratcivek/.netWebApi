using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Persistance.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("tr");

            Detail detail = new()
            {
                Id = 1,
                title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            Detail detail2 = new()
            {
                Id = 2,
                title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3,
                CreatedDate = DateTime.Now,
                IsDeleted = true
            };
            Detail detail3 = new()
            {
                Id = 3,
                title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
        }
    }
}
