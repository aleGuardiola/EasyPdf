using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace EasyPdf.Xaml
{
    public abstract class PdfXamlObject   
    {
        IDictionary<string, object> _propContainer;
        internal List<(string, string)> Bindings = new List<(string, string)>();

        public object Model { get => Get(nameof(Model)); set => Set(nameof(Model), value); }

        public PdfXamlObject Parent { get; internal set; }

        public PdfXamlObject(string xaml)
        {
            Initialize();
        }

        public PdfXamlObject()
        {
            Initialize();
        }

        void Initialize()
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
            SetValuesUsing();
        }

        protected void SetValuesUsing()
        {
            foreach (var bind in Bindings)
            {
                setBind(bind);
            }
        }

        private void setBind((string, string) b)
        {

            var member = b.Item2;

            if (b.Item1 == nameof(Model))
                Model = null;

            object model;
            PdfXamlObject node = this;

            do
            {
                if (node == null)
                    throw new NullReferenceException("Model is null");

                model = node.Exist(nameof(Model)) ? node.Model : null;
                node = node.Parent;

            } while(model == null);

            var members = member.Split('.');

            for(int i = 0; i < members.Length-1; i++)
            {
                var prop = getProperty(model.GetType(), members[i]);
                model = prop.GetValue(model);
                member = members[i+1];
            }                

            var property = getProperty(model.GetType(), member);
            var targetProperty = getProperty(this.GetType(), b.Item1);

            if (targetProperty.PropertyType == property.PropertyType)
            {
                var value = property.GetValue(model);
                Set(targetProperty.Name, value);
            }
            else
            {
                var val = property.GetValue(model);
                var converter = TypeDescriptor.GetConverter(targetProperty.PropertyType);

                if (!converter.CanConvertFrom(property.PropertyType))
                {
                    try
                    {
                        MethodInfo castMethod = this.GetType().GetMethod("Cast").MakeGenericMethod(targetProperty.PropertyType);
                        object castedObject = castMethod.Invoke(this, new object[] { val });

                        Set(targetProperty.Name, castedObject);
                        return;
                    }
                    catch(Exception e)
                    {
                        throw new InvalidCastException(string.Format("Cant convert from the member: {0} to the member: {1}", member, targetProperty.Name));
                    }
                }
                    
                var value = converter.ConvertFrom(val);
                Set(targetProperty.Name, value);
            }

        }

        public T Cast<T>(object o)
        {
            return (T)o;
        }

        static PropertyInfo getProperty(Type objectType, string prop)
        {
            return objectType.GetProperty(prop);
        }

    }

}
