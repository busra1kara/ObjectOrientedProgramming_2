using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OppGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Category category = new Category(1, "Elektronik");
            CategoryManager categoryManager = new CategoryManager();
            categoryManager.Add(category);

            Console.ReadLine();
        }
    }

    public class Category
    {
        public Category(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }

    public class Product
    {
        public Product(int ıd, string productName, string description)
        {
            Id = ıd;
            ProductName = productName;
            Description = description;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
    }

    public class Customer
    {
        public Customer(int ıd, string firstName, string lastName)
        {
            Id = ıd;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }

    //Ekleme, silme ve güncelleme operasyonları hepsi için aynı olacağından Generic Type bir interface tanımlarsak
    //farklı sınıflara ihtiyaç duymadan tek bir interface ile tüm entity sınıflarının ekleme, güncelleme ve silme
    //işlemlerini yapabiliriz.
    public interface IOperation<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    //Customer, product ve category işlemlerinde sınıfların kendi managerlarında farklı işlermler de olacağı için
    //manager interfaceleri her bir entity için yine ayrı olarak oluşturabiliriz.
    public interface ICategoryManager : IOperation<Category> 
    {
        void CategoryNameInfo();
    }
    public interface IProductManager : IOperation<Product>
    {
        void DescriptionInfo();
    }
    public interface ICustomerManager : IOperation<Customer>
    {
        void AddressInfo();
    }
    public class CategoryManager : ICategoryManager
    {
        public void Add(Category entity)
        {
            Console.WriteLine($"{entity.CategoryName} kategorisi eklendi");
        }

        public void CategoryNameInfo()
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductManager : IProductManager
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DescriptionInfo()
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerManager : ICustomerManager
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void AddressInfo()
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
