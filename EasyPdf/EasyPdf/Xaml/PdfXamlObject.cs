﻿using EasyPdf.Core;
using EasyPdf.Exceptions;
using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace EasyPdf.Xaml
{
    public abstract class PdfXamlObject   
    {
        IDictionary<string, PdfXamlObjectProperty> _propContainer;
        
        public string Model { get => (string)Get(); set => Set(value); }

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
            _propContainer = new Dictionary<string, PdfXamlObjectProperty>();
        }

        protected void Set( object value, [CallerMemberName]string prop = "" )
        {
            if(_propContainer.ContainsKey(prop))
            {
                _propContainer[prop].SetValue(value);
            }
            else
            {
                var property = new PdfXamlObjectProperty(value.GetType(), prop);
                property.SetValue(value);
                _propContainer[prop] = property;
            }
        }

        internal void Set(string prop, string bindingValue, Type type)
        {
            if (_propContainer.ContainsKey(prop))
            {
                _propContainer[prop].SetValue(bindingValue);
            }
            else
            {
                var property = new PdfXamlObjectProperty(type, prop);
                property.SetValue(bindingValue);
                _propContainer[prop] = property;
            }
        }

        protected object Get([CallerMemberName]string prop="")
        {
            return _propContainer[prop].GetValue(null);            
        }

        protected object Get(string prop, object model)
        {
            return _propContainer[prop].GetValue(model);
        }

        protected bool Exist([CallerMemberName]string prop="")
        {
            return _propContainer.ContainsKey(prop);
        }

        protected void Remove([CallerMemberName]string prop="")
        {
            _propContainer.Remove(prop);
        }

        public byte[] GetPdf(object model)
        {
#if DEBUG
            var startBuilding = DateTime.Now;
#endif

            using (MemoryStream stream = new MemoryStream())
            {
                using (var writer = new PdfWriter(stream))
                {
                    var pdfDoc = new PdfDocument(writer);
                    var document = new Document(pdfDoc);
                    OnBuild(document, model);
                    document.Close();
                }
#if DEBUG
                Console.WriteLine("buildingTime: {0}", (DateTime.Now - startBuilding).TotalSeconds);
#endif
                return stream.ToArray();
            }


            

        }
        
        public object GetModel(object model)
        {
            if ( !Exist(nameof(Model)))
                return model;
            else
            {
                var m = (string)Get(nameof(Model), model);
                if (string.IsNullOrEmpty(m) || m == ".")
                    return model;

                var path = m.Split('.');

                var type = model.GetType();

                foreach (var name in path)
                {
                    var propInfo = type.GetProperty(name);

                    if (propInfo == null)
                        throw new MemberNotFoundException(name, type);

                    model = propInfo.GetValue(model);
                    type = model.GetType();
                }

                return model;
            }
        }

        protected internal virtual void OnBuild(Document pdfDoc, object model)
        {
            
        }  

    }

}
