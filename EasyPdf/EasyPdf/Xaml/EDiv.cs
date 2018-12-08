using EasyPdf.Core;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Xaml
{
    public class EDiv : EBlockElementContainer<PdfXamlObject>
    {
        public bool FillAvailableArea
        {
            get => (bool)Get();
            set => Set(value);
        }
        public bool FillAvailableAreaOnSplit
        {
            get => (bool)Get();
            set => Set(value);
        }       

        protected internal override void OnBuild(PdfElementContainer pdfDoc, object model)
        {
            model = GetModel(model);
            base.OnBuild(pdfDoc, model);
             
            var div = new Div();
            BuildElement<Div>(div, model);

            if(Exist(nameof(FillAvailableArea)))
            {
                var fillAvailableArea = (bool)Get(nameof(FillAvailableArea), model);
                div.SetFillAvailableArea(fillAvailableArea); 
            }

            if (Exist(nameof(FillAvailableAreaOnSplit)))
            {
                var fillAvailableArea = (bool)Get(nameof(FillAvailableAreaOnSplit), model);
                div.SetFillAvailableAreaOnSplit(fillAvailableArea);
            }

            var container = new PdfElementContainer();
            foreach(var child in Children)
            {
                child.OnBuild(container, model);
            }

            foreach(var e in container)
            {
                var type = e.GetType();

                if (type == typeof(IBlockElement))
                    div.Add((IBlockElement)e);
                else if (type == typeof(AreaBreak))
                    div.Add((AreaBreak)e);
                else
                    div.Add((Image)e);
            }

            pdfDoc.Add(div);
        }

    }
}
