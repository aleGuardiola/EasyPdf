using EasyPdf.Core;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Xaml
{
    public class EListItem : EDiv
    {
        public EListItem()
        {
            
        }

        protected internal override void OnBuild(PdfElementContainer pdfDoc, object model)
        {
            base.OnBuild(pdfDoc, model);
            model = GetModel(model);



        }

    }
}
