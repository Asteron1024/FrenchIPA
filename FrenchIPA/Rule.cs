using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FrenchIPA {

  [DebuggerDisplay("{Term} => {Replace}")]
  internal class Rule {
    public Rule(Regex term, string transcription, string? alternative = null) {
      Term = term;
      Transcription = transcription;
      Alternative = alternative;
    }

    public Regex Term { get; }
    public string Transcription { get; }
    public string? Alternative { get; }
  }
}
