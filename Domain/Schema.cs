using System;
using System.Linq;
using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Domain
{
    public class Schema
    {
        private const string ArgSeparator = ",";
        private readonly char[] _allowedArgSchemaSuffixes = {'#', '*'};
        private readonly string[] _schemaArgs;
        private readonly Regex _schemaArgsRegex = new Regex(@"(([a-z]+)[#\*]?)+");

        public Schema(string schema)
        {
            var matchedArgs = _schemaArgsRegex.Matches(schema);
            var args = schema.Split(ArgSeparator);

            if (matchedArgs.Count != args.Length)
            {
                throw new ArgumentException(nameof(schema));
            }

            if (matchedArgs
                .Select(match => match.Groups[1].Value)
                .Select(argSchema => argSchema.TrimEnd(_allowedArgSchemaSuffixes))
                .Distinct()
                .Count() != args.Length)
            {
                throw new ArgumentException("Schema contains duplicate args");
            }

            _schemaArgs = args;
        }

        public Maybe<Arg> IntArg(string arg)
        {
            return _schemaArgs
                .Where(schemaArg => schemaArg.Equals($"{arg}#"))
                .Select(foundArg => Maybe<Arg>.From(new IntArg(arg)))
                .DefaultIfEmpty(Maybe<Arg>.None)
                .Single();
        }

        public Maybe<Arg> BoolArg(string arg)
        {
            return _schemaArgs
                .Where(schemaArg => schemaArg.Equals(arg))
                .Select(foundArg => Maybe<Arg>.From(new BoolArg(arg)))
                .DefaultIfEmpty(Maybe<Arg>.None)
                .Single();
        }

        public Maybe<Arg> StringArg(string arg)
        {
            return _schemaArgs
                .Where(schemaArg => schemaArg.Equals($"{arg}*"))
                .Select(foundArg => Maybe<Arg>.From(new StringArg(arg)))
                .DefaultIfEmpty(Maybe<Arg>.None)
                .Single();
        }
    }
}