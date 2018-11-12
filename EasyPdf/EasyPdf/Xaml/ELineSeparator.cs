using System;
using System.Collections.Generic;
using System.Text;
using iText.Layout;
using iText.Layout.Element;

namespace EasyPdf.Xaml
{
    public class ELineSeparator : EBlockElement
    {
        protected internal override void Build(Document pdfDoc)
        {
           // var lineSperator = new LineSeparator()

            base.Build(pdfDoc);
        }
    }
}
