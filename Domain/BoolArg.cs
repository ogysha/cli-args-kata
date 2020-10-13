using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Domain
{
    public class BoolArg : Arg
    {
        private readonly string _name;

        public BoolArg(string name)
        {
            _name = name;
        }

        public Maybe<object> Value(string args)
        {
            return new Regex($@"-{_name}(\s+|$)").IsMatch(args);
        }
    }
}