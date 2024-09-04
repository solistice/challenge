# Comments

The program can be run from commandline or can be run through the solution.
To run from commandline, do the following steps:

- Clone the repository
- Go the the challenge/ConsoleApp folder
- Execute `dotnet run ./input.txt <optional-target-length> <optional-maximum-number-of-combinations>`

Some remarks:

- Optional target length sets the length of the word to search for. If this is omitted, it will default to 6.
- Optional maximum number of combinations will limit the prefixes that are matched together. Example: `fo+ob+ar=foobar` will be ignored if maximum is set to 2 words. If this is omitted, it will also default to 6.
- (`<optional-maximum-number-of-combinations>` can not be used if `<optional-target-length>` is not used, for simplicity's and time's sake)
