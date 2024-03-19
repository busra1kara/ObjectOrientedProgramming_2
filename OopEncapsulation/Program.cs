using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopEncapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //name field'ı private olarak atansa da get ve set metodlarıyla name'e erişim sağlayabiliriz.
            Ogrenci ogrenci1 = new Ogrenci();
            ogrenci1.setName("Hakan");
            string ogrenciName = ogrenci1.getName();
            ogrenci1.TcNumber = 12345678912;
            Console.WriteLine(ogrenciName);
            Console.WriteLine(ogrenci1.TcNumber);

            Console.ReadLine();
        }
    }

    class Ogrenci
    {
        private string _name;
        private long _tcNumber;
        //Gerçek projelerde kişinin TC numarasına her yerden erişilmesini istemeyeceğimiz için bu şekilde
        //projenin farklı yerlerinde kullanmak isteyeceğimiz ama her yerden erişilmesini istemediğimiz
        //veriler için Encapsulation ile kapsülleme yaparak farklı şekillerde ulaşabiliriz.
        public void setName(string name)
        {
            _name = name;
        }
        public string getName()
        {
            return _name;
        }
        public long TcNumber
        {
            get { return _tcNumber; }
            set 
            {
                if (value.ToString().Length == 11) _tcNumber = value;
                else Console.WriteLine("TC numarası 11 haneli olmalıdır");
            }
        }
    }
}
