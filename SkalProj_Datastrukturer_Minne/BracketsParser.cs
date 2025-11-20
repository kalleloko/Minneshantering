
namespace SkalProj_Datastrukturer_Minne;

public class BracketsParser
{
    private string _s;

    private List<BracketMatch> _parsed = [];

    private static (char open, char close)[] _bracketPairs =
    {
        ('(', ')'),
        ('[', ']'),
        ('{', '}')
    };

    private bool _didParse = false;

    public string String
    {
        get { return _s; }
        set
        {
            _didParse = false;
            _parsed = [];
            _s = value;
        }
    }

    private static char[] _openingBrackets = [];

    public static char[] OpeningBrackets
    {
        get { return _bracketPairs.Select(pair => pair.open).ToArray(); }
        private set { _openingBrackets = value; }
    }

    private static char[] _closingBrackets = [];

    public static char[] ClosingBrackets
    {
        get { return _bracketPairs.Select(pair => pair.close).ToArray(); }
        private set { _closingBrackets = value; }
    }



    public BracketsParser(string input)
    {
        _s = input;
    }

    public BracketsParser()
    {
        _s = string.Empty;
    }

    /// <summary>
    /// Parse the string (if not yet cached) using a stack holding all
    /// opened bracket groups.
    /// 
    /// When an opening bracket is found, a new BracketMatch is pushed
    /// to the stack, and when correct closing bracket is found, the
    /// BracketMatch is popped and put in the _parsed list, which
    /// is returned when done.
    /// </summary>
    /// <returns>A list of BracketMatch, containing all groups of brackets</returns>
    /// <exception cref="FormatException">When string is not well formatted</exception>
    public List<BracketMatch> Parse()
    {
        // Caching. Kan detta göras snyggare?
        if (_didParse)
        {
            return _parsed;
        }

        Stack<BracketMatch> openedBrackets = [];
        int pos = 0;
        foreach (char c in _s)
        {
            if (MatchWithClosingBracket(c) is char closingBracket)
            {
                openedBrackets.Push(new BracketMatch(pos, closingBracket));
            }
            else if (IsClosingBracket(c))
            {
                BracketMatch currentBracketMatch;
                try
                {
                    currentBracketMatch = openedBrackets.Pop();
                }
                catch (InvalidOperationException)
                {
                    throw new FormatException(
                        $"Bracket mismatch, found '{c}' at position {pos} " +
                        "when expecting none"
                    );
                }
                if (c != currentBracketMatch.StopChar)
                {
                    throw new FormatException(
                        $"Bracket mismatch, found '{c}' at position {pos} " +
                        $"when expecting '{currentBracketMatch.StopChar}'"
                    );
                }

                if (openedBrackets.TryPeek(out var nextBracketMatch))
                {
                    nextBracketMatch.Content += currentBracketMatch.Content;
                }

                currentBracketMatch.Content += c;
                _parsed.Add(currentBracketMatch);

            }
            pos++;
            if (openedBrackets.TryPeek(out var currentMatch))
            {
                currentMatch.Content += c;
            }
        }
        if (openedBrackets.Count > 0)
        {
            string unclosed = string.Join(" ", openedBrackets.Select(b => b.StopChar));
            throw new FormatException($"Bracket mismatch, expected following closing brackets: '{unclosed}'");
        }

        _didParse = true;

        return _parsed;
    }

    /// <summary>
    /// Check if char c is one of the closing brackets
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static bool IsClosingBracket(char c)
    {
        return ClosingBrackets.Contains(c);
    }

    /// <summary>
    /// If c is an opening bracket, get the matching closing bracket. If not, return null.
    /// </summary>
    /// <param name="c">Char to check</param>
    /// <returns></returns>
    private static char? MatchWithClosingBracket(char c)
    {
        foreach ((char open, char close) in _bracketPairs)
        {
            if (c == open) return close;
        }
        return null;
    }
}