using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Domain
{
    public class StringArg : Arg
    {
        private const int ValueGroupIndex = 1;
        private readonly string _name;

        public StringArg(string name)
        {
            _name = name;
        }

        public Maybe<object> Value(string args)
        {
            return new Regex(@$"-{_name}(\S+)")
                .Match(args)
                .Groups[ValueGroupIndex]
                .Value;
        }
    }
}