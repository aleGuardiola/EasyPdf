using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using iText.Layout;
using iText.Layout.Element;
using Portable.Xaml.Markup;

namespace EasyPdf.Xaml
{

    [ContentPropertyAttribute("Text"), TypeConverter(typeof(ETextTypeConvert))]
    public class EText : Element
    {
        public string Text {
            get => (string)Get(nameof(Text));
            set => Set(nameof(Text), value);
        }

        public float HorizontalScaling
        {
            get => (float)Get(nameof(HorizontalScaling));
            set => Set(nameof(HorizontalScaling), value);
        }
        
        public float SkewAlpha
        {
            get => (float)Get(nameof(SkewAlpha));
            set => Set(nameof(SkewAlpha), value);
        }

        public float SkewBeta
        {
            get => (float)Get(nameof(SkewBeta));
            set => Set(nameof(SkewBeta), value);
        }
        
        public float TextRise
        {
            get => (float)Get(nameof(TextRise));
            set => Set(nameof(TextRise), value);
        }

        public EText()
        {
            Text = "";
        }

        internal Text GetText()
        {
            SetValuesUsing();

            var text = new Text(Text);
            BuildElement<Text>(text);
            
            if(Exist(nameof(SkewAlpha)) || Exist(nameof(SkewBeta)))
            {
                var alpha = Exist(nameof(SkewAlpha)) ? SkewAlpha : 0f;
                var beta = Exist(nameof(SkewBeta)) ? SkewBeta : 0f;
            }

            if(Exist(nameof(TextRise)))
            {
                text.SetTextRise(TextRise);
            }

            return text;
        }

        protected internal override void Build(Document pdfDoc)
        {               
            base.Build(pdfDoc);
        }
    }

    public class ETextTypeConvert : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var v = value as string;
            return new EText() { Text = v };
        }

    }
}
