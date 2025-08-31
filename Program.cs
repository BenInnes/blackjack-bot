using System.Collections;
using System.Diagnostics;
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
string play = "y";

while (play == "y")
{

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
    string temp = "";
    int pBust = 75;

    Console.WriteLine("The bot will stick if the % chance to bust is greater than a certain value. enter that value (default 75)");
    temp = Console.ReadLine();

    if (!int.TryParse(temp, out pBust))
    {
        Console.WriteLine("Bad value. Please input an integer next time, defaulting to 75");
    }

    if (pBust == 0)
    {
        pBust = 75;
    }

    Console.WriteLine("press any key to continue");
    Console.ReadKey();

    Console.Clear();

    //initialize hand

    int[] hand = new int[4];
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
        if (aceTotal == 0 && card == 1)
        {
            aceTotal = 10;
        }
    }

    int total = hand.Sum();
    bool game = true;

    aceTotal += total;

    while (game)
    {
        Console.WriteLine("is it my turn (y/N)");

        if (Console.ReadLine().ToLower() == "y")
        {
            Console.Clear();

            Console.WriteLine("if that was a misclick and it is not my turn, please type 'oops'");
            if (Console.ReadLine().ToLower() == "oops")
            {
                continue;
            }

            Console.Clear();

            if (total >= 20 | aceTotal == 21 | hand.Count() == 5) //thou shalt not hit on 20
            {
                Console.WriteLine("stick");
                break;
            }

            Console.WriteLine(getBust(deck, total) * 100 + "% chance of busting on hit");

            while ((getBust(deck, total) * 100) <= pBust)
            {
                Console.WriteLine("hit. please input your card using 10 for JQK and 1 for ace");
                temp = Console.ReadLine();
                hand.Append(Convert.ToInt16(temp));

                Console.Clear();

                if ((aceTotal - total) == 0 && temp == "1")
                {
                    aceTotal += 10;
                }

                deck.Remove(Convert.ToInt16(temp));
                total += Convert.ToInt16(temp);
                aceTotal += Convert.ToInt16(temp);

                Console.WriteLine("total (ace as 1) = " + total);

                if (aceTotal != total)
                {
                    Console.WriteLine("total (ace as 11) = " + aceTotal);
                }

                if ((total >= 20 && total < 22) | aceTotal == 21 | hand.Count() == 5) //thou shalt not hit on 20
                {
                    Console.WriteLine("stick");
                    break;
                }

                if (total > 21)
                {
                    Console.WriteLine("bust xD");
                    break;
                }

                Console.WriteLine(getBust(deck, total) * 100 + "% chance of busting on hit");
            }
            Console.WriteLine("stick");
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
    Console.WriteLine("press any key to continue");
    Console.ReadKey();


    Console.Clear();

    Console.WriteLine("would you like to play again y/N");
    play = Console.ReadLine().ToLower();

    Console.Clear();
}