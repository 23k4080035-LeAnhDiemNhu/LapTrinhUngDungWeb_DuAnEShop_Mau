using System.Collections.Generic;

namespace BlazorApp1_Demo.Data
{
    // CLASS A: CustomerServiceProblem (Phụ thuộc trực tiếp vào Class B)
    public class CustomerServiceProblem
    {
        private CustomerDataAccess custDA;

        public CustomerServiceProblem()
        {
            // Vấn đề: Phụ thuộc cứng (Tight Coupling) qua từ khóa 'new'
            custDA = new CustomerDataAccess();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return custDA.GetCustomers();
        }
    }

    // CLASS B: CustomerDataAccess (Lớp truy cập dữ liệu ban đầu)
    public class CustomerDataAccess
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer A" },
                new Customer { Id = 2, Name = "Customer B" }
            };
        }
    }

    // CLASS B': CustomerDataAccessSQL (Lớp truy cập dữ liệu mới - SQL Server)
    public class CustomerDataAccessSQL
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 101, Name = "SQL Customer 1" }
            };
        }
    }

    // Model đại diện Khách hàng
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
