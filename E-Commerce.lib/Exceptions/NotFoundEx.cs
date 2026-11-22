using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.lib.Exceptions
{
    public class NotFoundEx(string message) : Exception(message)
    {

    }
}
