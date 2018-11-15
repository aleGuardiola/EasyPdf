using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Exceptions
{
    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException(string member, Type type) : base($"Member {member} not found in type {type.FullName}.")
        {
            
        }
    }
}
