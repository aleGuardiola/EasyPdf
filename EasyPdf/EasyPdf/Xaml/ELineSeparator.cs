using System;
using System.Collections.Generic;
using System.Text;
using iText.Layout;
using iText.Layout.Element;

namespace EasyPdf.Xaml
{
    public class ELineSeparator : EBlockElement
    {
        protected internal override void OnBuild(Document pdfDoc, object model)
        {
            // var lineSperator = new LineSeparator()
            model = GetModel(model);
            base.OnBuild(pdfDoc, model);
        }
    }
}
