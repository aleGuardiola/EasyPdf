using Portable.Xaml;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using EasyPdf.Xaml;
using System.IO;

namespace EasyPdf
{
    public static class EasyPdfXamlCompiler
    {
        public static T Compile<T>(string easyPdf) where T : PdfXamlObject
        {
            return XamlServices.Parse(easyPdf) as T;
        }

        public static T Compile<T>(Stream stream) where T : PdfXamlObject
        {
            return XamlServices.Load(stream) as T;
        }

        public static T CompileResource<T>(string resourceName, Assembly assembly) where T : PdfXamlObject
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                return XamlServices.Load(stream) as T;
            }                
        }

    }
}
