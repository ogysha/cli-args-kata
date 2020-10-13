using System.Collections;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Domain;

namespace Tests.TestData
{
    public class ArgsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Args(@"-d10 -b -m..\tmp\temp.txt -wC:\Temp", new Schema("d#,b,w*,f,m*")),
                "b",
                "d",
                "m",
                new List<Maybe<object>>
                {
                    Maybe<bool>.From(true), Maybe<int>.From(10), Maybe<string>.From(@"..\tmp\temp.txt")
                }
            };
            yield return new object[]
            {
                new Args(@"-d10ssss -b -m..\tmp\temp.txt -j23234 -wC:\Temp", new Schema("d#,b,w*,f,m*,j#")),
                "b",
                "d",
                "m",
                new List<Maybe<object>>
                {
                    Maybe<bool>.From(true), Maybe<int>.None, Maybe<string>.From(@"..\tmp\temp.txt")
                }
            };
            yield return new object[]
            {
                new Args(@"-d10ssss -b -m..\tmp\temp.txt -j23234 -wC:\Temp", new Schema("d#,b,w*,f,m*,j#")),
                "f",
                "j",
                "w",
                new List<Maybe<object>>
                {
                    Maybe<bool>.From(false), Maybe<int>.From(23234), Maybe<string>.From(@"C:\Temp")
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}