// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Conventions;
using Microsoft.Data.Entity.SqlServer.Metadata;
using Xunit;

namespace Microsoft.Data.Entity.SqlServer.Tests.Metadata
{
    public class SqlServerMetadataExtensionsTest
    {
        [Fact]
        public void Can_get_and_set_column_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .Metadata;

            Assert.Equal("Name", property.SqlServer().ColumnName);
            Assert.Equal("Name", ((IProperty)property).SqlServer().ColumnName);

            property.Relational().ColumnName = "Eman";

            Assert.Equal("Name", property.Name);
            Assert.Equal("Name", ((IProperty)property).Name);
            Assert.Equal("Eman", property.Relational().ColumnName);
            Assert.Equal("Eman", ((IProperty)property).Relational().ColumnName);
            Assert.Equal("Eman", property.SqlServer().ColumnName);
            Assert.Equal("Eman", ((IProperty)property).SqlServer().ColumnName);

            property.SqlServer().ColumnName = "MyNameIs";

            Assert.Equal("Name", property.Name);
            Assert.Equal("Name", ((IProperty)property).Name);
            Assert.Equal("Eman", property.Relational().ColumnName);
            Assert.Equal("Eman", ((IProperty)property).Relational().ColumnName);
            Assert.Equal("MyNameIs", property.SqlServer().ColumnName);
            Assert.Equal("MyNameIs", ((IProperty)property).SqlServer().ColumnName);

            property.SqlServer().ColumnName = null;

            Assert.Equal("Name", property.Name);
            Assert.Equal("Name", ((IProperty)property).Name);
            Assert.Equal("Eman", property.Relational().ColumnName);
            Assert.Equal("Eman", ((IProperty)property).Relational().ColumnName);
            Assert.Equal("Eman", property.SqlServer().ColumnName);
            Assert.Equal("Eman", ((IProperty)property).SqlServer().ColumnName);
        }

        [Fact]
        public void Can_get_and_set_table_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var entityType = modelBuilder
                .Entity<Customer>()
                .Metadata;

            Assert.Equal("Customer", entityType.SqlServer().TableName);
            Assert.Equal("Customer", ((IEntityType)entityType).SqlServer().TableName);

            entityType.Relational().TableName = "Customizer";

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customer", ((IEntityType)entityType).DisplayName());
            Assert.Equal("Customizer", entityType.Relational().TableName);
            Assert.Equal("Customizer", ((IEntityType)entityType).Relational().TableName);
            Assert.Equal("Customizer", entityType.SqlServer().TableName);
            Assert.Equal("Customizer", ((IEntityType)entityType).SqlServer().TableName);

            entityType.SqlServer().TableName = "Custardizer";

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customer", ((IEntityType)entityType).DisplayName());
            Assert.Equal("Customizer", entityType.Relational().TableName);
            Assert.Equal("Customizer", ((IEntityType)entityType).Relational().TableName);
            Assert.Equal("Custardizer", entityType.SqlServer().TableName);
            Assert.Equal("Custardizer", ((IEntityType)entityType).SqlServer().TableName);

            entityType.SqlServer().TableName = null;

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customer", ((IEntityType)entityType).DisplayName());
            Assert.Equal("Customizer", entityType.Relational().TableName);
            Assert.Equal("Customizer", ((IEntityType)entityType).Relational().TableName);
            Assert.Equal("Customizer", entityType.SqlServer().TableName);
            Assert.Equal("Customizer", ((IEntityType)entityType).SqlServer().TableName);
        }

        [Fact]
        public void Can_get_and_set_schema_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var entityType = modelBuilder
                .Entity<Customer>()
                .Metadata;

            Assert.Null(entityType.Relational().Schema);
            Assert.Null(((IEntityType)entityType).Relational().Schema);
            Assert.Null(entityType.SqlServer().Schema);
            Assert.Null(((IEntityType)entityType).SqlServer().Schema);

            entityType.Relational().Schema = "db0";

            Assert.Equal("db0", entityType.Relational().Schema);
            Assert.Equal("db0", ((IEntityType)entityType).Relational().Schema);
            Assert.Equal("db0", entityType.SqlServer().Schema);
            Assert.Equal("db0", ((IEntityType)entityType).SqlServer().Schema);

            entityType.SqlServer().Schema = "dbOh";

            Assert.Equal("db0", entityType.Relational().Schema);
            Assert.Equal("db0", ((IEntityType)entityType).Relational().Schema);
            Assert.Equal("dbOh", entityType.SqlServer().Schema);
            Assert.Equal("dbOh", ((IEntityType)entityType).SqlServer().Schema);

            entityType.SqlServer().Schema = null;

            Assert.Equal("db0", entityType.Relational().Schema);
            Assert.Equal("db0", ((IEntityType)entityType).Relational().Schema);
            Assert.Equal("db0", entityType.SqlServer().Schema);
            Assert.Equal("db0", ((IEntityType)entityType).SqlServer().Schema);
        }

        [Fact]
        public void Can_get_and_set_column_type()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .Metadata;

            Assert.Null(property.Relational().ColumnType);
            Assert.Null(((IProperty)property).Relational().ColumnType);
            Assert.Null(property.SqlServer().ColumnType);
            Assert.Null(((IProperty)property).SqlServer().ColumnType);

            property.Relational().ColumnType = "nvarchar(max)";

            Assert.Equal("nvarchar(max)", property.Relational().ColumnType);
            Assert.Equal("nvarchar(max)", ((IProperty)property).Relational().ColumnType);
            Assert.Equal("nvarchar(max)", property.SqlServer().ColumnType);
            Assert.Equal("nvarchar(max)", ((IProperty)property).SqlServer().ColumnType);

            property.SqlServer().ColumnType = "nvarchar(verstappen)";

            Assert.Equal("nvarchar(max)", property.Relational().ColumnType);
            Assert.Equal("nvarchar(max)", ((IProperty)property).Relational().ColumnType);
            Assert.Equal("nvarchar(verstappen)", property.SqlServer().ColumnType);
            Assert.Equal("nvarchar(verstappen)", ((IProperty)property).SqlServer().ColumnType);

            property.SqlServer().ColumnType = null;

            Assert.Equal("nvarchar(max)", property.Relational().ColumnType);
            Assert.Equal("nvarchar(max)", ((IProperty)property).Relational().ColumnType);
            Assert.Equal("nvarchar(max)", property.SqlServer().ColumnType);
            Assert.Equal("nvarchar(max)", ((IProperty)property).SqlServer().ColumnType);
        }

        [Fact]
        public void Can_get_and_set_column_default_expression()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .Metadata;

            Assert.Null(property.Relational().GeneratedValueSql);
            Assert.Null(((IProperty)property).Relational().GeneratedValueSql);
            Assert.Null(property.SqlServer().GeneratedValueSql);
            Assert.Null(((IProperty)property).SqlServer().GeneratedValueSql);

            property.Relational().GeneratedValueSql = "newsequentialid()";

            Assert.Equal("newsequentialid()", property.Relational().GeneratedValueSql);
            Assert.Equal("newsequentialid()", ((IProperty)property).Relational().GeneratedValueSql);
            Assert.Equal("newsequentialid()", property.SqlServer().GeneratedValueSql);
            Assert.Equal("newsequentialid()", ((IProperty)property).SqlServer().GeneratedValueSql);

            property.SqlServer().GeneratedValueSql = "expressyourself()";

            Assert.Equal("newsequentialid()", property.Relational().GeneratedValueSql);
            Assert.Equal("newsequentialid()", ((IProperty)property).Relational().GeneratedValueSql);
            Assert.Equal("expressyourself()", property.SqlServer().GeneratedValueSql);
            Assert.Equal("expressyourself()", ((IProperty)property).SqlServer().GeneratedValueSql);

            property.SqlServer().GeneratedValueSql = null;

            Assert.Equal("newsequentialid()", property.Relational().GeneratedValueSql);
            Assert.Equal("newsequentialid()", ((IProperty)property).Relational().GeneratedValueSql);
            Assert.Equal("newsequentialid()", property.SqlServer().GeneratedValueSql);
            Assert.Equal("newsequentialid()", ((IProperty)property).SqlServer().GeneratedValueSql);
        }

        [Fact]
        public void Can_get_and_set_column_default_value()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .Metadata;

            Assert.Null(property.Relational().DefaultValue);
            Assert.Null(((IProperty)property).Relational().DefaultValue);
            Assert.Null(property.SqlServer().DefaultValue);
            Assert.Null(((IProperty)property).SqlServer().DefaultValue);

            property.Relational().DefaultValue = new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 };

            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, property.Relational().DefaultValue);
            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, ((IProperty)property).Relational().DefaultValue);
            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, property.SqlServer().DefaultValue);
            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, ((IProperty)property).SqlServer().DefaultValue);

            property.SqlServer().DefaultValue = new Byte[] { 69, 70, 32, 83, 79, 67, 75, 83 };

            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, property.Relational().DefaultValue);
            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, ((IProperty)property).Relational().DefaultValue);
            Assert.Equal(new Byte[] { 69, 70, 32, 83, 79, 67, 75, 83 }, property.SqlServer().DefaultValue);
            Assert.Equal(new Byte[] { 69, 70, 32, 83, 79, 67, 75, 83 }, ((IProperty)property).SqlServer().DefaultValue);

            property.SqlServer().DefaultValue = null;

            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, property.Relational().DefaultValue);
            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, ((IProperty)property).Relational().DefaultValue);
            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, property.SqlServer().DefaultValue);
            Assert.Equal(new Byte[] { 69, 70, 32, 82, 79, 67, 75, 83 }, ((IProperty)property).SqlServer().DefaultValue);
        }

        [Fact]
        public void Can_get_and_set_column_key_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var key = modelBuilder
                .Entity<Customer>()
                .Key(e => e.Id)
                .Metadata;

            Assert.Equal("PK_Customer", key.Relational().Name);
            Assert.Equal("PK_Customer", ((IKey)key).Relational().Name);
            Assert.Equal("PK_Customer", key.SqlServer().Name);
            Assert.Equal("PK_Customer", ((IKey)key).SqlServer().Name);

            key.Relational().Name = "PrimaryKey";

            Assert.Equal("PrimaryKey", key.Relational().Name);
            Assert.Equal("PrimaryKey", ((IKey)key).Relational().Name);
            Assert.Equal("PrimaryKey", key.SqlServer().Name);
            Assert.Equal("PrimaryKey", ((IKey)key).SqlServer().Name);

            key.SqlServer().Name = "PrimarySchool";

            Assert.Equal("PrimaryKey", key.Relational().Name);
            Assert.Equal("PrimaryKey", ((IKey)key).Relational().Name);
            Assert.Equal("PrimarySchool", key.SqlServer().Name);
            Assert.Equal("PrimarySchool", ((IKey)key).SqlServer().Name);

            key.SqlServer().Name = null;

            Assert.Equal("PrimaryKey", key.Relational().Name);
            Assert.Equal("PrimaryKey", ((IKey)key).Relational().Name);
            Assert.Equal("PrimaryKey", key.SqlServer().Name);
            Assert.Equal("PrimaryKey", ((IKey)key).SqlServer().Name);
        }

        [Fact]
        public void Can_get_and_set_column_foreign_key_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            modelBuilder
                .Entity<Customer>()
                .Key(e => e.Id);

            var foreignKey = modelBuilder
                .Entity<Order>()
                .Reference<Customer>()
                .InverseReference()
                .ForeignKey<Order>(e => e.CustomerId)
                .Metadata;

            Assert.Equal("FK_Order_Customer_CustomerId", foreignKey.Relational().Name);
            Assert.Equal("FK_Order_Customer_CustomerId", ((IForeignKey)foreignKey).Relational().Name);
            Assert.Equal("FK_Order_Customer_CustomerId", foreignKey.SqlServer().Name);
            Assert.Equal("FK_Order_Customer_CustomerId", ((IForeignKey)foreignKey).SqlServer().Name);

            foreignKey.Relational().Name = "FK";

            Assert.Equal("FK", foreignKey.Relational().Name);
            Assert.Equal("FK", ((IForeignKey)foreignKey).Relational().Name);
            Assert.Equal("FK", foreignKey.SqlServer().Name);
            Assert.Equal("FK", ((IForeignKey)foreignKey).SqlServer().Name);

            foreignKey.SqlServer().Name = "KFC";

            Assert.Equal("FK", foreignKey.Relational().Name);
            Assert.Equal("FK", ((IForeignKey)foreignKey).Relational().Name);
            Assert.Equal("KFC", foreignKey.SqlServer().Name);
            Assert.Equal("KFC", ((IForeignKey)foreignKey).SqlServer().Name);

            foreignKey.SqlServer().Name = null;

            Assert.Equal("FK", foreignKey.Relational().Name);
            Assert.Equal("FK", ((IForeignKey)foreignKey).Relational().Name);
            Assert.Equal("FK", foreignKey.SqlServer().Name);
            Assert.Equal("FK", ((IForeignKey)foreignKey).SqlServer().Name);
        }

        [Fact]
        public void Can_get_and_set_index_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var index = modelBuilder
                .Entity<Customer>()
                .Index(e => e.Id)
                .Metadata;

            Assert.Equal("IX_Customer_Id", index.Relational().Name);
            Assert.Equal("IX_Customer_Id", ((IIndex)index).Relational().Name);
            Assert.Equal("IX_Customer_Id", index.SqlServer().Name);
            Assert.Equal("IX_Customer_Id", ((IIndex)index).SqlServer().Name);

            index.Relational().Name = "MyIndex";

            Assert.Equal("MyIndex", index.Relational().Name);
            Assert.Equal("MyIndex", ((IIndex)index).Relational().Name);
            Assert.Equal("MyIndex", index.SqlServer().Name);
            Assert.Equal("MyIndex", ((IIndex)index).SqlServer().Name);

            index.SqlServer().Name = "DexKnows";

            Assert.Equal("MyIndex", index.Relational().Name);
            Assert.Equal("MyIndex", ((IIndex)index).Relational().Name);
            Assert.Equal("DexKnows", index.SqlServer().Name);
            Assert.Equal("DexKnows", ((IIndex)index).SqlServer().Name);

            index.SqlServer().Name = null;

            Assert.Equal("MyIndex", index.Relational().Name);
            Assert.Equal("MyIndex", ((IIndex)index).Relational().Name);
            Assert.Equal("MyIndex", index.SqlServer().Name);
            Assert.Equal("MyIndex", ((IIndex)index).SqlServer().Name);
        }

        [Fact]
        public void Can_get_and_set_index_clustering()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var index = modelBuilder
                .Entity<Customer>()
                .Index(e => e.Id)
                .Metadata;

            Assert.Null(index.SqlServer().IsClustered);
            Assert.Null(((IIndex)index).SqlServer().IsClustered);

            index.SqlServer().IsClustered = true;

            Assert.True(index.SqlServer().IsClustered.Value);
            Assert.True(((IIndex)index).SqlServer().IsClustered.Value);

            index.SqlServer().IsClustered = null;

            Assert.Null(index.SqlServer().IsClustered);
            Assert.Null(((IIndex)index).SqlServer().IsClustered);
        }

        [Fact]
        public void Can_get_and_set_key_clustering()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var key = modelBuilder
                .Entity<Customer>()
                .Key(e => e.Id)
                .Metadata;

            Assert.Null(key.SqlServer().IsClustered);
            Assert.Null(((IKey)key).SqlServer().IsClustered);

            key.SqlServer().IsClustered = true;

            Assert.True(key.SqlServer().IsClustered.Value);
            Assert.True(((IKey)key).SqlServer().IsClustered.Value);

            key.SqlServer().IsClustered = null;

            Assert.Null(key.SqlServer().IsClustered);
            Assert.Null(((IKey)key).SqlServer().IsClustered);
        }

        [Fact]
        public void Can_get_and_set_sequence()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            Assert.Null(model.Relational().TryGetSequence("Foo"));
            Assert.Null(((IModel)model).Relational().TryGetSequence("Foo"));
            Assert.Null(model.SqlServer().TryGetSequence("Foo"));
            Assert.Null(((IModel)model).SqlServer().TryGetSequence("Foo"));

            var sequence = model.SqlServer().GetOrAddSequence("Foo");

            Assert.Null(model.Relational().TryGetSequence("Foo"));
            Assert.Null(((IModel)model).Relational().TryGetSequence("Foo"));
            Assert.Equal("Foo", model.SqlServer().TryGetSequence("Foo").Name);
            Assert.Equal("Foo", ((IModel)model).SqlServer().TryGetSequence("Foo").Name);

            Assert.Equal("Foo", sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(1, sequence.IncrementBy);
            Assert.Equal(1, sequence.StartValue);
            Assert.Null(sequence.MinValue);
            Assert.Null(sequence.MaxValue);
            Assert.Same(typeof(long), sequence.ClrType);

            model.SqlServer().AddOrReplaceSequence(new Sequence("Foo", null, 1729, 11, 2001, 2010, typeof(int)));

            Assert.Null(model.Relational().TryGetSequence("Foo"));

            sequence = model.SqlServer().GetOrAddSequence("Foo");

            Assert.Equal("Foo", sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(11, sequence.IncrementBy);
            Assert.Equal(1729, sequence.StartValue);
            Assert.Equal(2001, sequence.MinValue);
            Assert.Equal(2010, sequence.MaxValue);
            Assert.Same(typeof(int), sequence.ClrType);
        }

        [Fact]
        public void Can_get_and_set_sequence_with_schema_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            Assert.Null(model.Relational().TryGetSequence("Foo", "Smoo"));
            Assert.Null(((IModel)model).Relational().TryGetSequence("Foo", "Smoo"));
            Assert.Null(model.SqlServer().TryGetSequence("Foo", "Smoo"));
            Assert.Null(((IModel)model).SqlServer().TryGetSequence("Foo", "Smoo"));

            var sequence = model.SqlServer().GetOrAddSequence("Foo", "Smoo");

            Assert.Null(model.Relational().TryGetSequence("Foo", "Smoo"));
            Assert.Null(((IModel)model).Relational().TryGetSequence("Foo", "Smoo"));
            Assert.Equal("Foo", model.SqlServer().TryGetSequence("Foo", "Smoo").Name);
            Assert.Equal("Foo", ((IModel)model).SqlServer().TryGetSequence("Foo", "Smoo").Name);

            Assert.Equal("Foo", sequence.Name);
            Assert.Equal("Smoo", sequence.Schema);
            Assert.Equal(1, sequence.IncrementBy);
            Assert.Equal(1, sequence.StartValue);
            Assert.Null(sequence.MinValue);
            Assert.Null(sequence.MaxValue);
            Assert.Same(typeof(long), sequence.ClrType);

            model.SqlServer().AddOrReplaceSequence(new Sequence("Foo", "Smoo", 1729, 11, 2001, 2010, typeof(int)));

            Assert.Null(model.Relational().TryGetSequence("Foo", "Smoo"));

            sequence = model.SqlServer().GetOrAddSequence("Foo", "Smoo");

            Assert.Equal("Foo", sequence.Name);
            Assert.Equal("Smoo", sequence.Schema);
            Assert.Equal(11, sequence.IncrementBy);
            Assert.Equal(1729, sequence.StartValue);
            Assert.Equal(2001, sequence.MinValue);
            Assert.Equal(2010, sequence.MaxValue);
            Assert.Same(typeof(int), sequence.ClrType);
        }

        [Fact]
        public void Can_add_and_replace_sequence()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            model.SqlServer().AddOrReplaceSequence(new Sequence("Foo"));

            Assert.Null(model.Relational().TryGetSequence("Foo"));
            Assert.Null(((IModel)model).Relational().TryGetSequence("Foo"));
            Assert.Equal("Foo", model.SqlServer().TryGetSequence("Foo").Name);
            Assert.Equal("Foo", ((IModel)model).SqlServer().TryGetSequence("Foo").Name);

            var sequence = model.SqlServer().TryGetSequence("Foo");

            Assert.Equal("Foo", sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(1, sequence.IncrementBy);
            Assert.Equal(1, sequence.StartValue);
            Assert.Null(sequence.MinValue);
            Assert.Null(sequence.MaxValue);
            Assert.Same(typeof(long), sequence.ClrType);

            model.SqlServer().AddOrReplaceSequence(new Sequence("Foo", null, 1729, 11, 2001, 2010, typeof(int)));

            Assert.Null(model.Relational().TryGetSequence("Foo"));

            sequence = model.SqlServer().TryGetSequence("Foo");

            Assert.Equal("Foo", sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(11, sequence.IncrementBy);
            Assert.Equal(1729, sequence.StartValue);
            Assert.Equal(2001, sequence.MinValue);
            Assert.Equal(2010, sequence.MaxValue);
            Assert.Same(typeof(int), sequence.ClrType);
        }

        [Fact]
        public void Can_add_and_replace_sequence_with_schema_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            model.SqlServer().AddOrReplaceSequence(new Sequence("Foo", "Smoo"));

            Assert.Null(model.Relational().TryGetSequence("Foo", "Smoo"));
            Assert.Null(((IModel)model).Relational().TryGetSequence("Foo", "Smoo"));
            Assert.Equal("Foo", model.SqlServer().TryGetSequence("Foo", "Smoo").Name);
            Assert.Equal("Foo", ((IModel)model).SqlServer().TryGetSequence("Foo", "Smoo").Name);

            var sequence = model.SqlServer().TryGetSequence("Foo", "Smoo");

            Assert.Equal("Foo", sequence.Name);
            Assert.Equal("Smoo", sequence.Schema);
            Assert.Equal(1, sequence.IncrementBy);
            Assert.Equal(1, sequence.StartValue);
            Assert.Null(sequence.MinValue);
            Assert.Null(sequence.MaxValue);
            Assert.Same(typeof(long), sequence.ClrType);

            model.SqlServer().AddOrReplaceSequence(new Sequence("Foo", "Smoo", 1729, 11, 2001, 2010, typeof(int)));

            Assert.Null(model.Relational().TryGetSequence("Foo", "Smoo"));

            sequence = model.SqlServer().TryGetSequence("Foo", "Smoo");

            Assert.Equal("Foo", sequence.Name);
            Assert.Equal("Smoo", sequence.Schema);
            Assert.Equal(11, sequence.IncrementBy);
            Assert.Equal(1729, sequence.StartValue);
            Assert.Equal(2001, sequence.MinValue);
            Assert.Equal(2010, sequence.MaxValue);
            Assert.Same(typeof(int), sequence.ClrType);
        }

        [Fact]
        public void Can_get_multiple_sequences()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            model.Relational().AddOrReplaceSequence(new Sequence("Fibonacci"));
            model.SqlServer().AddOrReplaceSequence(new Sequence("Golomb"));

            var sequences = model.SqlServer().Sequences;

            Assert.Equal(2, sequences.Count);
            Assert.Contains(sequences, s => s.Name == "Fibonacci");
            Assert.Contains(sequences, s => s.Name == "Golomb");
        }

        [Fact]
        public void Can_get_multiple_sequences_when_overridden()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            model.Relational().AddOrReplaceSequence(new Sequence("Fibonacci", startValue: 1));
            model.SqlServer().AddOrReplaceSequence(new Sequence("Fibonacci", startValue: 3));
            model.SqlServer().AddOrReplaceSequence(new Sequence("Golomb"));

            var sequences = model.SqlServer().Sequences;

            Assert.Equal(2, sequences.Count);
            Assert.Contains(sequences, s => s.Name == "Golomb");

            var sequence = sequences.FirstOrDefault(s => s.Name == "Fibonacci");
            Assert.NotNull(sequence);
            Assert.Equal(3, sequence.StartValue);
        }

        [Fact]
        public void Can_get_and_set_value_generation_on_model()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            Assert.Null(model.SqlServer().IdentityStrategy);
            Assert.Null(((IModel)model).SqlServer().IdentityStrategy);

            model.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;

            Assert.Equal(SqlServerIdentityStrategy.SequenceHiLo, model.SqlServer().IdentityStrategy);
            Assert.Equal(SqlServerIdentityStrategy.SequenceHiLo, ((IModel)model).SqlServer().IdentityStrategy);

            model.SqlServer().IdentityStrategy = null;

            Assert.Null(model.SqlServer().IdentityStrategy);
            Assert.Null(((IModel)model).SqlServer().IdentityStrategy);
        }

        [Fact]
        public void Can_get_and_set_default_sequence_name_on_model()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            Assert.Null(model.SqlServer().HiLoSequenceName);
            Assert.Null(((IModel)model).SqlServer().HiLoSequenceName);

            model.SqlServer().HiLoSequenceName = "Tasty.Snook";

            Assert.Equal("Tasty.Snook", model.SqlServer().HiLoSequenceName);
            Assert.Equal("Tasty.Snook", ((IModel)model).SqlServer().HiLoSequenceName);

            model.SqlServer().HiLoSequenceName = null;

            Assert.Null(model.SqlServer().HiLoSequenceName);
            Assert.Null(((IModel)model).SqlServer().HiLoSequenceName);
        }

        [Fact]
        public void Can_get_and_set_pool_size_on_model()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            Assert.Null(model.SqlServer().HiLoSequencePoolSize);
            Assert.Null(((IModel)model).SqlServer().HiLoSequencePoolSize);

            model.SqlServer().HiLoSequencePoolSize = 88;

            Assert.Equal(88, model.SqlServer().HiLoSequencePoolSize);
            Assert.Equal(88, ((IModel)model).SqlServer().HiLoSequencePoolSize);

            model.SqlServer().HiLoSequencePoolSize = null;

            Assert.Null(model.SqlServer().HiLoSequencePoolSize);
            Assert.Null(((IModel)model).SqlServer().HiLoSequencePoolSize);
        }

        [Fact]
        public void Can_get_and_set_default_sequence_schema_on_model()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var model = modelBuilder.Model;

            Assert.Null(model.SqlServer().HiLoSequenceSchema);
            Assert.Null(((IModel)model).SqlServer().HiLoSequenceSchema);

            model.SqlServer().HiLoSequenceSchema = "Tasty.Snook";

            Assert.Equal("Tasty.Snook", model.SqlServer().HiLoSequenceSchema);
            Assert.Equal("Tasty.Snook", ((IModel)model).SqlServer().HiLoSequenceSchema);

            model.SqlServer().HiLoSequenceSchema = null;

            Assert.Null(model.SqlServer().HiLoSequenceSchema);
            Assert.Null(((IModel)model).SqlServer().HiLoSequenceSchema);
        }

        [Fact]
        public void Can_get_and_set_value_generation_on_property()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .Metadata;

            Assert.Null(property.SqlServer().IdentityStrategy);
            Assert.Null(((IProperty)property).SqlServer().IdentityStrategy);
            Assert.Null(property.RequiresValueGenerator);
            Assert.False(((IProperty)property).RequiresValueGenerator);

            property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;

            Assert.Equal(SqlServerIdentityStrategy.SequenceHiLo, property.SqlServer().IdentityStrategy);
            Assert.Equal(SqlServerIdentityStrategy.SequenceHiLo, ((IProperty)property).SqlServer().IdentityStrategy);
            Assert.Null(property.RequiresValueGenerator);

            property.SqlServer().IdentityStrategy = null;

            Assert.Null(property.SqlServer().IdentityStrategy);
            Assert.Null(((IProperty)property).SqlServer().IdentityStrategy);
            Assert.Null(property.RequiresValueGenerator);
        }

        [Fact]
        public void Can_get_and_set_value_generation_on_nullable_property()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.NullableInt)
                .ValueGeneratedOnAdd()
                .Metadata;

            Assert.Null(property.SqlServer().IdentityStrategy);
            Assert.Null(((IProperty)property).SqlServer().IdentityStrategy);
            Assert.Null(property.RequiresValueGenerator);
            Assert.False(((IProperty)property).RequiresValueGenerator);

            property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;

            Assert.Equal(SqlServerIdentityStrategy.SequenceHiLo, property.SqlServer().IdentityStrategy);
            Assert.Equal(SqlServerIdentityStrategy.SequenceHiLo, ((IProperty)property).SqlServer().IdentityStrategy);
            Assert.Null(property.RequiresValueGenerator);

            property.SqlServer().IdentityStrategy = null;

            Assert.Null(property.SqlServer().IdentityStrategy);
            Assert.Null(((IProperty)property).SqlServer().IdentityStrategy);
            Assert.Null(property.RequiresValueGenerator);
        }

        [Fact]
        public void Throws_setting_sequence_generation_for_invalid_type()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .Metadata;

            Assert.Equal(
                Strings.SequenceBadType("Name", typeof(Customer).FullName, "String"),
                Assert.Throws<ArgumentException>(
                    () => property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo).Message);
        }

        [Fact]
        public void Throws_setting_identity_generation_for_invalid_type()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .Metadata;

            Assert.Equal(
                Strings.IdentityBadType("Name", typeof(Customer).FullName, "String"),
                Assert.Throws<ArgumentException>(
                    () => property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.IdentityColumn).Message);
        }

        [Fact]
        public void Throws_setting_identity_generation_for_byte_property()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Byte)
                .Metadata;

            Assert.Equal(
                Strings.IdentityBadType("Byte", typeof(Customer).FullName, "Byte"),
                Assert.Throws<ArgumentException>(
                    () => property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.IdentityColumn).Message);
        }

        [Fact]
        public void Throws_setting_identity_generation_for_nullable_byte_property()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.NullableByte)
                .Metadata;

            Assert.Equal(
                Strings.IdentityBadType("NullableByte", typeof(Customer).FullName, "Nullable`1"),
                Assert.Throws<ArgumentException>(
                    () => property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.IdentityColumn).Message);
        }

        [Fact]
        public void Can_get_and_set_sequence_name_on_property()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .Metadata;

            Assert.Null(property.SqlServer().HiLoSequenceName);
            Assert.Null(((IProperty)property).SqlServer().HiLoSequenceName);

            property.SqlServer().HiLoSequenceName = "Snook";

            Assert.Equal("Snook", property.SqlServer().HiLoSequenceName);
            Assert.Equal("Snook", ((IProperty)property).SqlServer().HiLoSequenceName);

            property.SqlServer().HiLoSequenceName = null;

            Assert.Null(property.SqlServer().HiLoSequenceName);
            Assert.Null(((IProperty)property).SqlServer().HiLoSequenceName);
        }

        [Fact]
        public void Can_get_and_set_pool_size_on_property()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .Metadata;

            Assert.Null(property.SqlServer().HiLoSequencePoolSize);
            Assert.Null(((IProperty)property).SqlServer().HiLoSequencePoolSize);

            property.SqlServer().HiLoSequencePoolSize = 77;

            Assert.Equal(77, property.SqlServer().HiLoSequencePoolSize);
            Assert.Equal(77, ((IProperty)property).SqlServer().HiLoSequencePoolSize);

            property.SqlServer().HiLoSequencePoolSize = null;

            Assert.Null(property.SqlServer().HiLoSequencePoolSize);
            Assert.Null(((IProperty)property).SqlServer().HiLoSequencePoolSize);
        }

        [Fact]
        public void Can_get_and_set_sequence_schema_on_property()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .Metadata;

            Assert.Null(property.SqlServer().HiLoSequenceSchema);
            Assert.Null(((IProperty)property).SqlServer().HiLoSequenceSchema);

            property.SqlServer().HiLoSequenceSchema = "Tasty";

            Assert.Equal("Tasty", property.SqlServer().HiLoSequenceSchema);
            Assert.Equal("Tasty", ((IProperty)property).SqlServer().HiLoSequenceSchema);

            property.SqlServer().HiLoSequenceSchema = null;

            Assert.Null(property.SqlServer().HiLoSequenceSchema);
            Assert.Null(((IProperty)property).SqlServer().HiLoSequenceSchema);
        }

        [Fact]
        public void TryGetSequence_returns_null_if_property_is_not_configured_for_sequence_value_generation()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .Metadata;

            modelBuilder.Model.SqlServer().AddOrReplaceSequence(new Sequence("DaneelOlivaw"));

            Assert.Null(property.SqlServer().TryGetHiLoSequence());
            Assert.Null(((IProperty)property).SqlServer().TryGetHiLoSequence());

            property.SqlServer().HiLoSequenceName = "DaneelOlivaw";

            Assert.Null(property.SqlServer().TryGetHiLoSequence());
            Assert.Null(((IProperty)property).SqlServer().TryGetHiLoSequence());

            modelBuilder.Model.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.IdentityColumn;

            Assert.Null(property.SqlServer().TryGetHiLoSequence());
            Assert.Null(((IProperty)property).SqlServer().TryGetHiLoSequence());

            modelBuilder.Model.SqlServer().IdentityStrategy = null;
            property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.IdentityColumn;

            Assert.Null(property.SqlServer().TryGetHiLoSequence());
            Assert.Null(((IProperty)property).SqlServer().TryGetHiLoSequence());
        }

        [Fact]
        public void TryGetSequence_returns_sequence_property_is_marked_for_sequence_generation()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .Metadata;

            modelBuilder.Model.SqlServer().AddOrReplaceSequence(new Sequence("DaneelOlivaw"));
            property.SqlServer().HiLoSequenceName = "DaneelOlivaw";
            property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;

            Assert.Equal("DaneelOlivaw", property.SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("DaneelOlivaw", ((IProperty)property).SqlServer().TryGetHiLoSequence().Name);
        }

        [Fact]
        public void TryGetSequence_returns_sequence_property_is_marked_for_default_generation_and_model_is_marked_for_sequence_generation()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .Metadata;

            modelBuilder.Model.SqlServer().AddOrReplaceSequence(new Sequence("DaneelOlivaw"));
            modelBuilder.Model.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;
            property.SqlServer().HiLoSequenceName = "DaneelOlivaw";

            Assert.Equal("DaneelOlivaw", property.SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("DaneelOlivaw", ((IProperty)property).SqlServer().TryGetHiLoSequence().Name);
        }

        [Fact]
        public void TryGetSequence_returns_sequence_property_is_marked_for_sequence_generation_and_model_has_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .Metadata;

            modelBuilder.Model.SqlServer().AddOrReplaceSequence(new Sequence("DaneelOlivaw"));
            modelBuilder.Model.SqlServer().HiLoSequenceName = "DaneelOlivaw";
            property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;

            Assert.Equal("DaneelOlivaw", property.SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("DaneelOlivaw", ((IProperty)property).SqlServer().TryGetHiLoSequence().Name);
        }

        [Fact]
        public void TryGetSequence_returns_sequence_property_is_marked_for_default_generation_and_model_is_marked_for_sequence_generation_and_model_has_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .Metadata;

            modelBuilder.Model.SqlServer().AddOrReplaceSequence(new Sequence("DaneelOlivaw"));
            modelBuilder.Model.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;
            modelBuilder.Model.SqlServer().HiLoSequenceName = "DaneelOlivaw";

            Assert.Equal("DaneelOlivaw", property.SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("DaneelOlivaw", ((IProperty)property).SqlServer().TryGetHiLoSequence().Name);
        }

        [Fact]
        public void TryGetSequence_with_schema_returns_sequence_property_is_marked_for_sequence_generation()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .Metadata;

            modelBuilder.Model.SqlServer().AddOrReplaceSequence(new Sequence("DaneelOlivaw", "R"));
            property.SqlServer().HiLoSequenceName = "DaneelOlivaw";
            property.SqlServer().HiLoSequenceSchema = "R";
            property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;

            Assert.Equal("DaneelOlivaw", property.SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("DaneelOlivaw", ((IProperty)property).SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("R", property.SqlServer().TryGetHiLoSequence().Schema);
            Assert.Equal("R", ((IProperty)property).SqlServer().TryGetHiLoSequence().Schema);
        }

        [Fact]
        public void TryGetSequence_with_schema_returns_sequence_model_is_marked_for_sequence_generation()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .Metadata;

            modelBuilder.Model.SqlServer().AddOrReplaceSequence(new Sequence("DaneelOlivaw", "R"));
            modelBuilder.Model.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;
            property.SqlServer().HiLoSequenceName = "DaneelOlivaw";
            property.SqlServer().HiLoSequenceSchema = "R";

            Assert.Equal("DaneelOlivaw", property.SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("DaneelOlivaw", ((IProperty)property).SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("R", property.SqlServer().TryGetHiLoSequence().Schema);
            Assert.Equal("R", ((IProperty)property).SqlServer().TryGetHiLoSequence().Schema);
        }

        [Fact]
        public void TryGetSequence_with_schema_returns_sequence_property_is_marked_for_sequence_generation_and_model_has_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .Metadata;

            modelBuilder.Model.SqlServer().AddOrReplaceSequence(new Sequence("DaneelOlivaw", "R"));
            modelBuilder.Model.SqlServer().HiLoSequenceName = "DaneelOlivaw";
            modelBuilder.Model.SqlServer().HiLoSequenceSchema = "R";
            property.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;

            Assert.Equal("DaneelOlivaw", property.SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("DaneelOlivaw", ((IProperty)property).SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("R", property.SqlServer().TryGetHiLoSequence().Schema);
            Assert.Equal("R", ((IProperty)property).SqlServer().TryGetHiLoSequence().Schema);
        }

        [Fact]
        public void TryGetSequence_with_schema_returns_sequence_model_is_marked_for_sequence_generation_and_model_has_name()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());

            var property = modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .Metadata;

            modelBuilder.Model.SqlServer().AddOrReplaceSequence(new Sequence("DaneelOlivaw", "R"));
            modelBuilder.Model.SqlServer().IdentityStrategy = SqlServerIdentityStrategy.SequenceHiLo;
            modelBuilder.Model.SqlServer().HiLoSequenceName = "DaneelOlivaw";
            modelBuilder.Model.SqlServer().HiLoSequenceSchema = "R";

            Assert.Equal("DaneelOlivaw", property.SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("DaneelOlivaw", ((IProperty)property).SqlServer().TryGetHiLoSequence().Name);
            Assert.Equal("R", property.SqlServer().TryGetHiLoSequence().Schema);
            Assert.Equal("R", ((IProperty)property).SqlServer().TryGetHiLoSequence().Schema);
        }

        private class Customer
        {
            public int Id { get; set; }
            public int? NullableInt { get; set; }
            public string Name { get; set; }
            public byte Byte { get; set; }
            public byte? NullableByte { get; set; }
        }

        private class Order
        {
            public int OrderId { get; set; }
            public int CustomerId { get; set; }
        }
    }
}