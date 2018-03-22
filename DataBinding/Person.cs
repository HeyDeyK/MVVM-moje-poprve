using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding
{
    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Rad { get; set; }


        public Person(string name,int id,string rad)
        {
            this.Name = name;
            this.Id = id;
            this.Rad = rad;
        }

        
    }
}
