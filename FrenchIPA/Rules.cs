﻿using System.Text.RegularExpressions;

namespace FrenchIPA {
  internal static class Rules {
    public static List<Rule> List { get; set; } = new List<Rule>() {
      new Rule(new Regex("(e|es)$"), ""),
      new Rule(new Regex("e[rz]$"), "e"),
      new Rule(new Regex("[tdzsxgpbc]+$"), ""),

      new Rule(new Regex("ueil+"), "œj"),
      new Rule(new Regex("eill"), "ɛj", "ej"),
      new Rule(new Regex("ail$"), "aj"),
      new Rule(new Regex("eil$"), "ɛj"),
      new Rule(new Regex("aill"), "ɑj", "aj"),
      new Rule(new Regex("(?<=[qg]u)ill"), "ij"),
      new Rule(new Regex("(?<=[aouâœ])ill"), "j"),
      new Rule(new Regex("(?<=^i)ll"), "l"),
      new Rule(new Regex("ill"), "ij"),
      new Rule(new Regex("(?<=[aeiouéèâôy])il$"), "j"),
      new Rule(new Regex("(?<=[bcdfgjklmnprstvz])il$"), ""),

      new Rule(new Regex("oin(?![aeiounméèâôy])"), "wɛ̃"),
      new Rule(new Regex("(im|in|ain|ein|aim|ym)(?![aeiounméèâôy])"), "ɛ̃"),
      new Rule(new Regex("(um|un)(?![aeiounméèâôy])"), "ɛ̃", "œ̃"),
      new Rule(new Regex("ien(?![aeiounméèâôy])"), "jɛ̃"),
      new Rule(new Regex("o[nm](?![aeiounméèâôy])"), "ɔ̃"),
      new Rule(new Regex("[ae][mn](?![aeiounméèâôy])"), "ɑ̃"),
      new Rule(new Regex("^enn"), "ɑ̃n"),
      new Rule(new Regex("^emm"), "ɑ̃m"),

      new Rule(new Regex("e?au"), "o", "ɔ"),
      new Rule(new Regex("oeu"), "ø"),
      new Rule(new Regex("eu(?=([tdzsxg]*|se|e)$)"), "ø"),
      new Rule(new Regex("[eœ]u"), "œ", "ø"),
      new Rule(new Regex("eû"), "ø"),
      new Rule(new Regex("a[iî]"), "ɛ", "e"),
      new Rule(new Regex("ei"), "ɛ", "e"),
      new Rule(new Regex("o[iî]"), "wa"),

      new Rule(new Regex("oy"), "waj"),
      new Rule(new Regex("ay"), "ɛj", "ej"),
      new Rule(new Regex("uy"), "ɥij"),

      new Rule(new Regex("xc"), "ks"),
      new Rule(new Regex("cc(?=[ei])"), "ks"),
      new Rule(new Regex("bsc?(?!u)"), "ps", "bz"),
      new Rule(new Regex("s?c(?=[eiêéèy])"), "s"),
      new Rule(new Regex("c?qu"), "k"),
      new Rule(new Regex("gu(?=[eiéèê])"), "g"),
      new Rule(new Regex("ge(?=[ao])"), "ʒ"),

      new Rule(new Regex("ou(?=(e.|[aé]|ï|i[^l]))"), "w"),
      new Rule(new Regex("o[uû]"), "u"),
      new Rule(new Regex("u(?=(i|î|er|eu|é|è|e.|a))"), "ɥ"),
      new Rule(new Regex("(?<=[bcdfgjkptvz][bcdfgjklmprvz])i(?=er|o|é|è|an)"), "ij"),
      new Rule(new Regex("i(?=[èoaéu])"), "j"),
      new Rule(new Regex("[iï](?=e.)"), "j"),

      new Rule(new Regex("(?<=[lpm])a(?=ss)"), "ɑ", "a"),
      new Rule(new Regex("a"), "a", "ɑ"),
      new Rule(new Regex("à"), "a"),
      new Rule(new Regex("â"), "ɑ", "a"),
      new Rule(new Regex("(?<=^r)e(?!ct|sp|st|nn)"), "ə"),
      new Rule(new Regex("e(?=[bcdfgjklmnprstvz]{2,})"), "ɛ", "e"),
      new Rule(new Regex("(?<=([aeiouéè]|[aeo][nm])(b|c|ch|d|f|g|j|k|l+|m|n|gn|p|qu|r+|s+|t+|v|z))e(?=([bcdfgjklmnprstvz]|ss)[aeiouéè])"), "", "ə"),
      new Rule(new Regex("e(?=x)"), "ɛ"),
      new Rule(new Regex("e(?=[lctf]h?$)"), "ɛ"),
      new Rule(new Regex("e"), "ə"),
      new Rule(new Regex("é"), "e"),
      new Rule(new Regex("è"), "ɛ"),
      new Rule(new Regex("ê"), "ɛ", "e"),
      new Rule(new Regex("i"), "i"),
      new Rule(new Regex("î"), "i"),
      new Rule(new Regex("ï"), "i"),
      new Rule(new Regex("o(?=[tdzsxg]+$)"), "o"),
      new Rule(new Regex("o"), "ɔ", "o"),
      new Rule(new Regex("ô"), "o"),
      new Rule(new Regex("û"), "y"),
      new Rule(new Regex("u"), "y"),
      new Rule(new Regex("y"), "i"),
      new Rule(new Regex("œ"), "œ"),

      new Rule(new Regex("b"), "b"),
      new Rule(new Regex("ch"), "ʃ"),
      new Rule(new Regex("c+"), "k"),
      new Rule(new Regex("ç"), "s"),
      new Rule(new Regex("d+"), "d"),
      new Rule(new Regex("f+"), "f"),
      new Rule(new Regex("g(?=[eiéèêî])"), "ʒ"),
      new Rule(new Regex("gn"), "ɲ"),
      new Rule(new Regex("g"), "g"),
      new Rule(new Regex("ph"), "f"),
      new Rule(new Regex("j"), "ʒ"),
      new Rule(new Regex("k"), "k"),
      new Rule(new Regex("l+"), "l"),
      new Rule(new Regex("m+"), "m"),
      new Rule(new Regex("n+"), "n"),
      new Rule(new Regex("p+"), "p"),
      new Rule(new Regex("q"), "k"),
      new Rule(new Regex("r+"), "ʁ"),
      new Rule(new Regex("st(?=io)"), "st"),
      new Rule(new Regex("t(?=io)"), "s"),
      new Rule(new Regex("ss"), "s"),
      new Rule(new Regex("(?<=[aeiouéèâôêî])s(?=[aeiouéèâôêî])"), "z"),
      new Rule(new Regex("s"), "s"),
      new Rule(new Regex("t+"), "t"),
      new Rule(new Regex("v"), "v"),
      new Rule(new Regex("w"), "w"),
      new Rule(new Regex("(?<=^e)xh?(?=[aeiouéèâôêî])"), "gz"),
      new Rule(new Regex("x"), "ks"),
      new Rule(new Regex("z"), "z"),
      new Rule(new Regex("h"), ""),
      new Rule(new Regex("."), ""),
    };
  }
}