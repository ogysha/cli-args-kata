using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Domain
{
    public class IntArg : Arg
    {
        private const int ValueGroupIndex = 1;
        private readonly string _name;

        public IntArg(string name)
        {
            _name = name;
        }

        public Maybe<object> Value(string args)
        {
            return int.TryParse(
                new Regex(@$"-{_name}(\S+)").Match(args).Groups[ValueGroupIndex].Value,
                out var value
            )
                ? Maybe<int>.From(value)
                : Maybe<int>.None;
        }
    }
}