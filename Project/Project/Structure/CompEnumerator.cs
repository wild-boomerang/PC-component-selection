using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class CompEnumerator : IEnumerator<Computer>
    {
        private List<Computer> computers;
        private int position = -1;

        public CompEnumerator(List<Computer> computers)
        {
            this.computers = computers;
        }

        public Computer Current
        {
            get
            {
                if (position == -1 || position >= computers.Count)
                {
                    throw new InvalidOperationException();
                }

                else
                    return computers[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (position < computers.Count - 1)
            {
                position++;
                return true;
            }

            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        { }
    }
}
