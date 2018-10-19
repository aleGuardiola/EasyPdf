﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using iText.Layout;
using iText.Layout.Element;
using Portable.Xaml.Markup;

namespace EasyPdf
{
    [ContentPropertyAttribute("Content"), TypeConverter(typeof(ETextTypeConvert))]
    public class EText : PdfXamlObject
    {
        public string Content { get; set; }

        public Color FontColor
        {
            get => (Color)Get(nameof(FontColor));
            set => Set(nameof(FontColor), value);
        }

        public EText()
        {
            Content = "";
        }

        internal Text GetText()
        {
            var text = new Text(Content);

            if (Exist(nameof(FontColor)))
                text.SetFontColor(Helpers.TypeConverter.ToITextColor(FontColor));

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
            return new EText() { Content = v };
        }

    }
}
