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

            //Parallel.ForEach(new bool[10000],(v)=>{
            //    var example = new Example();
            //    example.Model = new TestModel()
            //    {
            //        Header = new HeaderModel()
            //        {
            //            Title = "Bass Insurance",
            //            Subtitle = "Form 1"
            //        },
            //        Name = "Alejandro",
            //        BackgroundColor = Color.Blue
            //    };
            //    example.GetPdf();
            //});
            
            for(int i = 0; i < 10000; i++)
            {
                var example = new Example();
                example.Model = new TestModel()
                {
                    Header = new HeaderModel()
                    {
                        Title = "Bass Insurance",
                        Subtitle = "Form 1"
                    },
                    Name = "Alejandro",
                    BackgroundColor = Color.Blue
                };
                example.GetPdf();
            }

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
