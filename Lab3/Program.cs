 using System;

    public interface IModule
    {
        double Module();
    }

    public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModule
    {
        private double re;
        private double im;

        public double Re
        {
            get => re;
            set => re = value;
        }

        public double Im
        {
            get => im;
            set => im = value;
        }

        public ComplexNumber(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString()
        {
            string sign = im >= 0 ? " + " : " - ";
            return $"{re}{sign}{Math.Abs(im)}i";
        }

        // Operator +
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.re + b.re, a.im + b.im);

        // Operator -
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.re - b.re, a.im - b.im);

        // Operator *
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(
                a.re * b.re - a.im * b.im,
                a.re * b.im + a.im * b.re
            );

        // Sprzężenie (operator unarny -)
        public static ComplexNumber operator -(ComplexNumber a)
            => new ComplexNumber(a.re, -a.im);

        // Clone()
        public object Clone()
            => new ComplexNumber(re, im);

        // Equals()
        public bool Equals(ComplexNumber other)
        {
            if (other == null) return false;
            return re == other.re && im == other.im;
        }

        public override bool Equals(object obj)
            => Equals(obj as ComplexNumber);

        public override int GetHashCode()
            => HashCode.Combine(re, im);

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
            => a?.Equals(b) ?? b is null;

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
            => !(a == b);

        // Obliczanie modułu
        public double Module()
            => Math.Sqrt(re * re + im * im);
    }

    public class Program
    {
        public static void Main()
        {
            ComplexNumber z1 = new ComplexNumber(7, 2);
            ComplexNumber z2 = new ComplexNumber(8, -9);

            Console.WriteLine("z1 = " + z1);
            Console.WriteLine("z2 = " + z2);

            Console.WriteLine("z1 + z2 = " + (z1 + z2));
            Console.WriteLine("z1 - z2 = " + (z1 - z2));
            Console.WriteLine("z1 * z2 = " + (z1 * z2));

            Console.WriteLine("-z1 (sprzężenie) = " + (-z1));

            Console.WriteLine("z1 == z2 ? " + (z1 == z2));
            Console.WriteLine("Moduł z1 = " + z1.Module());

            ComplexNumber z3 = (ComplexNumber)z1.Clone();
            Console.WriteLine("Kopia z1: " + z3);
        }
    }
