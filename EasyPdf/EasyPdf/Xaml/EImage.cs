using EasyPdf.Core;
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

        protected internal override void OnBuild(PdfElementContainer pdfDoc, object model)
        {
            model = GetModel(model);

            base.OnBuild(pdfDoc, model);

            if (!Exist(nameof(Source)))
                throw new MissingMemberException($"Member {nameof(ImageSource)} is required in an EImage Element.");

            var imageSource = (ImageSource)Get(nameof(Source), model);
            var image = new Image(ImageDataFactory.Create(imageSource.GetBytes()));

            if(Exist(nameof(Width)))
            {
                var width = (float)Get(nameof(Width), model);
                image.SetWidth(width);
            }

            if (Exist(nameof(Height)))
            {
                var height = (float)Get(nameof(Height), model);
                image.SetHeight(Height);
            }

            if(Exist(nameof(HorizontalScale)) || Exist(nameof(VerticalScale)))
            {
                var horizontalScale = Exist(nameof(HorizontalScale)) ?(float)Get(nameof(HorizontalScale), model) : 1f;
                var verticalScale = Exist(nameof(VerticalScale)) ? (float)Get(nameof(VerticalScale), model) : 1f;
                image.Scale(horizontalScale, verticalScale);
            }
            
            if(Exist(nameof(AutoScale)))
            {
                var autoScale = (bool)Get(nameof(AutoScale), model);
                image.SetAutoScale(autoScale);
            }

            if(Exist(nameof(AutoScaleHeight)))
            {
                var autoScaleHeight = (bool)Get(nameof(AutoScaleHeight), model);
                image.SetAutoScaleHeight(autoScaleHeight);
            }

            if(Exist(nameof(AutoScaleWidth)))
            {
                var autoScaleWidth = (bool)Get(nameof(AutoScaleWidth), model);
                image.SetAutoScaleWidth(autoScaleWidth);
            }

            if(Exist(nameof(FixedPositionLeft)) || Exist(nameof(FixedPositionBottom)))
            {
                var fixedPositionLeft = Exist(nameof(FixedPositionLeft)) ? (float)Get(nameof(FixedPositionLeft), model) : 0f;
                var fixedPositionBottom = Exist(nameof(FixedPositionBottom)) ? (float)Get(nameof(FixedPositionBottom), model) : 0f;
                image.SetFixedPosition(fixedPositionLeft, fixedPositionBottom);
            }

            if(Exist(nameof(MarginBottom)))
            {
                var marginBottom = (float)Get(nameof(MarginBottom), model);
                image.SetMarginBottom(marginBottom);
            }
            
            if (Exist(nameof(MarginTop)))
            {
                var marginTop = (float)Get(nameof(MarginTop), model);
                image.SetMarginTop(marginTop);
            }

            if (Exist(nameof(MarginLeft)))
            {
                var marginLeft = (float)Get(nameof(MarginLeft), model);
                image.SetMarginLeft(marginLeft);
            }
            
            if (Exist(nameof(MarginRight)))
            {
                var marginRight = (float)Get(nameof(MarginRight), model);
                image.SetMarginRight(marginRight);
            }

            if(Exist(nameof(MaxHeight)))
            {
                var maxHeight = (float)Get(nameof(MaxHeight), model);
                image.SetMaxHeight(maxHeight);
            }
            
            if (Exist(nameof(MaxWidth)))
            {
                var maxWidth = (float)Get(nameof(MaxWidth), model);
                image.SetMaxWidth(maxWidth);
            }

            if (Exist(nameof(MinHeight)))
            {
                var minHeight = (float)Get(nameof(MinHeight), model);
                image.SetMinHeight(minHeight);
            }

            if (Exist(nameof(MinWidth)))
            {
                var minWidth = (float)Get(nameof(MinWidth), model);
                image.SetMinWidth(minWidth);
            }

            if (Exist(nameof(PaddingBottom)))
            {
                var paddingBottom = (float)Get(nameof(PaddingBottom),model);
                image.SetPaddingBottom(paddingBottom);
            }
            
            if (Exist(nameof(PaddingTop)))
            {
                var paddingTop = (float)Get(nameof(PaddingTop), model);
                image.SetPaddingTop(paddingTop);
            }
            
            if (Exist(nameof(PaddingRight)))
            {
                var paddingRight = (float)Get(nameof(PaddingRight), model);
                image.SetPaddingRight(paddingRight);
            }
            
            if (Exist(nameof(PaddingLeft)))
            {
                var paddingLeft = (float)Get(nameof(PaddingLeft), model);
                image.SetPaddingLeft(paddingLeft);
            }
            
            if (Exist(nameof(RadiansRotationAngle)))
            {
                var radiansRotationAngle = (double)Get(nameof(RadiansRotationAngle), model);
                image.SetRotationAngle(radiansRotationAngle);
            }

            pdfDoc.Add(image);
        }

    }
}
