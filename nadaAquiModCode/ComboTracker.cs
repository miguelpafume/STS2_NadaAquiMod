namespace nadaAquiMod.nadaAquiModCode;

public static class ComboTracker
{
    private static readonly HashSet<string> _playedThisTurn = new();

    public static void RecordPlay(string cardEntry)
    {
        _playedThisTurn.Add(cardEntry);  
    } 
    public static bool WasPlayed(string cardEntry)
    {
        return _playedThisTurn.Contains(cardEntry);
    }

    public static void Remove(string cardEntry)
    {
        _playedThisTurn.Remove(cardEntry);
    }

    public static void Clear()
    {
        _playedThisTurn.Clear();
    }
}