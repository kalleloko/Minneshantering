namespace SkalProj_Datastrukturer_Minne;

public class BracketMatch
{

    public int Position { get; init; }
    public char StopChar { get; init; }
    public string Content { get; set; } = "";

    public BracketMatch(int position, char stopChar)
    {
        Position = position;
        StopChar = stopChar;
    }

    public BracketMatch(int position, char stopChar, string content)
    {
        Position = position;
        StopChar = stopChar;
        Content = content;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string? ToString()
    {
        return new string(' ', Position) + Content;
    }
    /// <summary>
    /// Check if obj equals this by properties
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is BracketMatch other &&
               Position == other.Position &&
               Content == other.Content;
    }

    /// <summary>
    /// Get hash code from properties
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Position, Content);
    }
}