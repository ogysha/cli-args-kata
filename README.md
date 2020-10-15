# Kata: CLI arguments

Parse CLI args into a convenient data structure:  
Example:

The schema `"d#,b,l*"` specifies an int arg `-d`, a bool arg `-b`, and a string arg `-l`  
So given args `-d10 -b -lINFO`
* the arg `-d` has the value `10`
* the arg `-b` has the value `true`
* the arg `-l` has the value `"INFO"`

```c#
Args args = new Args("-d10 -b -lINFO", new Schema("d#,b,l*"));

// Fetch arg's value
Maybe<int> maybeIntArg = args.Integer("d")
maybeIntArg.HasValue             // True
maybeIntArg.Value                // 10

// Can't fetch for non existing arg
Maybe<string> maybeStringArg = args.String("p")
maybeStringArg.HasValue          // False
```