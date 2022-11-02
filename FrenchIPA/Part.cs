using System.Diagnostics;

namespace FrenchIPA {
  [DebuggerDisplay("{Text} => {Transcription} ({Alternative})")]
  internal class Part {
    public Part(string text, int index) {
      Text = text;
      Index = index;
      Length = text.Length;
    }

    public bool Transcribed => Transcription != null;
    public int Index { get; }
    public int Length { get; }
    private string Text { get; }
    public string? Transcription { get; set; }
    public string? Alternative { get; set; }
  }
}
