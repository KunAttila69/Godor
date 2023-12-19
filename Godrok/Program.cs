StreamReader sr = new StreamReader("melyseg.txt");
List<int> lines = new();
while (!sr.EndOfStream)
{
    lines.Add(int.Parse(sr.ReadLine()));
}
sr.Close();
//1.Feladat
Console.WriteLine("1.Feladat: "+lines.Count);

//2.Feladat
int location = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("2.Feladat: " + lines[location]);

//3.Feladat
int unChanged = lines.Where(x => x == 0).Count();
Console.WriteLine("3.Feladat: " + Math.Round(Convert.ToDouble(unChanged) * 100 / Convert.ToDouble(lines.Count()),2)+"%");

//4.Feladat
StreamWriter sw = new StreamWriter("godrok.txt");

string text = "";
int godrok = 0;
for (int i = 0; i < lines.Count(); i++)
{
    if (lines[i] > 0)
    {
        text += $" {lines[i]}";
    }
    if(text != "" && lines[i] == 0)
    {
        godrok++;
        sw.WriteLine(text);
        text = "";
    }
}
sw.Close();

//5.Feladat
Console.WriteLine("5.Feladat: "+godrok);

//6.Feladat
Console.WriteLine("6.Feladat");

//a)
Console.WriteLine("a)");
if (lines[location] == 0)
{
    Console.WriteLine("Az adott helyen nincs gödör.");
}
else
{
    int start = location;
    List<int> currentHole = new();
    for (int i = 0; i < location-1; i++)
    {
        if (lines[i] >0 && start != 0)
        {
            start = i;
        }
        if (lines[i] == 0)
        {
            start = location;
        }
    }
    int end = location;
    for (int i = location; i < lines.Count(); i++)
    {
        if (lines[i] == 0)
        {
            end = i;
            break;
        }
    }
    for (int i = start - 1; i < end; i++)
    {
        currentHole.Add(lines[i]);
    }

    Console.WriteLine($"A gödör kezdete: {start} méter, a gödör vége {end}");

    //b)
    Console.WriteLine("b)");
    bool melyul = true;
    for (int i = start - 1; i < end; i++)
    {
        if (lines[i] != lines[lines.Count()-i])
        {
            melyul = false;
            break;
        }
    }
    Console.WriteLine(melyul ? "Folyamatosan mélyül" : "Nem mélyül folyamatosan");

    //c)
    Console.WriteLine("c)");
    Console.WriteLine($"A legnagyobb mélysége {currentHole.Max()} méter");

    //d)
    Console.WriteLine("d)");
    int terfogat = 0;
    foreach (var tile in currentHole)
    {
        terfogat += 1 * 10 * tile;
    }
    Console.WriteLine($"A térfogata {terfogat} m^3");

    //e)
    Console.WriteLine("e)");
    int vizesTerfogat = 0;
    foreach (var tile in currentHole)
    {
        vizesTerfogat += 1 * 10 * (tile-1);
    }
    Console.WriteLine($"A vízmennyiség {vizesTerfogat} m^3");
}




