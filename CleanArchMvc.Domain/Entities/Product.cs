using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0,
            "Invalid id value");
            Id = id;

            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = CategoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid Name is required");

            DomainExceptionValidation.When(name.Length < 3,
           "Invalid Name is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
            "Invalid description is required");

            DomainExceptionValidation.When(name.Length < 5,
           "Invalid description is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image),
           "Invalid Name is required");

            DomainExceptionValidation.When(name.Length > 250,
           "Invalid Name is required");

            DomainExceptionValidation.When(price < 0,
           "invalid price value");

            DomainExceptionValidation.When(stock < 0,
           "invalid stock value");
        }

        //chave estrangeira
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
