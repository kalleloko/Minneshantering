namespace SkalProj_Datastrukturer_Minne;

public class BracketsParser
{
    private string _s;

    private List<(int position, string content)> _parsed = [];

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


    public BracketsParser(string input)
    {
        _s = input;
    }

    public List<(int, string)> Parse()
    {
        // Caching. Kan detta göras snyggare?
        if (_didParse)
        {
            return _parsed;
        }
        _didParse = true;

        return _parsed;
    }

}