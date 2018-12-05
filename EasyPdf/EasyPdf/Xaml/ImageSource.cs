using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;

namespace EasyPdf.Xaml
{
    [TypeConverter(typeof(ImageSourceTypeConverter))]
    public abstract class ImageSource
    {
        public abstract byte[] GetBytes();
    }

    public class ImageSourceTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var strValue = (string)value;

            var uri = new Uri(strValue);

            if (uri.IsFile)
                return new FileImageSource(strValue);

            if (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                return new HttpImageSource(strValue);

            throw new UriFormatException("The provided string is not a file or a http resource.");
        }

    }

    public class HttpImageSource : ImageSource
    {
        string url;

        public HttpImageSource(string url)
        {
            this.url = url;
        }

        public override byte[] GetBytes()
        {
            var client = new WebClient();
            var bytes = client.DownloadData(url);
            return bytes;
        }
    }

    public class FileImageSource : ImageSource
    {
        string path;

        public FileImageSource(string path)
        {
            this.path = path;
        }

        public override byte[] GetBytes()
        {
            var bytes = File.ReadAllBytes(path);
            return bytes;
        }
    }

}