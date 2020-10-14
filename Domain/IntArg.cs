using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Domain
{
    public class IntArg : Arg
    {
        private const int ValueGroupIndex = 1;
        private readonly Regex _intArgRegex;

        public IntArg(string name)
        {
            _intArgRegex = new Regex(@$"-{name}(\S+)");
        }

        public Maybe<object> Value(string args)
        {
            return int.TryParse(_intArgRegex.Match(args).Groups[ValueGroupIndex].Value, out var value)
                ? Maybe<int>.From(value)
                : Maybe<int>.None;
        }
    }
}