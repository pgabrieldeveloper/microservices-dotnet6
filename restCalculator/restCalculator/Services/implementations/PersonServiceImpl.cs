using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Threading;
using restCalculator.Model;

namespace restCalculator.Services.implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public Person Update(Person person)
        {
            return person;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                Address = "Aracaju - Sergipe - Brasil",
                Gender = "male",
                Name = "Paulo Gabriel"
            };
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = mockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public void Delete(long id)
        {
            
        }
        private Person mockPerson(int i)
        { 
            return new Person
            {
                Id = IncrementAndGet(),
                Address = "Aracaju - Sergipe - Brasil" + IncrementAndGet(),
                Gender = "male",
                Name = "Paulo Gabriel"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}