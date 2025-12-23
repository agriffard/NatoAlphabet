using Comptime;

namespace NatoAlphabet;

public static partial class NatoConverter
{
    // Letter → NATO phonetic word
    [Comptime]
    public static Dictionary<char, string> LetterToPhonetic()
    {
        return new Dictionary<char, string>(CharComparer.OrdinalIgnoreCase)
        {
            {'A', "Alpha"},
            {'B', "Bravo"},
            {'C', "Charlie"},
            {'D', "Delta"},
            {'E', "Echo"},
            {'F', "Foxtrot"},
            {'G', "Golf"},
            {'H', "Hotel"},
            {'I', "India"},
            {'J', "Juliett"},
            {'K', "Kilo"},
            {'L', "Lima"},
            {'M', "Mike"},
            {'N', "November"},
            {'O', "Oscar"},
            {'P', "Papa"},
            {'Q', "Quebec"},
            {'R', "Romeo"},
            {'S', "Sierra"},
            {'T', "Tango"},
            {'U', "Uniform"},
            {'V', "Victor"},
            {'W', "Whiskey"},
            {'X', "X-ray"},
            {'Y', "Yankee"},
            {'Z', "Zulu"}
        };
    }

    // NATO phonetic word → Letter
    [Comptime]
    public static Dictionary<string, char> PhoneticToLetter()
    {
        var dict = new Dictionary<string, char>(StringComparer.OrdinalIgnoreCase);
        foreach (var kvp in LetterToPhonetic())
        {
            dict[kvp.Value] = kvp.Key;
        }
        return dict;
    }

    // Convert letter → NATO phonetic word
    public static string ToNato(char letter)
    {
        return LetterToPhonetic().TryGetValue(char.ToUpper(letter), out var word) ? word : null;
    }

    // Convert NATO phonetic word → letter
    public static char? ToLetter(string phonetic)
    {
        return PhoneticToLetter().TryGetValue(phonetic, out var letter) ? letter : (char?)null;
    }

    // Case-insensitive comparer for char dictionary
    private class CharComparer : IEqualityComparer<char>
    {
        public static readonly CharComparer OrdinalIgnoreCase = new CharComparer();
        public bool Equals(char x, char y) => char.ToUpperInvariant(x) == char.ToUpperInvariant(y);
        public int GetHashCode(char obj) => char.ToUpperInvariant(obj).GetHashCode();
    }
}
