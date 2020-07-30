using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class CompCollection : IEnumerable<Computer>
    {
        private List<Computer> computers;

        public IEnumerator<Computer> GetEnumerator()
        {
            return new CompEnumerator(computers);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(Computer computer)
        {
            computers.Add(computer);
        }

        public bool Remove(Computer computer)
        {
            return computers.Remove(computer);
        }

        public void Find()
        {
            //computers.Find(new Predicate<Computer> s);
        }
    }
}
