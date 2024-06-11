﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Util;
using NUnit.Framework;

namespace NHibernate.Test.SubselectFetchTest
{
	using System.Threading.Tasks;
	[TestFixture]
	public class SubselectFetchFixtureAsync : TestCase
	{
		protected override void Configure(Configuration configuration)
		{
			configuration.SetProperty(Cfg.Environment.GenerateStatistics, "true");
		}

		[Test]
		public async Task SubselectFetchHqlAsync()
		{
			ISession s = OpenSession();
			ITransaction t = s.BeginTransaction();
			Parent p = new Parent("foo");
			p.Children.Add(new Child("foo1"));
			p.Children.Add(new Child("foo2"));
			Parent q = new Parent("bar");
			q.Children.Add(new Child("bar1"));
			q.Children.Add(new Child("bar2"));
			ArrayHelper.AddAll(q.MoreChildren, p.Children);
			await (s.SaveAsync(p));
			await (s.SaveAsync(q));
			await (t.CommitAsync());
			s.Close();

			s = OpenSession();
			t = s.BeginTransaction();

			Sfi.Statistics.Clear();

			IList parents = await (s.CreateQuery("from Parent where name between 'bar' and 'foo' order by name desc")
				.ListAsync());
			p = (Parent) parents[0];
			q = (Parent) parents[1];

			Assert.IsFalse(NHibernateUtil.IsInitialized(p.Children));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.Children));

			Assert.AreEqual(2, p.Children.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(p.Children[0]));

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.Children));

			Assert.AreEqual(2, q.Children.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.Children[0]));

			Assert.IsFalse(NHibernateUtil.IsInitialized(p.MoreChildren));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.MoreChildren));

			Assert.AreEqual(0, p.MoreChildren.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.MoreChildren));

			Assert.AreEqual(2, q.MoreChildren.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.MoreChildren[0]));

			Assert.AreEqual(3, Sfi.Statistics.PrepareStatementCount);

			Child c = (Child) p.Children[0];
			await (NHibernateUtil.InitializeAsync(c.Friends));

			await (s.DeleteAsync(p));
			await (s.DeleteAsync(q));

			await (t.CommitAsync());
			s.Close();
		}

		[Test]
		public async Task SubselectFetchNamedParamAsync()
		{
			ISession s = OpenSession();
			ITransaction t = s.BeginTransaction();
			Parent p = new Parent("foo");
			p.Children.Add(new Child("foo1"));
			p.Children.Add(new Child("foo2"));
			Parent q = new Parent("bar");
			q.Children.Add(new Child("bar1"));
			q.Children.Add(new Child("bar2"));
			ArrayHelper.AddAll(q.MoreChildren, p.Children);
			await (s.SaveAsync(p));
			await (s.SaveAsync(q));
			await (t.CommitAsync());
			s.Close();

			s = OpenSession();
			t = s.BeginTransaction();

			Sfi.Statistics.Clear();

			IList parents = await (s.CreateQuery("from Parent where name between :bar and :foo order by name desc")
				.SetParameter("bar", "bar")
				.SetParameter("foo", "foo")
				.ListAsync());
			p = (Parent) parents[0];
			q = (Parent) parents[1];

			Assert.IsFalse(NHibernateUtil.IsInitialized(p.Children));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.Children));

			Assert.AreEqual(2, p.Children.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(p.Children[0]));

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.Children));

			Assert.AreEqual(2, q.Children.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.Children[0]));

			Assert.IsFalse(NHibernateUtil.IsInitialized(p.MoreChildren));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.MoreChildren));

			Assert.AreEqual(0, p.MoreChildren.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.MoreChildren));

			Assert.AreEqual(2, q.MoreChildren.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.MoreChildren[0]));

			Assert.AreEqual(3, Sfi.Statistics.PrepareStatementCount);

			Child c = (Child) p.Children[0];
			await (NHibernateUtil.InitializeAsync(c.Friends));

			await (s.DeleteAsync(p));
			await (s.DeleteAsync(q));

			await (t.CommitAsync());
			s.Close();
		}

		[Test]
		public async Task SubselectFetchPosParamAsync()
		{
			ISession s = OpenSession();
			ITransaction t = s.BeginTransaction();
			Parent p = new Parent("foo");
			p.Children.Add(new Child("foo1"));
			p.Children.Add(new Child("foo2"));
			Parent q = new Parent("bar");
			q.Children.Add(new Child("bar1"));
			q.Children.Add(new Child("bar2"));
			ArrayHelper.AddAll(q.MoreChildren, p.Children);
			await (s.SaveAsync(p));
			await (s.SaveAsync(q));
			await (t.CommitAsync());
			s.Close();

			s = OpenSession();
			t = s.BeginTransaction();

			Sfi.Statistics.Clear();

			IList parents = await (s.CreateQuery("from Parent where name between ? and ? order by name desc")
				.SetParameter(0, "bar")
				.SetParameter(1, "foo")
				.ListAsync());
			p = (Parent) parents[0];
			q = (Parent) parents[1];

			Assert.IsFalse(NHibernateUtil.IsInitialized(p.Children));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.Children));

			Assert.AreEqual(2, p.Children.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(p.Children[0]));

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.Children));

			Assert.AreEqual(2, q.Children.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.Children[0]));

			Assert.IsFalse(NHibernateUtil.IsInitialized(p.MoreChildren));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.MoreChildren));

			Assert.AreEqual(0, p.MoreChildren.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.MoreChildren));

			Assert.AreEqual(2, q.MoreChildren.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.MoreChildren[0]));

			Assert.AreEqual(3, Sfi.Statistics.PrepareStatementCount);

			Child c = (Child) p.Children[0];
			await (NHibernateUtil.InitializeAsync(c.Friends));

			await (s.DeleteAsync(p));
			await (s.DeleteAsync(q));

			await (t.CommitAsync());
			s.Close();
		}

		[Test]
		public async Task SubselectFetchWithLimitAsync()
		{
			ISession s = OpenSession();
			ITransaction t = s.BeginTransaction();
			Parent p = new Parent("foo");
			p.Children.Add(new Child("foo1"));
			p.Children.Add(new Child("foo2"));
			Parent q = new Parent("bar");
			q.Children.Add(new Child("bar1"));
			q.Children.Add(new Child("bar2"));
			Parent r = new Parent("aaa");
			r.Children.Add(new Child("aaa1"));
			await (s.SaveAsync(p));
			await (s.SaveAsync(q));
			await (s.SaveAsync(r));
			await (t.CommitAsync());
			s.Close();

			s = OpenSession();
			t = s.BeginTransaction();

			Sfi.Statistics.Clear();

			IList parents = await (s.CreateQuery("from Parent order by name desc")
				.SetMaxResults(2)
				.ListAsync());
			p = (Parent) parents[0];
			q = (Parent) parents[1];
			Assert.IsFalse(NHibernateUtil.IsInitialized(p.Children));
			Assert.IsFalse(NHibernateUtil.IsInitialized(p.MoreChildren));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.Children));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.MoreChildren));
			Assert.AreEqual(0, p.MoreChildren.Count);
			Assert.AreEqual(2, p.Children.Count);
			Assert.IsTrue(NHibernateUtil.IsInitialized(q.Children));
			Assert.IsTrue(NHibernateUtil.IsInitialized(q.MoreChildren));

			Assert.AreEqual(3, Sfi.Statistics.PrepareStatementCount);

			r = (Parent) await (s.GetAsync(typeof(Parent), r.Name));
			Assert.IsTrue(NHibernateUtil.IsInitialized(r.Children)); // The test for True is the test of H3.2
			Assert.IsFalse(NHibernateUtil.IsInitialized(r.MoreChildren));
			Assert.AreEqual(1, r.Children.Count);
			Assert.AreEqual(0, r.MoreChildren.Count);

			await (s.DeleteAsync(p));
			await (s.DeleteAsync(q));
			await (s.DeleteAsync(r));

			await (t.CommitAsync());
			s.Close();
		}

		[Test]
		public async Task ManyToManyCriteriaJoinAsync()
		{
			ISession s = OpenSession();
			ITransaction t = s.BeginTransaction();
			Parent p = new Parent("foo");
			p.Children.Add(new Child("foo1"));
			p.Children.Add(new Child("foo2"));
			Parent q = new Parent("bar");
			q.Children.Add(new Child("bar1"));
			q.Children.Add(new Child("bar2"));
			ArrayHelper.AddAll(q.MoreChildren, p.Children);
			await (s.SaveAsync(p));
			await (s.SaveAsync(q));
			await (t.CommitAsync());
			s.Close();

			s = OpenSession();
			t = s.BeginTransaction();

			await (s.CreateCriteria(typeof(Parent))
				.AddOrder(Order.Desc("Name"))
				// H3 has this after CreateCriteria("Friends"), but it's not yet supported in NH
				.CreateCriteria("MoreChildren")
				.CreateCriteria("Friends")
				.ListAsync());

			IList parents = await (s.CreateCriteria(typeof(Parent))
				.Fetch("MoreChildren")
				.Fetch("MoreChildren.Friends")
				.AddOrder(Order.Desc("Name"))
				.ListAsync());

			await (s.DeleteAsync(parents[0]));
			await (s.DeleteAsync(parents[1]));

			await (t.CommitAsync());
			s.Close();
		}

		[Test]
		public async Task SubselectFetchCriteriaAsync()
		{
			ISession s = OpenSession();
			ITransaction t = s.BeginTransaction();
			Parent p = new Parent("foo");
			p.Children.Add(new Child("foo1"));
			p.Children.Add(new Child("foo2"));
			Parent q = new Parent("bar");
			q.Children.Add(new Child("bar1"));
			q.Children.Add(new Child("bar2"));
			ArrayHelper.AddAll(q.MoreChildren, p.Children);
			await (s.SaveAsync(p));
			await (s.SaveAsync(q));
			await (t.CommitAsync());
			s.Close();

			s = OpenSession();
			t = s.BeginTransaction();

			Sfi.Statistics.Clear();

			IList parents = await (s.CreateCriteria(typeof(Parent))
				.Add(Expression.Between("Name", "bar", "foo"))
				.AddOrder(Order.Desc("Name"))
				.ListAsync());
			p = (Parent) parents[0];
			q = (Parent) parents[1];

			Assert.IsFalse(NHibernateUtil.IsInitialized(p.Children));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.Children));

			Assert.AreEqual(2, p.Children.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(p.Children[0]));

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.Children));

			Assert.AreEqual(2, q.Children.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.Children[0]));

			Assert.IsFalse(NHibernateUtil.IsInitialized(p.MoreChildren));
			Assert.IsFalse(NHibernateUtil.IsInitialized(q.MoreChildren));

			Assert.AreEqual(0, p.MoreChildren.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.MoreChildren));

			Assert.AreEqual(2, q.MoreChildren.Count);

			Assert.IsTrue(NHibernateUtil.IsInitialized(q.MoreChildren[0]));

			Assert.AreEqual(3, Sfi.Statistics.PrepareStatementCount);

			Child c = (Child) p.Children[0];
			await (NHibernateUtil.InitializeAsync(c.Friends));

			await (s.DeleteAsync(p));
			await (s.DeleteAsync(q));

			await (t.CommitAsync());
			s.Close();
		}

		protected override string[] Mappings
		{
			get { return new string[] {"SubselectFetchTest.ParentChild.hbm.xml"}; }
		}

		protected override string MappingsAssembly
		{
			get { return "NHibernate.Test"; }
		}

		//public override string CacheConcurrencyStrategy
		//{
		//    get { return null; }
		//}
	}
}
