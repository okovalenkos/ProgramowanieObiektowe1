using System;
using System.Numerics;
using System.Reflection.Metadata;

public interface IModular
{
    public double Module();
}
public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular, IComparable<ComplexNumber>, IComparable
{
    private double re;
    private double im;
    public double Re { get => re; set => re = value; }
    public double Im { get => im; set => im = value; }
    public ComplexNumber(double re, double im)
    {
        this.re = re; this.im = im;
    }
    public override string ToString()
    {
        string sign = im >= 0 ? "+" : "-";
        return $"{re} {sign} {Math.Abs(im)}i";
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

    public int CompareTo(ComplexNumber other)
    {
        if (other is null) return 1;
        return Module().CompareTo(other.Module());
    }

    public int CompareTo(object obj)
    {
        if (obj is ComplexNumber other) return CompareTo(other);
        throw new ArgumentException("Objekt nie jest liczbą zespoloną", nameof(obj));
    }
}
{
    static void Main(string[] args)
    {
        ComplexNumber[] liczby = new Complex[]
    {
    Complex(-8, 9);
        Complex(3, -5);
        Complex(0, 5);
        Complex(3, 4);
        Complex(2, 2);
    };
    foreach (var liczba in liczby)
    {
        Console.WriteLine(liczba);
    }
}
}