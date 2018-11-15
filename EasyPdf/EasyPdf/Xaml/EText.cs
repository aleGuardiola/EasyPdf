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
            set => Set(value);
        }

        public float HorizontalScaling
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public float SkewAlpha
        {
            get => (float)Get();
            set => Set(value);
        }

        public float SkewBeta
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public float TextRise
        {
            get => (float)Get();
            set => Set(value);
        }

        public EText()
        {
            Text = "";
        }

        internal Text GetText(object model)
        {
            var text = new Text((string)Get(nameof(Text), model) ?? "" );
            BuildElement<Text>(text, model);
            
            if(Exist(nameof(SkewAlpha)) || Exist(nameof(SkewBeta)))
            {
                var alpha = Exist(nameof(SkewAlpha)) ? Get(nameof(SkewAlpha), model) : 0f;
                var beta = Exist(nameof(SkewBeta)) ? Get(nameof(SkewBeta), model) : 0f;
            }

            if(Exist(nameof(TextRise)))
            {
                text.SetTextRise(TextRise);
            }

            return text;
        }

        protected internal override void OnBuild(Document pdfDoc, object model)
        {               
            base.OnBuild(pdfDoc, model);
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
