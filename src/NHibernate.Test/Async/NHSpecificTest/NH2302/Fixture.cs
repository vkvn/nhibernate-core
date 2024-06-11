﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Data;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping;
using NHibernate.SqlTypes;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH2302
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		protected override void AddMappings(Configuration configuration)
		{
			base.AddMappings(configuration);

			foreach (var cls in configuration.ClassMappings)
			{
				foreach (var prop in cls.PropertyIterator)
				{
					foreach (var col in prop.ColumnIterator)
					{
						if (col is Column column && column.SqlType == "nvarchar(max)")
						{
							column.SqlType = Dialect.GetLongestTypeName(DbType.String);
						}
					}
				}
			}
		}

		protected override void OnTearDown()
        {
            CleanUp();

            base.OnTearDown();
        }

        [Test]
        public async Task StringHugeLengthAsync()
        {
			if (Sfi.ConnectionProvider.Driver is OdbcDriver || Dialect is MsSqlCeDialect)
				Assert.Ignore("NH-4065, not fixed for Odbc and MsSqlCe");

			if (Dialect.GetTypeName(SqlTypeFactory.GetString(10000)) != Dialect.GetLongestTypeName(DbType.String))
				Assert.Ignore("Current dialect does support limited strings of 10 000 characters");

            int id;
            // buildup a string the exceed the mapping
            string str = GetFixedLengthString12000();

            using (ISession sess = OpenSession())
            using (ITransaction tx = sess.BeginTransaction())
            {
                // create and save the entity
                StringLengthEntity entity = new StringLengthEntity();
                entity.StringHugeLength = str;
                await (sess.SaveAsync(entity));
                await (tx.CommitAsync());
                id = entity.ID;
            }

            using (ISession sess = OpenSession())
            using (ITransaction tx = sess.BeginTransaction())
            {
                StringLengthEntity loaded = await (sess.GetAsync<StringLengthEntity>(id));
                Assert.IsNotNull(loaded);
                Assert.AreEqual(12000, loaded.StringHugeLength.Length);
                Assert.AreEqual(str, loaded.StringHugeLength);
                await (tx.CommitAsync());
            }
        }

        [Test]
        public async Task BlobSqlTypeAsync()
        {
            int id;
            // buildup a string the exceed the mapping
            string str = GetFixedLengthString12000();

            using (ISession sess = OpenSession())
            using (ITransaction tx = sess.BeginTransaction())
            {
                // create and save the entity
                StringLengthEntity entity = new StringLengthEntity();
                entity.BlobSqlType = str;
                await (sess.SaveAsync(entity));
                await (tx.CommitAsync());
                id = entity.ID;
            }

            using (ISession sess = OpenSession())
            using (ITransaction tx = sess.BeginTransaction())
            {
                StringLengthEntity loaded = await (sess.GetAsync<StringLengthEntity>(id));
                Assert.IsNotNull(loaded);
                Assert.AreEqual(12000, loaded.BlobSqlType.Length);
                Assert.AreEqual(str, loaded.BlobSqlType);
                await (tx.CommitAsync());
            }
        }

				[Test]
				public async Task BlobWithLengthAsync()
				{
					int id;
					// buildup a string the exceed the mapping
					string str = GetFixedLengthString12000();

					using (ISession sess = OpenSession())
					using (ITransaction tx = sess.BeginTransaction())
					{
						// create and save the entity
						StringLengthEntity entity = new StringLengthEntity();
						entity.BlobLength = str;
						await (sess.SaveAsync(entity));
						await (tx.CommitAsync());
						id = entity.ID;
					}

					using (ISession sess = OpenSession())
					using (ITransaction tx = sess.BeginTransaction())
					{
						StringLengthEntity loaded = await (sess.GetAsync<StringLengthEntity>(id));
						Assert.IsNotNull(loaded);
						Assert.AreEqual(12000, loaded.BlobLength.Length);
						Assert.AreEqual(str, loaded.BlobLength);
						await (tx.CommitAsync());
					}
				}

				[Test]
				public async Task BlobWithoutLengthAsync()
				{
					if (Dialect is MySQLDialect)
						Assert.Ignore("Not fixed for MySQLDialect, still generating a varchar(255) column for StringClob without length");
					int id;
					// buildup a string the exceed the mapping
					string str = GetFixedLengthString12000();

					using (ISession sess = OpenSession())
					using (ITransaction tx = sess.BeginTransaction())
					{
						// create and save the entity
						StringLengthEntity entity = new StringLengthEntity();
						entity.Blob = str;
						await (sess.SaveAsync(entity));
						await (tx.CommitAsync());
						id = entity.ID;
					}

					using (ISession sess = OpenSession())
					using (ITransaction tx = sess.BeginTransaction())
					{
						StringLengthEntity loaded = await (sess.GetAsync<StringLengthEntity>(id));
						Assert.IsNotNull(loaded);
						Assert.AreEqual(12000, loaded.Blob.Length);
						Assert.AreEqual(str, loaded.Blob);
						await (tx.CommitAsync());
					}
				}

        private void CleanUp()
        {
            using (ISession session = OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Delete("from StringLengthEntity");
                tx.Commit();
            }
        }

        private static string GetFixedLengthString12000()
        {
            return new string('a', 12000);
        }
	}
}
