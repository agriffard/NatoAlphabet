using NatoAlphabet;

// letter → NATO phonetic word
char[] letters = ['A', 'C', 'Z', 'D'];
foreach (var letter in letters)
{
    Console.WriteLine($"{letter} -> {NatoConverter.ToNato(letter)}");
}

// NATO phonetic word → letter
string[] words = ["Alpha", "Charlie", "Zulu", "Delta"];
foreach (var word in words)
{
    Console.WriteLine($"{word} -> {NatoConverter.ToLetter(word)}");
}
