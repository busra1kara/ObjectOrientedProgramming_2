using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OopInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonCompany personCompany = new PersonCompany();
            personCompany.FirstName = "Ali";
            personCompany.CreditCarNumber = "123456";
            CorporateCompany corporateCompany = new CorporateCompany();
            corporateCompany.CompanyName = "ASUS";
            corporateCompany.TaxNumber = 845789;

            //KALITIMDA CONSTRUCTOR KULLANIMI
            Director director = new Director("Duygu", "Yılmaz", "Maliye");
            director.ShowInfo();
            director.DirectorShowInfo();

            //INTERFACE ile ÇOKLU KALITIM
            Guitar guitar = new Guitar(1, "Gitar", "Akustik Gitar", "Telli");
            guitar.WriteInstrument();
            guitar.CleanType();
            guitar.TuningType();
            InstrumentManager instrumentManager = new InstrumentManager(new Piano(2, "Piyano", "Kuyruklu Piyano", "Tuşlu"));
            instrumentManager.InstrumentOperations();

            Console.ReadLine();
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }

    class PersonCompany : Customer
    {
        public string CreditCarNumber { get; set; }
    }

    class CorporateCompany : Customer
    {
        public int TaxNumber { get; set; }
    }


    //KALITIMDA CONSTRUCTOR KULLANIMI
    class Personnel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Personnel(string name, string userName)
        {
            FirstName = name;
            LastName = userName;
        }
        public void ShowInfo()
        {
            Console.WriteLine("Personel adı ve soyadı: " + FirstName + " " + LastName);
        }
    }

    class Director : Personnel
    {
        public string Department {  get; set; }
        public Director(string firstName, string lastName, string department) : base(firstName, lastName)
        {
            //base inherit edilen sınıfın parametreli constructor metodunu çağırır. base ile alt sınıf
            //kalıtıldığı sınıfın constructor metoduna ulaşabilir. Director'ın Constructor metodu
            //çalışmadan Personnel'in Constructor metodu çalışır.
            Department = department;
        }
        public void DirectorShowInfo()
        {
            Console.WriteLine("Personel Ad ve Soyadı: " + FirstName + " " + LastName + ", Departmanı: " + Department);
        }
    }


    //INTERFACE ile ÇOKLU KALITIM
    class Instrument
    {
        public Instrument(int id, string name, string description, string playType)
        {
            Id = id;
            Name = name;
            Description = description;
            PlayType = playType;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PlayType { get; set; }
        public void WriteInstrument()
        {
            Console.WriteLine($"{Id}, {Name}, {Description}, {PlayType}");
        }
    }

    interface ISettingsIsntrument
    {
        void TuningType();
        void CleanType();
    }

    class InstrumentManager
    {
        ISettingsIsntrument _settingsIsntrument;
        public InstrumentManager(ISettingsIsntrument settingsIsntrument)
        {
            _settingsIsntrument = settingsIsntrument;
        }

        public void InstrumentOperations()
        {
            _settingsIsntrument.CleanType();
            _settingsIsntrument.TuningType();
        }
    }

    class Guitar : Instrument, ISettingsIsntrument
    {
        public Guitar(int id, string name, string description, string playType) : base(id, name, description, playType)
        {
        }

        public void CleanType()
        {
            Console.WriteLine("Gitar temizleme şekli...");
        }

        public void TuningType()
        {
            Console.WriteLine("Gitar akort şekli...");
        }
    }

    class Piano : Instrument, ISettingsIsntrument
    {
        public Piano(int id, string name, string description, string playType) : base(id, name, description, playType)
        {
        }

        public void CleanType()
        {
            Console.WriteLine("Piano temizleme şekli...");
        }

        public void TuningType()
        {
            Console.WriteLine("Piano akort şekli...");
        }
    }
}
