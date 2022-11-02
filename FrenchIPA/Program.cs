using System.Text;

namespace FrenchIPA {
  internal class Program {

    static void Main(string[] args) {
      //Console.OutputEncoding = Encoding.UTF8;
      //var symbols = File.ReadAllText("fr.txt").GroupBy(x => x).OrderBy(x => x.Key).Select(x => new { ch = x.Key, count = x.Count()}).ToList();
      //var res = symbols.Aggregate("", (x, y) => $"{x}\t{y}\r\n");
      //Console.WriteLine(res);


      var lines = File.ReadAllLines("words.txt", Encoding.UTF8);
      var cards = lines.Select(x => x.Split('\t'))
                       .Where(x => !string.IsNullOrEmpty(x[3]) && !x[1].Contains(' ') && !x[1].Contains('-'))
                       .Select(x => new Card(x[1].ToLower(), x[3][1..^1].Replace("ˈ", "").Replace("ʼ", "").Replace("(", "").Replace(")", "").Replace(" ", "")))
                       .ToList();

      foreach (var card in cards)
        card.GenerateTranscription();

      int correctCount = cards.Count(x => x.IsCorrect == true);
      int alternativeCount = cards.Count(x => x.IsCorrect == null);
      int notCorrect = cards.Count(x => x.IsCorrect == false);

      cards = cards.OrderByDescending(x => x.IsCorrect == false).ThenBy(x => x.IsCorrect).ToList();
      var sb = new StringBuilder(1024);
      sb.AppendLine($"{correctCount} ({correctCount + alternativeCount}), {notCorrect}");

      foreach (var card in cards) {
        sb.Append(card.Word).Append('\t')
          .Append(card.OriginalTranscription).Append('\t')
          .Append(card.MyTranscription).Append('\t')
          .Append(card.IsCorrect?.ToString() ?? "Alternative").AppendLine();
      }
      File.WriteAllText("tr.txt", sb.ToString());
      Console.WriteLine($"{correctCount} ({correctCount + alternativeCount}), {notCorrect}");
      //Console.ReadKey();
    }

  }
}
