using System;
using System.Collections.Generic;
using System.Text;
using EasyPdf.Collections;
using iText.Layout;
using iText.Layout.Element;
using Portable.Xaml.Markup;

namespace EasyPdf.Xaml
{
    [ContentPropertyAttribute("Content")]
    public class EParagraph : EBlockElement
    {
        public IList<EText> Content { get; }

        public EParagraph()
        {
            Content = new ChildrenContainerList<EText>(this);
        }

        protected internal override void OnBuild(Document pdfDoc, object model)
        {
            model = GetModel(model);
            base.OnBuild(pdfDoc, model);

            var paragraph = new Paragraph();
            BuildElement<Paragraph>(paragraph, model);

            foreach (var content in Content)
                paragraph.Add(content.GetText(model));

            pdfDoc.Add(paragraph);
        }
    }
}
