using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Indexer
{
    public class IndexerTest
    {
        private readonly Indexer indexer = new Indexer();

        [Fact]
        public void ShouldGetItemFromObjectWhenValidIndexProvided()
        {
            string country = indexer[0];

            country.Should().Be("Bangladesh");
        }

        [Fact]
        public void ShouldAddNewCountry()
        {
            string country = "USA";
            indexer[0] = country;

            string returnCountry = indexer[0];

            country.Should().Be("USA");
        }

        [Fact]
        public void ShouldReturnIndexWhenValidCountryNameProvided()
        {
            int index = indexer["India"];

            index.Should().Be(1);
        }
    }
}
