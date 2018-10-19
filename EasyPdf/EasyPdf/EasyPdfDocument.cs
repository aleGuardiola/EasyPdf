using iText.Kernel.Pdf;
using iText.Layout;
using Portable.Xaml;
using System.IO;

namespace EasyPdf
{
    public abstract class EasyPdfDocument
    {
        //Xaml code used to generate the pdf
        bool initialized;
        string _xamlCode;
        EDocument _eDocument;
        
        public EasyPdfDocument()
        {
            
        }

        protected void Initialize(string xamlCode)
        {
            _xamlCode = xamlCode;
            _eDocument = XamlServices.Load(xamlCode) as EDocument;
            initialized = true;
        }

        MemoryStream GetPdf()
        {
            if (!initialized)
                throw new System.TypeInitializationException(nameof(EasyPdfDocument), null);

            MemoryStream stream = new MemoryStream();
            var pdfDoc = new PdfDocument(new PdfWriter(stream));
            var document = new Document(pdfDoc);
            _eDocument.Build(document);
            document.Close();

            return stream;
        }

    }
}
