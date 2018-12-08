using EasyPdf.Collections;
using EasyPdf.Core;
using iText.Layout;
using Portable.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Xaml
{
    [ContentPropertyAttribute("Children")]
    public abstract class PdfXamlObjectContainer<T> : PdfXamlObject where T : PdfXamlObject
    {
        public IList<T> Children { get; }

        public PdfXamlObjectContainer()
        {
            Children = new ChildrenContainerList<T>(this);
        }

        protected internal override void OnBuild(PdfElementContainer pdfDoc, object model)
        {
            model = GetModel(model);

            //Build for every children
            foreach (var child in Children)
                child.OnBuild(pdfDoc, model);
        }

    }
}
