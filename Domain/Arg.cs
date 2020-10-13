using CSharpFunctionalExtensions;

namespace Domain
{
    public interface Arg
    {
        Maybe<object> Value(string args);
    }
}