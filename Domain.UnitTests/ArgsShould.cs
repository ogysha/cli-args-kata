using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Domain;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class ArgsShould
    {
        [Theory]
        [ClassData(typeof(ArgsTestData))]
        public void Parse_cli_args(
            Args args,
            string boolArg,
            string intArg,
            string stringArg,
            IEnumerable<Maybe<object>> expectedValues)
        {
            var actual = new List<Maybe<object>>
            {
                args.Boolean(boolArg), args.Integer(intArg), args.String(stringArg)
            };
            Assert.Equal(expectedValues, actual);
        }
    }
}