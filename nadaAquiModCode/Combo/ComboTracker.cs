using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models; 

namespace nadaAquiMod.nadaAquiModCode.Combo;

public static class ComboTracker
{
    private static readonly List<CardModel> _playedThisTurn = new();
    private static bool _suppressNextRecord = false;

    public static IReadOnlyList<CardModel> CardsPlayed => _playedThisTurn;

    public static void RecordPlay(CardModel card)
    {
        if (_suppressNextRecord)
        {
            _suppressNextRecord = false;
            return;
        }

        _playedThisTurn.Add(card);
    }

    // Type-base
    public static int CountOfType(CardType type) => _playedThisTurn.Count(c => c.Type == type);

    public static bool WasPlayedType(CardType type) => _playedThisTurn.Any(c => c.Type == type);

    // Id-based
    public static bool WasPlayed(string cardEntry) => _playedThisTurn.Any(c => c.Id.Entry == cardEntry);

    public static int CountOf(string cardEntry) => _playedThisTurn.Count(c => c.Id.Entry == cardEntry);

    public static bool Remove(string cardEntry)
    {
        int idx = _playedThisTurn.FindIndex(c => c.Id.Entry == cardEntry);
        if (idx < 0) return false;

        _playedThisTurn.RemoveAt(idx);
        return true;
    }

    public static void ConsumeCombo(params string[] partnerEntries)
    {
        foreach (string entry in partnerEntries)
            Remove(entry);

        _suppressNextRecord = true;
    }

    public static void Clear()
    {
        _playedThisTurn.Clear();
        _suppressNextRecord = false;
    } 
}