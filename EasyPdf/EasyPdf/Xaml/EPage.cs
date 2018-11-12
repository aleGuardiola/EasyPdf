using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace EasyPdf.Xaml
{
    public class EPage : PdfXamlObjectContainer<PdfXamlObject>
    {
        internal bool FirstPage = false; 

        protected internal override void Build(Document pdfDoc)
        {
                        
            if(!FirstPage)
            {
                var page = new AreaBreak(AreaBreakType.NEXT_PAGE);
                pdfDoc.Add(page);
            }
           // iText.Layout.Element.LineSeparator
            base.Build(pdfDoc);
        }
    }
}
