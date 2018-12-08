using System;
using System.Collections.Generic;
using System.Text;
using EasyPdf.Core;
using EasyPdf.Helpers;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;

namespace EasyPdf.Xaml
{
    public class ELineSeparator : EBlockElement
    {

        public System.Drawing.Color Color
        {
            get => (System.Drawing.Color)Get();
            set => Set(value);
        }

        public float LineWidth
        {
            get => (float)Get();
            set => Set(value);
        }

        protected internal override void OnBuild(PdfElementContainer pdfDoc, object model)
        {
            model = GetModel(model);
            base.OnBuild(pdfDoc, model);

            var drawer = new Drawer();

            if(Exist(nameof(Color)))
            {
                var color = (System.Drawing.Color)Get(nameof(Color), model);
                drawer.SetColor(TypeConverter.ToITextColor(color));
            }

            if(Exist(nameof(LineWidth)))
            {
                var lineWidth = (float)Get(nameof(LineWidth));
                drawer.SetLineWidth(lineWidth);
            }

            var lineSperator = new LineSeparator(drawer);
            BuildElement<LineSeparator>(lineSperator, model);
            
        }

        class Drawer : ILineDrawer
        {

            Color color;
            float width = 5f;

            public Drawer()
            {

            }

            public void Draw(PdfCanvas canvas, Rectangle drawArea)
            {
                canvas.Rectangle(drawArea).SetColor(color, true);

                throw new NotImplementedException();
            }

            public Color GetColor()
            {
                return color == null ? ColorConstants.BLACK : color;
            }

            public float GetLineWidth()
            {
                return width;
            }

            public void SetColor(Color color)
            {
                this.color = color;
            }

            public void SetLineWidth(float lineWidth)
            {
                this.width = lineWidth;
            }
        }

    }
}
