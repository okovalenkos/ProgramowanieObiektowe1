using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Zadanie2();
        Zadanie3();
        Zadanie4();
    }
    static void Zadanie2()
    {
        List<string> wpisy = new List<string>();

        Console.WriteLine("Ile linii tekstu chcesz wprowadzić?");
        int ile = int.Parse(Console.ReadLine());

        for (int i = 0; i < ile; i++)
        {
            Console.Write($"Podaj tekst {i + 1}: ");
            string linia = Console.ReadLine();
            wpisy.Add(linia);
        }

        string sciezka = "dane_uzytkownika.txt";

        File.WriteAllLines(sciezka, wpisy);

        Console.WriteLine($"\nDane zapisano do pliku: {sciezka}");
    }

    static void Zadanie3()
    {
        string sciezka = "dane_uzytkownika.txt";

        if (!File.Exists(sciezka))
        {
            Console.WriteLine("Plik nie istnieje. Najpierw wykonaj zadanie 2.");
            return;
        }

        string[] linie = File.ReadAllLines(sciezka);

        Console.WriteLine("\nZawartość pliku:");

        foreach (string linia in linie)
        {
            Console.WriteLine(linia);
        }
    }
    static void Zadanie4()
    {
        string sciezka = "dane_uzytkownika.txt";

        Console.WriteLine("Ile nowych linii chcesz dopisać?");
        int ile = int.Parse(Console.ReadLine());

        using (StreamWriter sw = new StreamWriter(sciezka, append: true))
        {
            for (int i = 0; i < ile; i++)
            {
                Console.Write($"Podaj tekst {i + 1}: ");
                string linia = Console.ReadLine();
                sw.WriteLine(linia);
            }
        }

        Console.WriteLine("\nNowe linie zostały dopisane do pliku.");
    }
}

    public class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<int> Oceny { get; set; }

        public Student()
        {
            Oceny = new List<int>();
        }
    }