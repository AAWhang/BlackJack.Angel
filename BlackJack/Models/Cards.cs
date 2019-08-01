using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Models
{


  public class Cards
  {
    public string Card { get; set; }
    public int Value { get; set; }
    public Cards (string card, int value)
    {
      Card = card;
      Value = value;
    }
  }

  public static class Hands
  {
    public static List<Cards> Deck = new List<Cards> {};
    public static List<Cards> PlayerOne = new List<Cards> {};
    public static List<Cards> PlayerTwo = new List<Cards> {};
	  public static string suit;
    public static string number;
    public static int value;
    public static string card;

    public static void makedeck ()
    {
      for (var i = 0; i < 4; i++)
      {
        if (i == 0) {
          suit = "Spades";
        } else if (i == 1) {
          suit = "Clubs";
        } else if (i == 2) {
          suit = "Diamonds";
        } else if (i == 3) {
          suit = "Hearts";
        }
        for (var j = 0; j < 13; j++)
        {
          if (j == 0) {
            number = "Ace";
          } else if (j == 1) {
            number = "Two";
          } else if (j == 2) {
            number = "Three";
          } else if (j == 3) {
            number = "Four";
          } else if (j == 4) {
            number = "Five";
          } else if (j == 5) {
            number = "Six";
          } else if (j == 6) {
            number = "Seven";
          } else if (j == 7) {
            number = "Eight";
          } else if (j == 8) {
            number = "Nine";
          } else if (j == 9) {
            number = "Ten";
          } else if (j == 10) {
            number = "Jack";
          } else if (j == 11) {
            number = "Queen";
          } else if (j == 12) {
            number = "King";
          }
          value = j + 1;
          if (value > 10) {
            value = 10;
          }
          card = number + " of " + suit;
          Deck.Add(new Cards(card,value));
        }
      }
      Deck.Shuffle();
      Deal();
    }

    private static Random rng = new Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


       public static void Deal() {
           PlayerOne.Add(Deck[0]);
           Deck.RemoveAt(0);
           PlayerOne.Add(Deck[0]);
           Deck.RemoveAt(0);
           PlayerTwo.Add(Deck[0]);
           Deck.RemoveAt(0);
           PlayerTwo.Add(Deck[0]);
           Deck.RemoveAt(0);
       }



   public static void printcards() {
     foreach (Cards kvp in Deck)
     {
       Console.WriteLine(kvp.Card + " is worth " + kvp.Value);
     }
   }
   public static void printhands() {
     int total1 = 0;
     int total2 = 0;
     foreach (Cards kvp in PlayerOne)
     {
       Console.WriteLine(kvp.Card + " is worth " + kvp.Value);
       total1 += kvp.Value;
     }
      Console.WriteLine("Player 1: " + total1)

     foreach (Cards kvp in PlayerTwo)
     {
       Console.WriteLine(kvp.Card + " is worth " + kvp.Value);
       total2 += kvp.Value;
     }
     Console.WriteLine("Player 2: " + total2)
   }

  }
}
