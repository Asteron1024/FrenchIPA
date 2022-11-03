using System.Text.RegularExpressions;

namespace FrenchIPA {
  internal class Card {
    public Card(string word, string transcription) {
      Word = word;
      OriginalTranscription = transcription;
    }

    public string Word { get; set; }
    public string OriginalTranscription { get; set; }
    public string? MyTranscription { get; private set; }
    public bool? IsCorrect { get; private set; }
    public List<Part>? TranscriptionParts { get; private set; }

    public void GenerateTranscription() {
      TranscriptionParts = GetTranscriptionParts(Word);
      MyTranscription = string.Concat(TranscriptionParts.Select(x => x.Transcription));
      IsCorrect = GetIsCorrect(TranscriptionParts, OriginalTranscription);
    }

    private List<Part> GetTranscriptionParts(string word) {
      var parts = new List<Part> { new Part(word, 0) };

      foreach (var rule in Rules.List) {
        var newParts = new List<Part>();

        foreach (var part in parts) {
          if (part.Transcribed)
            newParts.Add(part);
          else
            Replace(word, part, rule, newParts);
        }
        parts = newParts;
      }
      return parts;
    }

    private void Replace(string text, Part part, Rule rule, List<Part> outputParts) {
      var matches = rule.Term.Matches(text);
      if (matches.Any()) {
        var currentIndex = part.Index;

        foreach (var match in matches.Cast<Match>()) {
          if (match.Index >= part.Index && match.Index + match.Length <= part.Index + part.Length) {

            if (match.Index > currentIndex)
              outputParts.Add(new Part(text[currentIndex..match.Index], currentIndex));

            outputParts.Add(new Part(text.Substring(match.Index, match.Length), match.Index) { Transcription = rule.Transcription, Alternative = rule.Alternative });
            currentIndex = match.Index + match.Length;
          }
        }
        if (currentIndex < part.Index + part.Length)
          outputParts.Add(new Part(text[currentIndex..(part.Index + part.Length)], currentIndex));
      }
      else {
        outputParts.Add(part);
      }
    }

    private bool? GetIsCorrect(List<Part> parts, string transcription) {
      bool correct = true;
      bool alternative = true;
      int index = 0;
      foreach (var part in parts) {
        var trLength = part.Transcription!.Length;

        bool trCorrect = true;
        bool altCorrect = true;

        int startIndex = index;
        if (trLength == 0 && part.Alternative != null) {
          if (part.Alternative! == transcription.Substring(index, part.Alternative!.Length)) {
            trCorrect = false;
            index += part.Alternative!.Length;
          }
        }
        else {
          for (int i = 0; i < trLength; i++, index++) {
            trCorrect &= transcription.Length > index && part.Transcription![i] == transcription[index];
          }
        }

        if (!trCorrect) {
          if (part.Alternative != null) {
            var altLength = part.Alternative!.Length;
            index = startIndex;
            for (int i = 0; i < altLength; i++, index++) {
              altCorrect &= transcription.Length > index && part.Alternative![i] == transcription[index];
            }
          }
          else
            altCorrect = false;
        }
        correct &= trCorrect;
        alternative &= altCorrect;
        if (!alternative)
          break;
      }
      correct &= index == transcription.Length;
      alternative &= index == transcription.Length;
      return correct ? true : alternative ? null : false;
    }
  }
}

