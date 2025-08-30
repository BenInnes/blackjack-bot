using System.Collections;
using System.Runtime.CompilerServices;

static double getBust(ArrayList deck, int total)
{
    int bustThreshold = 21 - total; //the highest possible card that can be drawn without busting
    int nSafe = 0; //number of cards that would not cause bust
    int nBust = 0; //number of cards that would cause bust
    
    foreach (int card in deck)
    {
        if (card > bustThreshold)
        {
            nBust++;
        }
        else
        {
            nSafe++;
        }
    }

    return ((float)nBust / ((float)nSafe + (float)nBust));
}

//initilize deck
ArrayList deck = new ArrayList();
int[] ranks = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1 };

for (int i = 0; i < 4; i++)
{
    foreach (int rank in ranks)
    {
        deck.Add(rank);
    }
}

//initialize hand

int[] hand = new int[4];
int aceN = 0;
int aceTotal = 0;


Console.WriteLine("Please enter the value of the first card in your hand, using 10 for JQK and 1 for ace");

hand[0] = Convert.ToInt16(Console.ReadLine());
Console.Clear();

Console.WriteLine("Please enter the value of the second card in your hand, using 10 for JQK and 1 for ace");

hand[1] = Convert.ToInt16(Console.ReadLine());
Console.Clear();


foreach (int card in hand) //update ace count and remove cards in hand from deck
{
    deck.Remove(card);
    if (card == 1)
    {
        aceN++;
        aceTotal += 10;
    }
}

int total = hand.Sum();
bool game = true;
string temp = "";

aceTotal += total;

while (game)
{
    Console.WriteLine("is it my turn (y/N)");

    if (Console.ReadLine() == "y")
    {
        Console.Clear();

        if (total >= 20 | aceTotal >= 20) //thou shalt not hit on 20
        {
            Console.WriteLine("stick");
            break;
        }

        Console.WriteLine(getBust(deck, total) +"% chance of busting on hit");

        game = false;
    }
    else
    {
        Console.Clear();

        Console.WriteLine("enter the value of the card if the current player hit (using 10 for JQK and 1 for ace) or type turn if they stuck");
        temp = Console.ReadLine();

        Console.Clear();

        if (temp != "turn")
        {
            deck.Remove(temp);
            Console.WriteLine(temp + " successfully removed from deck");
        }
    }
}
