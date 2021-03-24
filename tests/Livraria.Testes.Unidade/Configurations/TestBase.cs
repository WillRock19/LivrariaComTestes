using AutoBogus;
using Autofac.Extras.FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Livraria.Testes.Unidade.Configurations
{
    internal class TestBase
    {
        protected AutoFake _autoFake;

        public TestBase()
        {
            AutoFaker.Configure(builder =>
            {
                builder.WithRecursiveDepth(1);
            });

            _autoFake = new AutoFake();
        }

        [OneTimeSetUp]
        public void AllTestsOneTimeSetUp()
        {
            AssertionOptions.AssertEquivalencyUsing(options =>
            {
                options.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, 2000)).WhenTypeIs<DateTime>();
                options.Using<DateTimeOffset>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, 2000)).WhenTypeIs<DateTimeOffset>();
                return options;
            });
        }

        protected bool ObjectsAreEquivalent<T>(T originalObject, T objectToCompare)
        {
            try
            {
                originalObject.Should().BeEquivalentTo(objectToCompare);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
