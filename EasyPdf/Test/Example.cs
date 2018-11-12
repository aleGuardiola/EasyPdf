using EasyPdf.Xaml;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Test
{
    public class Example : ReferencePdfXamlObject
    {
        protected override void Initialize(PdfBuilder builder)
        {
            builder.Build("Test.Example.xaml", Assembly.GetExecutingAssembly());
        }
    }
}
