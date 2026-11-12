int[,] tablica = new int[3, 3];
Random losowanie = new();
bool end = false;

Console.WriteLine("Kółko i krzyżyk");
Console.WriteLine("Komputer: X, gracz: O");

while (!end)
{
    int wolnePola = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (tablica[i, j] == 0)
            {
                wolnePola++;
            }
        }
    }

    if (wolnePola == 0)
    {
        WyswietlPlansze();
        Console.WriteLine("Remis!");
        break;
    }

    int xKomputera;
    int yKomputera;
    do
    {
        xKomputera = losowanie.Next(0, 3);
        yKomputera = losowanie.Next(0, 3);
    }
    while (tablica[xKomputera, yKomputera] != 0);

    tablica[xKomputera, yKomputera] = 1;
    Console.WriteLine("\nRuch komputera:");
    WyswietlPlansze();

    if (CzyWygrana(1))
    {
        Console.WriteLine("Wygrał komputer!");
        break;
    }

    wolnePola--;
    if (wolnePola == 0)
    {
        Console.WriteLine("Remis!");
        break;
    }

    bool poprawnyRuch = false;
    while (!poprawnyRuch)
    {
        Console.Write("Podaj numer wiersza (0-2): ");
        bool poprawnyWiersz = int.TryParse(Console.ReadLine(), out int x);
        Console.Write("Podaj numer kolumny (0-2): ");
        bool poprawnaKolumna = int.TryParse(Console.ReadLine(), out int y);

        if (poprawnyWiersz && poprawnaKolumna && x >= 0 && x <= 2 && y >= 0 && y <= 2)
        {
            if (tablica[x, y] == 0)
            {
                tablica[x, y] = 2;
                poprawnyRuch = true;
            }
            else
            {
                Console.WriteLine("To pole jest już zajęte.");
            }
        }
        else
        {
            Console.WriteLine("Podaj liczby od 0 do 2.");
        }
    }

    WyswietlPlansze();
    if (CzyWygrana(2))
    {
        Console.WriteLine("Wygrał gracz!");
        end = true;
    }
}

void WyswietlPlansze()
{
    Console.WriteLine("-------------");
    for (int i = 0; i < 3; i++)
    {
        Console.Write("| ");
        for (int j = 0; j < 3; j++)
        {
            char znak = tablica[i, j] switch
            {
                1 => 'X',
                2 => 'O',
                _ => ' '
            };

            Console.Write($"{znak} | ");
        }

        Console.WriteLine();
        Console.WriteLine("-------------");
    }
}

bool CzyWygrana(int gracz)
{
    for (int i = 0; i < 3; i++)
    {
        if ((tablica[i, 0] == gracz && tablica[i, 1] == gracz && tablica[i, 2] == gracz) ||
            (tablica[0, i] == gracz && tablica[1, i] == gracz && tablica[2, i] == gracz))
        {
            return true;
        }
    }

    return (tablica[0, 0] == gracz && tablica[1, 1] == gracz && tablica[2, 2] == gracz) ||
           (tablica[0, 2] == gracz && tablica[1, 1] == gracz && tablica[2, 0] == gracz);
}
