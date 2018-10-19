using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace EasyPdf
{
    public class EPage : PdfXamlObjectContainer<PdfXamlObject>
    {       
        protected internal override void Build(Document pdfDoc)
        {
            var page = new AreaBreak(AreaBreakType.NEXT_PAGE);
            pdfDoc.Add(page);
            base.Build(pdfDoc);
        }
    }
}
