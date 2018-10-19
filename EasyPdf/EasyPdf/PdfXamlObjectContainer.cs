using iText.Layout;
using Portable.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf
{
    [ContentPropertyAttribute("Children")]
    public abstract class PdfXamlObjectContainer<T> : PdfXamlObject where T : PdfXamlObject
    {
        public IList<T> Children { get; }

        public PdfXamlObjectContainer()
        {
            Children = new List<T>();
        }

        protected internal override void Build(Document pdfDoc)
        {
            base.Build(pdfDoc);

            //Build for every children
            foreach (var child in Children)
                child.Build(pdfDoc);
        }

    }
}
