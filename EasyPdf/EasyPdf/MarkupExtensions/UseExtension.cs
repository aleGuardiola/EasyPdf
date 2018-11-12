using Portable.Xaml;
using Portable.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using EasyPdf.Xaml;

namespace EasyPdf.MarkupExtensions
{
    [MarkupExtensionReturnType(typeof(object))]
    public class UseExtension : MarkupExtension
    {
        string _member;

        public UseExtension(string member)
        {
            if(member==null) throw new NullReferenceException(nameof(member));
            _member = member;
        }

        [ConstructorArgument("member")]
        public string Member { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var rootObjService = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;

            var targetObject = target.TargetObject as PdfXamlObject;
            var targetProperty = target.TargetProperty as PropertyInfo;

            targetObject.Bindings.Add((targetProperty.Name, _member));

            return null;
        }

    }
}
