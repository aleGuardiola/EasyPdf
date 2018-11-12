using iText.Layout;
using Portable.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace EasyPdf.Xaml
{
    public abstract class ReferencePdfXamlObject : PdfXamlObject
    {
        public PdfXamlObject Root { get; private set; }
        
        public ReferencePdfXamlObject()
        {
            var builder = new PdfBuilder(this);
            Initialize(builder);

            if (!builder.isBuilt)
                throw new InvalidOperationException("You have to call Build() to initialize the object");
        }

        protected abstract void Initialize(PdfBuilder builder);
        
        protected internal override void Build(Document pdfDoc)
        {
            base.Build(pdfDoc);
            Root.Build(pdfDoc);            
        }


        public class PdfBuilder
        {
            ReferencePdfXamlObject refObj;
            internal bool isBuilt = false;

            internal PdfBuilder(ReferencePdfXamlObject refObj)
            {
                this.refObj = refObj;
            }

            public void Build(string xaml)
            {
                throwIfBuilt();
                var value = EasyPdfXamlCompiler.Compile<PdfXamlObject>(xaml);
                value.Parent = refObj;
                refObj.Root = value;

                isBuilt = true;
            }

            public void Build(string resource, Assembly assembly)
            {
                throwIfBuilt();
                var value = EasyPdfXamlCompiler.CompileResource<PdfXamlObject>(resource, assembly);
                value.Parent = refObj;
                refObj.Root = value;

                isBuilt = true;
            }

            public void Build(Stream stream)
            {
                throwIfBuilt();
                var value = EasyPdfXamlCompiler.Compile<PdfXamlObject>(stream);
                value.Parent = refObj;
                refObj.Root = value;

                isBuilt = true;
            }

            public void Build(PdfXamlObject root)
            {
                throwIfBuilt();
                if (root == null)
                    throw new NullReferenceException("The root cant be null");
                root.Parent = refObj;
                refObj.Root = root;

                isBuilt = true;
            }

            void throwIfBuilt()
            {
                if (isBuilt)
                    throw new InvalidOperationException("You can call Build only one time");
            }

        }

    }


}
