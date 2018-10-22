using System;
using System.Collections.Generic;
using System.Text;
using iText.Layout;
using iText.Layout.Element;
using Portable.Xaml.Markup;

namespace EasyPdf
{
    [ContentPropertyAttribute("Content")]
    public class EParagraph : EBlockElement
    {
        public IList<EText> Content { get; }

        public EParagraph()
        {
            Content = new List<EText>();
        }

        protected internal override void Build(Document pdfDoc)
        {
            var paragraph = new Paragraph();
            BuildElement<Paragraph>(paragraph);

            foreach (var content in Content)
                paragraph.Add(content.GetText());

            pdfDoc.Add(paragraph);

            base.Build(pdfDoc);
        }
    }
}
