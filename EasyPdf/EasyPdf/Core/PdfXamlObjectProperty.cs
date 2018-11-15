using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace EasyPdf.Core
{
    public class PdfXamlObjectProperty
    {
        Type type;
        string name;
        string bindingValue;
        object staticValue;

        internal PdfXamlObjectProperty(Type type, string name)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }
        
        internal void SetValue(string bindingValue)
        {
            this.bindingValue = bindingValue;
        }

        internal void SetValue(object value)
        {
            staticValue = value;
        }

        internal object GetValue(object model)
        {
            if (model == null || bindingValue == null)
                return staticValue;

            var member = bindingValue;
            var targerType = type;

            var property = getProperty(model.GetType(), member);

            var value = property.GetValue(model);

            if (targerType == property.PropertyType)
                return value;

            var converter = TypeDescriptor.GetConverter(property.PropertyType);
            if (converter.CanConvertTo(targerType))
                return converter.ConvertTo(value, targerType);

            try
            {
                MethodInfo castMethod = this.GetType().GetMethod("j").MakeGenericMethod(targerType);
                object castedObject = castMethod.Invoke(this, new object[] { value });

                return castedObject;
            }
            catch (Exception e)
            {
                throw new InvalidCastException(string.Format("Cant convert from the member: {0} to the member: {1}", member, name));
            }
        }

        public T j<T>(object o)
        {
            return (T)o;
        }

        static PropertyInfo getProperty(Type objectType, string prop)
        {
            return objectType.GetProperty(prop);
        }

    }


}
