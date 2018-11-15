using iText.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Xaml
{
    public class EBlockElementContainer<T> : EBlockElement where T : PdfXamlObject
    {
        public IList<T> Children { get; }

        public EBlockElementContainer()
        {
            Children = new List<T>();
        }
        
        protected internal override void OnBuild(Document pdfDoc, object model)
        {
            model = GetModel(model);
            base.OnBuild(pdfDoc, model);

            //Build for every children
            foreach (var child in Children)
                child.OnBuild(pdfDoc, model);
        }

    }
}
