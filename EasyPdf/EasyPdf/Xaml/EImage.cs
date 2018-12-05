using iText.IO.Image;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Xaml
{
    public class EImage : PdfXamlObject
    {
        public ImageSource Source
        {
            get => (ImageSource)Get();
            set => Set(value);
        }

        public float HorizontalScale
        {
            get => (float)Get();
            set => Set(value);
        }

        public float VerticalScale
        {
            get => (float)Get();
            set => Set(value);
        }

        public bool AutoScale
        {
            get => (bool)Get();
            set => Set(value);
        }

        public bool AutoScaleHeight
        {
            get => (bool)Get();
            set => Set(value);
        }

        public bool AutoScaleWidth
        {
            get => (bool)Get();
            set => Set(value);
        }

        public bool FixedPositionLeft
        {
            get => (bool)Get();
            set => Set(value);
        }

        public bool FixedPositionBottom
        {
            get => (bool)Get();
            set => Set(value);
        }

        public float Height
        {
            get => (float)Get();
            set => Set(value);
        }

        public float MarginBottom
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public float MarginLeft
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public float MarginRight
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public float MarginTop
        {
            get => (float)Get();
            set => Set(value);
        }

        public float MaxHeight
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public float MaxWidth
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public float MinHeight
        {
            get => (float)Get();
            set => Set(value);
        }

        public float MinWidth
        {
            get => (float)Get();
            set => Set(value);
        }
       
        public float PaddingBottom
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public float PaddingLeft
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public float PaddingRight
        {
            get => (float)Get();
            set => Set(value);
        }

        public float PaddingTop
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public double RadiansRotationAngle
        {
            get => (double)Get();
            set => Set(value);
        }
        
        public float Width
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public EImage()
        {
           
        }

        protected internal override void OnBuild(Document pdfDoc, object model)
        {
            model = GetModel(model);

            base.OnBuild(pdfDoc, model);

            if (!Exist(nameof(Source)))
                throw new MissingMemberException($"Member {nameof(ImageSource)} is required in an EImage Element.");

            var imageSource = (ImageSource)Get(nameof(Source), model);
            var image = new Image(ImageDataFactory.Create(imageSource.GetBytes()));

            var width = Exist(nameof(Width)) ? (float)Get(nameof(Width), model) : 0f;
            image.SetWidth(width);
            
            var height = Exist(nameof(Height)) ? (float)Get(nameof(Height), model) : 0f;
            image.SetHeight(height);

            var horizontalScale = Exist(nameof(HorizontalScale)) ? (float)Get(nameof(HorizontalScale), model) : 1f;
            var verticalScale = Exist(nameof(VerticalScale)) ? (float)Get(nameof(VerticalScale), model) : 1f;
            image.Scale(horizontalScale, verticalScale);

            var autoScale = Exist(nameof(AutoScale)) ? (bool)Get(nameof(AutoScale), model) : false;
            image.SetAutoScale(autoScale);

            var autoScaleHeight = Exist(nameof(AutoScaleHeight)) ? (bool)Get(nameof(AutoScaleHeight), model) : false;
            image.SetAutoScaleHeight(autoScaleHeight);

            var autoScaleWidth = Exist(nameof(AutoScaleWidth)) ? (bool)Get(nameof(AutoScaleWidth), model) : false;
            image.SetAutoScaleHeight(autoScaleHeight);

            var fixedPositionLeft = Exist(nameof(FixedPositionLeft)) ? (float)Get(nameof(FixedPositionLeft), model) : 0f;
            var fixedPositionBottom = Exist(nameof(FixedPositionBottom)) ? (float)Get(nameof(FixedPositionBottom), model) : 0f;
            image.SetFixedPosition(fixedPositionLeft, fixedPositionBottom);

            pdfDoc.Add(image);
        }

    }
}
