using System.Collections.Generic;

namespace BlazorApp1_Demo.Data
{
    // BƯỚC 1: Abstraction Interface - Trừu tượng hóa truy cập dữ liệu
    public interface ICustomerDataAccess
    {
        IEnumerable<Customer> GetCustomers();
    }

    // BƯỚC 2A: Class B1 - Triển khai ICustomerDataAccess (Dữ liệu In-Memory)
    public class CustomerDataAccessSolution : ICustomerDataAccess
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer A (DI Solution)" },
                new Customer { Id = 2, Name = "Customer B (DI Solution)" }
            };
        }
    }

    // BƯỚC 2B: Class B2 - Triển khai ICustomerDataAccess (Dữ liệu SQL Server)
    public class CustomerDataAccessSQLSolution : ICustomerDataAccess
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 101, Name = "SQL Customer (DI Solution)" }
            };
        }
    }

    // BƯỚC 3A: Class A - Sử dụng Constructor Injection
    public class CustomerServiceConstructorInjection
    {
        private readonly ICustomerDataAccess _custDA;

        // Constructor Injection: Tiêm phụ thuộc qua Constructor của lớp
        public CustomerServiceConstructorInjection(ICustomerDataAccess custDA)
        {
            _custDA = custDA;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _custDA.GetCustomers();
        }
    }

    // BƯỚC 3B: Class A - Sử dụng Setter Injection
    public class CustomerServiceSetterInjection
    {
        // Setter Injection: Tiêm phụ thuộc qua Property Setter
        public ICustomerDataAccess CustDataAccess { get; set; } = default!;

        public IEnumerable<Customer> GetCustomers()
        {
            return CustDataAccess?.GetCustomers() ?? new List<Customer>();
        }
    }

    // BƯỚC 4: Demo Interface (IAnimal, Dog, Cat) đảo ngược phụ thuộc
    public interface IAnimal
    {
        string AnimalSound();
    }

    public class Dog : IAnimal
    {
        public string AnimalSound() => "Dog sound: Woof Woof";
    }

    public class Cat : IAnimal
    {
        public string AnimalSound() => "Cat sound: Meow Meow";
    }

    public class AnimalPetService
    {
        private readonly IAnimal _pet;

        public AnimalPetService(IAnimal pet)
        {
            _pet = pet;
        }

        public string MakeSound()
        {
            return _pet.AnimalSound();
        }
    }
}
