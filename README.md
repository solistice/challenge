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

# 6 letter words

There's a file in the root of the repository, input.txt, that contains words of varying lengths (1 to 6 characters).

Your objective is to show all combinations of those words that together form a word of 6 characters. That combination must also be present in input.txt
E.g.:  
<code>
foobar  
fo  
obar  
</code>

should result in the ouput:  
<code>
fo+obar=foobar
</code>

You can start by only supporting combinations of two words and improve the algorithm at the end of the exercise to support any combinations.

Treat this exercise as if you were writing production code; think unit tests, SOLID, clean code and avoid primitive obsession. Be mindful of changing requirements like a different maximum combination length, or a different source of the input data.

The solution must be stored in a git repo. After the repo is cloned, the application should be able to run with one command / script.

Don't spend too much time on this.
