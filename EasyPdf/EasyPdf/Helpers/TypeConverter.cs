using iText.Kernel.Pdf.Colorspace;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Helpers
{
    internal static class TypeConverter
    {
        internal static iText.Kernel.Colors.Color ToITextColor(System.Drawing.Color color)
        {
            var dRGB = new iText.Kernel.Colors.DeviceRgb(color.R, color.G, color.B);
            return iText.Kernel.Colors.Color.MakeColor( dRGB.GetColorSpace() );
        }
    }
}
