using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Polymorphism ile kalıtılan veya implemente edilen sınıfların nesnelerine farklı sınıflardan ulaşılabilir.
            //Tüm şekiller IGeometricObjects üzerinden implement edildiği için bu türde olan tüm farklı sınıfların
            //farklı işlemleri tek bir class üzerinden yönetilebilir. Polymorphism'in bu şekilde uygulanması
            //dinamik polimofrizme (runtime) örnek verilebilir. Bu türde CalculateArea hangi alt sınıf olduğu fark etmeksizin
            //çalışacaktır.
            GeometricManager geometricManager = new GeometricManager(new Rectangle());
            geometricManager.Calculate();

            //Statik Polymorphism Method Overloading ile ilişkilidir. Math nesnesinde hangi Sum metodunun çalışacağı
            //metot parametrelerine göre derleme zamanında belirlenir.
            Math math = new Math();
            int intSum = math.Sum(5, 12);
            double doubleSum = math.Sum(5.8, 13.7);
            Console.WriteLine(intSum);
            Console.WriteLine(doubleSum);

            Console.ReadLine();
        }
    }

    class GeometricManager
    {
        private IGeometricObjects _geometricObjects;
        public GeometricManager(IGeometricObjects geometricObjects)
        {
            _geometricObjects = geometricObjects;
        }
        public void Calculate()
        {
            _geometricObjects.CalculateArea();
        }
    }

    interface IGeometricObjects
    {
        void CalculateArea();
    }

    class Square : IGeometricObjects
    {
        public void CalculateArea()
        {
            Console.WriteLine("Kare alan hesabı: a x a");
        }
    }

    class Rectangle : IGeometricObjects
    {
        public void CalculateArea()
        {
            Console.WriteLine("Dikdörtgen alan hesabı: a x b");
        }
    }

    class Triangle : IGeometricObjects
    {
        public void CalculateArea()
        {
            Console.WriteLine("Üçgen alan hesabı: (a x h) / 2");
        }
    }

    class Math
    {
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public double Sum(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
