using System;
using Domain;
using Xunit;

namespace Tests
{
    public class SchemaShould
    {
        [Fact]
        public void Fail_if_no_schema_provided()
        {
            Assert.Throws<ArgumentNullException>(() => new Schema(null));
        }

        [Theory]
        [InlineData("    ")]
        [InlineData("blaaa,*-,,")]
        [InlineData("d#,d,c,d#,")]
        [InlineData("d# ,d,      c,  d#,")]
        public void Fail_if_not_valid_schema_provided(string schema)
        {
            Assert.Throws<ArgumentException>(() => new Schema(schema));
        }

        [Theory]
        [InlineData("b")]
        [InlineData("d#,j,f*")]
        [InlineData("d#,j,f*,w*,t*,m#,b")]
        public void Create_if_valid_schema_provided(string schema)
        {
            Assert.NotNull(new Schema(schema));
        }
    }
}