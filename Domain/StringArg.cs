using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Domain
{
    public class StringArg : Arg
    {
        private const int StringValueGroupIndex = 1;
        private readonly Regex _stringArgRegex;

        public StringArg(string name)
        {
            _stringArgRegex = new Regex(@$"-{name}(\S+)");
        }

        public Maybe<object> Value(string args)
        {
            return _stringArgRegex
                .Match(args)
                .Groups[StringValueGroupIndex]
                .Value;
        }
    }
}