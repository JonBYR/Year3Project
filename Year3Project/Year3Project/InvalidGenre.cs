using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year3Project
{
    internal class InvalidGenre : Exception
    {
        public InvalidGenre(string genre) : base(String.Format("Invalid Genre: {0}", genre))
        {

        }
    }
}
