using DDD.Sample.Infrastructure.Interface.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sample.Domain.Aggregate
{
    public partial class Student : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public byte[] RowVersion { get; set; }

        public void ModifyInfo(string name, int age)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }

            if (age > 0 && age < 100)
            {
                Age = age;
            }
        }
    }
}
