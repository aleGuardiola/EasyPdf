using System;
using System.Collections.Generic;
using System.Text;
using iText.Layout;
using iText.Layout.Element;
using Portable.Xaml.Markup;

namespace EasyPdf
{
    [ContentPropertyAttribute("Content")]
    public class EParagraph : PdfXamlObject
    {
        public EText Content { get; set; }

        public EParagraph()
        {
            Content = new EText();
        }

        protected internal override void Build(Document pdfDoc)
        {
            var paragraph = new Paragraph(Content.GetText());

            pdfDoc.Add(paragraph);

            base.Build(pdfDoc);
        }
    }
}
