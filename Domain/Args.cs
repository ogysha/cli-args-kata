using System;
using CSharpFunctionalExtensions;

namespace Domain
{
    public class Args
    {
        private readonly string _args;
        private readonly Schema _schema;

        public Args(string args, Schema schema)
        {
            _args = args ?? throw new ArgumentNullException(nameof(args));
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        public Maybe<bool> Boolean(string arg)
        {
            return _schema.BoolArg(arg)
                .Map(foundArg => foundArg.Value(_args))
                .Map(maybeValue => maybeValue.Value)
                .Map(value => (bool) value);
        }

        public Maybe<int> Integer(string arg)
        {
            return _schema.IntArg(arg)
                .Map(foundArg => foundArg.Value(_args))
                .Map(maybeValue => maybeValue.Value)
                .Map(maybeObjectResult => (Maybe<int>) maybeObjectResult)
                .Unwrap();
        }

        public Maybe<string> String(string arg)
        {
            return _schema.StringArg(arg)
                .Map(foundArg => foundArg.Value(_args))
                .Map(maybeValue => maybeValue.Value)
                .Map(value => (string) value);
        }
    }
}