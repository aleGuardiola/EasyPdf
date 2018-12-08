using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Core
{
    public class PdfElementContainer : IReadOnlyList<object>
    {
        List<object> elements;
        public PdfElementContainer()
        {
            elements = new List<object>();
        }

        public void Add(IBlockElement element)
        {
            elements.Add(element);
        }
        
        public void Add(Image element)
        {
            elements.Add(element);
        }

        public void Add(AreaBreak areaBreak)
        {
            elements.Add(areaBreak);
        }

        public object this[int index] => elements[index];

        public int Count => elements.Count;

        public IEnumerator<object> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
