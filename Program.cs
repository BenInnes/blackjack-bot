using System.Collections;

//initilize deck

ArrayList deck = new ArrayList();
int[] ranks = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1};

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
    }
}

bool game = true;

while (game)
{

}