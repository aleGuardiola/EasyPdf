using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using EasyPdf;
using Portable.Xaml;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Test.Example.xaml";
              
            TimeSpan diff;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();

                var currentTime = DateTime.Now;
                var myResult = XamlServices.Parse(result) as EDocument;
                
                diff = DateTime.Now - currentTime;

               // myResult.GetPdf();
                File.WriteAllBytes(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.pdf"),
                    myResult.GetPdf().ToArray());
            }

            Console.WriteLine("Time parsing: {0} Milliseconds", diff.Milliseconds);
            Console.Read();
        }
    }

    [TypeConverter(typeof(MyClassConverter))]
    public class Binding
    {
        public string Source{ get; set; }

        //public string GetResult()
        //{
            
        //}

    }

    public class MyClassConverter : TypeConverter
    {
         public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return "Alejo";
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return new Binding() { Source = "Tu madre" };
        }
               

    }

    public class XamlName
    {
        string name;
        public string Name {
            get=>name;
            set {
                name = value;
            }
        }
    }

    public static class Example
    {
        public static string Name = "Alejandro";
    }


}
