using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using EasyPdf.Core;
using iText.Layout;

namespace EasyPdf.Xaml
{
    [Portable.Xaml.Markup.ContentPropertyAttribute("Children")]
    public class EDocument : PdfXamlObjectContainer<EPage>
    {
        protected internal override void OnBuild(PdfElementContainer pdfDoc, object model)
        {
            model = GetModel(model);

            if (Children.Count > 0)
                Children[0].FirstPage = true;

            base.OnBuild(pdfDoc, model);
        }
    }
}
