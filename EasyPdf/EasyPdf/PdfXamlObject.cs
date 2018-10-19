using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyPdf
{
    public abstract class PdfXamlObject
    {
        IDictionary<string, object> _propContainer;
        public PdfXamlObject()
        {
            _propContainer = new Dictionary<string, object>();
        }

        protected void Set(string prop, object value)
        {
            _propContainer[prop] = value;
        }

        protected object Get(string prop)
        {
            return _propContainer[prop];            
        }

        protected bool Exist(string prop)
        {
            return _propContainer.ContainsKey(prop);
        }

        protected void Remove(string prop)
        {
            _propContainer.Remove(prop);
        }

        public MemoryStream GetPdf()
        {
            MemoryStream stream = new MemoryStream();
            var pdfDoc = new PdfDocument(new PdfWriter(stream));
            var document = new Document(pdfDoc);
            Build(document);
            document.Close();
            return stream;
        }

        protected internal virtual void Build(Document pdfDoc)
        {
            //Empty implementation
        }
    }
}
