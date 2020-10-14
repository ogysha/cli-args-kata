using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Domain
{
    public class BoolArg : Arg
    {
        private readonly Regex _boolArgRegex;

        public BoolArg(string name)
        {
            _boolArgRegex = new Regex($@"-{name}(\s+|$)");
        }

        public Maybe<object> Value(string args)
        {
            return _boolArgRegex.IsMatch(args);
        }
    }
}