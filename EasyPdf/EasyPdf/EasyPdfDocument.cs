using EasyPdf.EasyPdfComponents;
using Portable.Xaml;

namespace EasyPdf
{
    public abstract class EasyPdfDocument
    {
        //Xaml code used to generate the pdf
        string _xamlCode;
        EDocument _document;

        public EasyPdfDocument()
        {
            
        }

        protected void Initialize(string xamlCode)
        {
            _xamlCode = xamlCode;
            _document = XamlServices.Load(xamlCode) as EDocument;                      
        }
    }
}
