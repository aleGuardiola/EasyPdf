using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using iText.Layout;

namespace EasyPdf
{
    [Portable.Xaml.Markup.ContentPropertyAttribute("Children")]
    public class EDocument : PdfXamlObjectContainer<EPage>
    {
        public Color BackgroundColor
        {
            get => (Color)Get(nameof(BackgroundColor));
            set => Set(nameof(BackgroundColor), value);
        }

        protected internal override void Build(Document pdfDoc)
        {
            if (Exist(nameof(BackgroundColor)))
                pdfDoc.SetBackgroundColor(Helpers.TypeConverter.ToITextColor(BackgroundColor));
                       
            if (Children.Count > 0)
                Children[0].FirstPage = true;

            base.Build(pdfDoc);
        }
    }
}
