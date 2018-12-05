using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using EasyPdf;
using EasyPdf.Xaml;
using Portable.Xaml;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var pdf = new Example();
            Console.WriteLine("parseTime: {0}", (DateTime.Now - startTime).TotalSeconds);

            var model = new TestModel()
            {
                BackgroundColor = Color.Blue,
                Header = new HeaderModel()
                {
                    Title = "BassUw",
                    Subtitle = "Best Underwriters"
                },
                Name = "Alejo Guardiola"
            };

            //File.WriteAllBytes("", pdf.GetPdf(model));
            
            //for(int i = 0; i < 10000; i++)
            //pdf.GetPdf(model);
            

            //for (int i = 0; i < 100; i++)
            //    pdf.GetPdf(model);

            File.WriteAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.pdf"), pdf.GetPdf(model));

            Console.WriteLine("totalTime: {0}", (DateTime.Now - startTime).TotalSeconds);
            Console.Read();
        }
    }

    public class HeaderModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }

    public class TestModel
    {
        public HeaderModel Header{ get; set; }

        public string Name { get; set; }
        public Color BackgroundColor { get; set; }
    }


}
