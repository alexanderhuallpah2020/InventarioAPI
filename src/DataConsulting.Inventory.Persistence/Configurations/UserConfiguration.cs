﻿using DataConsulting.Inventory.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Persistence.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(
            EntityTypeBuilder<User> builder
            )
        {
            builder.ToTable("users");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
        .HasConversion(userId => userId!.Value, value => new UserId(value));


            builder.Property(user => user.Nombre)
                .HasMaxLength(200)
                .HasConversion(nombre => nombre!.Value, value => new Nombre(value));


            builder.Property(user => user.Apellido)
            .HasMaxLength(200)
            .HasConversion(apellido => apellido!.Value, value => new Apellido(value));

            builder.Property(user => user.Email)
            .HasMaxLength(400)
            .HasConversion(email => email!.Value, value => new Domain.Users.Email(value));

            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}
