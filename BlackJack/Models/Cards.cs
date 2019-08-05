using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

    public static class Game
    {
      public static int p1total;
      public static int p2total;
      public static Boolean p1bust = false;
      public static Boolean p2bust = false;

      public static int totalcount (List<Cards> Player)
      {
        int total = 0;
        foreach(Cards card in Player)
        {
          total += card.Value;
        }
        return total;
      }

      public static void assignTotal()
      {
        p1total = totalcount(Hands.PlayerOne);
        p2total = totalcount(Hands.PlayerTwo);
      }

      public static Boolean bustcheck(int total)
      {
        if (total > 21)
        {
          return true;
        }
        return false;
      }

      public static void p1choice()
      {
        int choice1;
        Console.WriteLine("Player 1, Would you like to hit (1) or stay (2)?");
        choice1 = int.Parse(Console.ReadLine());
        if (choice1 == 1)
        {
          Hands.hit(Hands.PlayerOne);
          Console.WriteLine(Hands.PlayerOne[Hands.PlayerOne.Count -1].Card);
        }
      }

      public static void p2choice()
      {
        int choice2;
        Console.WriteLine("Player 2, Would you like to hit (1) or stay (2)?");
        choice2 = int.Parse(Console.ReadLine());
        if (choice2 == 1)
        {
          Hands.hit(Hands.PlayerTwo);
          Console.WriteLine(Hands.PlayerTwo[Hands.PlayerTwo.Count -1].Card);
        }
      }

      public static void p1Lose()
      {
        Console.WriteLine("Player 1 has busted!");
      }

      public static void p2Lose()
      {
        Console.WriteLine("Player 2 has busted!");
      }



      public static void playBlackJack()
      {
        Hands.makedeck();
        Hands.Deck.Shuffle();
  			Hands.Deal();



        while (p1bust == false && p2bust == false)
        {
            Hands.printhands();

            p1choice();
            p2choice();

  		      assignTotal();
          p1bust = bustcheck(p1total);
          p2bust = bustcheck(p2total);
          if (p1bust == true)
          {
              Console.WriteLine("P1 Total: " + p1total);
              p1Lose();
          }
          if (p2bust == true)
          {
              Console.WriteLine("P2 Total: " + p2total);
              p2Lose();
          }

        }
      }



    }

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
      }



      public static void Shuffle<T>(this IList<T> list)
      {
  		Random rng = new Random();
          int n = list.Count;
          while (n > 1) {
              n--;
              int k = rng.Next(n + 1);
              T value = list[k];
              list[k] = list[n];
              list[n] = value;
          }
      }


     public static void Deal()
     {
             PlayerOne.Add(Deck[0]);
             Deck.RemoveAt(0);
             PlayerOne.Add(Deck[0]);
             Deck.RemoveAt(0);
             PlayerTwo.Add(Deck[0]);
             Deck.RemoveAt(0);
             PlayerTwo.Add(Deck[0]);
             Deck.RemoveAt(0);
     }

     public static void hit(List<Cards> Player)
     {
       Console.WriteLine("PRE:" + Player[0].Value +  ", " + Player[1].Value);
             Player.Add(Deck[0]);
             Deck.RemoveAt(0);

      Console.WriteLine("POST:" + Player[0].Value +  ", " + Player[1].Value);

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
        Console.WriteLine("Player 1: " + total1);

       foreach (Cards kvp in PlayerTwo)
       {
         Console.WriteLine(kvp.Card + " is worth " + kvp.Value);
         total2 += kvp.Value;
       }
       Console.WriteLine("Player 2: " + total2);
     }

    }
}
