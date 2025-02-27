using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Domain.Common;
using ProductDemo.Domain.ValueObjects;

namespace ProductDemo.Domain.Entities
{
    public class Customer : BaseEntity
    {
       
        public string Name { get; private set; }
        public int Age { get; set; }
        public Address Address { get; private set; }

        public Customer()
        {
            
        }
        public Customer(string name, int age, Address address)
        {
            Name = name;
            Age = age;
            Address = address;
        }
    }
}
