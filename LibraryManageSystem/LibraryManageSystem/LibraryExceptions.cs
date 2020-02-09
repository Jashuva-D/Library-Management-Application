using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    public class InvalidBookException : Exception
    {
        public InvalidBookException(string msg) : base(msg)
        {

        }
    }
    public class InvalidAuthorException : Exception
    {
        public InvalidAuthorException(string msg) : base(msg)
        {

        }
    }
    public class InvalidPublisherException : Exception
    {
        public InvalidPublisherException(string msg) : base(msg)
        {

        }

    }
    public class InvalidMemberException : Exception
    {
        public InvalidMemberException(string msg) : base(msg)
        {

        }
    }

}
