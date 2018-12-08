using EasyPdf.Core;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Xaml
{
    public class EList : EBlockElementContainer<EListItem>
    {
        IEnumerable<object> source;



        public EList()
        {
            List l;
        }

        protected internal override void OnBuild(PdfElementContainer pdfDoc, object model)
        {
            model = GetModel(model);
            base.OnBuild(pdfDoc, model);
        }

    }
}
