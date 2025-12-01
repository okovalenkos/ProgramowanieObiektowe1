using System;
using System.Collections.Generic;
using System.Linq;

public interface IModular
{
    public double Module();
}
public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular, IComparable<ComplexNumber>
{
    private double re;
    private double im;

    public double Re { get => re; set => re = value; }
    public double Im { get => im; set => im = value; }

    public ComplexNumber(double re, double im)
    {
        this.re = re; this.im = im;
    }

    public int CompareTo(ComplexNumber other)
    {
        if (other == null) return 1;

        double thisModule = this.Module();
        double otherModule = other.Module();
        if (thisModule < otherModule) return -1;
        if (thisModule > otherModule) return 1;
        return 0;
    }

    public override string ToString()
    {
        string sign = im >= 0 ? " + " : " - ";
        return $"{re}{sign}{Math.Abs(im)}i";
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re + b.re, a.im + b.im);
    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re - b.re, a.im - b.im);
    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);
    public static ComplexNumber operator -(ComplexNumber a)
        => new ComplexNumber(a.re, -a.im); 

    public object Clone() => new ComplexNumber(re, im);

    public bool Equals(ComplexNumber other)
    {
        if (other == null) return false;
        return re == other.re && im == other.im;
    }

    public override bool Equals(object obj)
        => obj is ComplexNumber other && Equals(other);

    public override int GetHashCode()
        => HashCode.Combine(re, im);

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
        => a?.Equals(b) ?? b is null;
    public static bool operator !=(ComplexNumber a, ComplexNumber b)
        => !(a == b);

    public double Module()
        => Math.Sqrt(re * re + im * im);
}

public class Program
{
    public static void Main(string[] args)
    {
        // 2. Definicja tablicy pięciu, przykładowych liczb zespolonych
        ComplexNumber[] complexArray = new ComplexNumber[]
        {
            new ComplexNumber(7, 9),
            new ComplexNumber(3, 7),
            new ComplexNumber(8, 1),
            new ComplexNumber(0, 3),
            new ComplexNumber(2, -8)
        };

        Console.WriteLine("## 2. Operacje na Tablicy Liczb Zespolonych ##");

        // 2a. Wypisz je wykorzystując pętlę foreach
        Console.WriteLine("\na. Tablica początkowa:");
        foreach (var z in complexArray)
        {
            Console.WriteLine(z);
        }

        // 2b. Posortuj w oparciu o moduł liczby zespolonej i wypisz jeszcze raz
        Array.Sort(complexArray);
        Console.WriteLine("\nb. Tablica posortowana (wg. modułu):");
        foreach (var z in complexArray)
        {
            Console.WriteLine(z);
        }

        // 2c. Wypisz minimum i maksimum tablicy
        var minComplex = complexArray.Min();
        var maxComplex = complexArray.Max();
        Console.WriteLine($"\nc. Minimum tablicy (najmniejszy moduł): {minComplex}");
        Console.WriteLine($"c. Maksimum tablicy (największy moduł): {maxComplex}");

        // 2d. Odfiltruj z tablicy wszystkie liczby zespolone o ujemnej części urojonej i wypisz jeszcze raz
        var filteredArray = complexArray.Where(z => z.Im >= 0).ToArray();
        Console.WriteLine("\nd. Tablica po odfiltrowaniu (Im >= 0):");
        foreach (var z in filteredArray)
        {
            Console.WriteLine(z);
        }

        
        //  3. Definicja listy zawierającej co najmniej pięć liczb zespolonych
         
        List<ComplexNumber> complexList = new List<ComplexNumber>
        {
            new ComplexNumber(12, 2),
            new ComplexNumber(7, -4),
            new ComplexNumber(4, 5),
            new ComplexNumber(3, 5),
            new ComplexNumber(-1, 10)
        };

        Console.WriteLine("\n## 3. Operacje na Liście Liczb Zespolonych ##");

        // Sprawdzenie, że operacje z zad. 2 działają:
        var orderedList = complexList.OrderBy(z => z).ToList();
        Console.WriteLine("\nLista posortowana (Orderby):");
        foreach (var element in orderedList) Console.WriteLine(element);

        Console.WriteLine($"Minimum listy: {complexList.Min()}");
        Console.WriteLine($"Maksimum listy: {complexList.Max()}");

        var filteredReList = complexList.Where(z => z.Re < 0).ToList();
        Console.WriteLine($"Liczby z Re < 0: {string.Join(" | ", filteredReList)}");

        // 3a. Usuń drugi element z listy i wypisz całą listę
        if (complexList.Count > 1)
        {
            complexList.RemoveAt(1);
            Console.WriteLine("\na. Po usunięciu drugiego elementu:");
            foreach (var element in complexList) Console.WriteLine(element);
        }

        // 3b. Usuń najmniejszy element z listy i wypisz całą listę
        var minNormElement = complexList.Min();
        complexList.Remove(minNormElement);
        Console.WriteLine("\nb. Po usunięciu najmniejszego elementu (wg. modułu):");
        foreach (var element in complexList) Console.WriteLine(element);

        // 3c. Usuń wszystkie elementy z listy i wypisz całą listę
        complexList.Clear();
        Console.WriteLine($"\nc. Po wyczyszczeniu listy. Liczba elementów: {complexList.Count}");

        
         // 4. Zdefiniuj zbiór (HashSet) i dodaj do niego liczby zespolone
         
        HashSet<ComplexNumber> complexSet = new HashSet<ComplexNumber>();
        var z1 = new ComplexNumber(6, 7);
        var z2 = new ComplexNumber(1, 2);
        var z3 = new ComplexNumber(6, 7); // Duplikat
        var z4 = new ComplexNumber(1, -2);
        var z5 = new ComplexNumber(-5, 9);

        complexSet.Add(z1);
        complexSet.Add(z2);
        complexSet.Add(z3);
        complexSet.Add(z4);
        complexSet.Add(z5);

        Console.WriteLine("\n## 4. Operacje na Zbiorze (HashSet) Liczb Zespolonych ##");

        // 4a. Sprawdź zawartość zbioru wypisując wszystkie wartości
        Console.WriteLine("\na. Zawartość zbioru (HashSet):");
        foreach (var element in complexSet)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine($"(Zbiór zawiera {complexSet.Count} unikalne elementy)");

        // 4b. Sprawdź możliwość wykonania operacji z poprzednich zadań na zbiorze (minimum, maksimum, sortowanie, filtrowanie)
        Console.WriteLine("\nb. Operacje LINQ na zbiorze:");

        // Minimum i Maksimum
        Console.WriteLine($"Minimum: {complexSet.Min()}");
        Console.WriteLine($"Maksimum: {complexSet.Max()}");

        // Sortowanie (konwersja do Listy)
        var sortedComplexSet = complexSet.OrderBy(z => z).ToList();
        Console.WriteLine("Posortowany zbiór (konwersja do listy):");
        foreach (var element in sortedComplexSet) Console.WriteLine(element);

        // Filtrowanie (przykładowo Im < 0)
        var filteredImaginaryNegative = complexSet.Where(z => z.Im < 0).ToList();
        Console.WriteLine($"Filtrowanie (Im < 0): {string.Join(" | ", filteredImaginaryNegative)}");

        
         // 5. Zdefiniuj słownik, w którym kluczami będą nazwy zmiennych (string),
        
         
        Dictionary<string, ComplexNumber> complexDictionary = new Dictionary<string, ComplexNumber>
        {
            { "z1", new ComplexNumber(6, 7) },
            { "z2", new ComplexNumber(1, 2) },
            { "z3", new ComplexNumber(6, 7) },
            { "z4", new ComplexNumber(1, -2) },
            { "z5", new ComplexNumber(-5, 9) }
        };

        Console.WriteLine("\n## 5. Operacje na Słowniku (Dictionary) ##");

        // 5a. Wypisz wszystkie elementy słownika w postaci (klucz, wartość)
        Console.WriteLine("\na. Wszystkie elementy słownika (klucz, wartość):");
        foreach (var kvp in complexDictionary)
        {
            Console.WriteLine($"({kvp.Key}, {kvp.Value})");
        }

        // 5b. Wypisz osobno wszystkie klucze i wszystkie wartości ze słownika
        Console.WriteLine("\nb. Klucze:");
        Console.WriteLine(string.Join(" | ", complexDictionary.Keys));
        Console.WriteLine("Wartości:");
        Console.WriteLine(string.Join(" | ", complexDictionary.Values));

        // 5c. Sprawdź, czy w słowniku istnieje element o kluczu z6
        bool containsZ6 = complexDictionary.ContainsKey("z6");
        Console.WriteLine($"\nc. Czy klucz \"z6\" istnieje? {containsZ6}");

        // 5d. Wykonaj na słowniku zadania 2c i 2d (Min/Max i filtrowanie)
        Console.WriteLine("\nd. Minimum, Maksimum i Filtracja na wartościach słownika:");

        // Minimum i Maksimum
        var minVal = complexDictionary.Values.Min();
        var maxVal = complexDictionary.Values.Max();
        Console.WriteLine($"Minimum: {minVal}");
        Console.WriteLine($"Maksimum: {maxVal}");

        // Filtrowanie (przykładowo Im < 0)
        var filteredValues = complexDictionary.Values.Where(z => z.Im < 0).ToList();
        Console.WriteLine($"Odfiltrowane (Im < 0): {string.Join(" | ", filteredValues)}");

        // 5e. Usuń ze słownika element o kluczu „z3”
        complexDictionary.Remove("z3");
        Console.WriteLine("\ne. Po usunięciu klucza \"z3\". Liczba elementów: " + complexDictionary.Count);

        // 5f. Usuń drugi element ze słownika
        if (complexDictionary.Count >= 2)
        {
            string secondKey = complexDictionary.Keys.Skip(1).First();
            complexDictionary.Remove(secondKey);
            Console.WriteLine($"\nf. Usunięto pozycję o kluczu ({secondKey}). Liczba elementów: " + complexDictionary.Count);
        }
        Console.WriteLine("Aktualne pozycje w słowniku:");
        foreach (var kvp in complexDictionary) Console.WriteLine($"({kvp.Key}, {kvp.Value})");

        // 5g. Wyczyść słownik
        complexDictionary.Clear();
        Console.WriteLine($"\ng. Słownik został wyczyszczony. Liczba elementów: {complexDictionary.Count}");
    }
}