using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPdf.Xaml
{
    public class EBlockElement : PdfXamlObject
    {
        public float Height
        {
            get => (float)Get();
            set => Set(value);
        }

        public bool KeepTogether
        {
            get => (bool)Get();
            set => Set(value);
        }

        public bool KeepWithNext
        {
            get => (bool)Get();
            set => Set(value);
        }
        
        public float Margin
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

        public float Padding
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
        
        public double RotationAngle
        {
            get => (double)Get();
            set => Set(value);
        }
                
        public float SpacingRatio
        {
            get => (float)Get();
            set => Set(value);
        }
        
        public VerticalAlignment VerticalAlignment
        {
            get => (VerticalAlignment)Get();
            set => Set(value);
        }
        
        public float Width
        {
            get => (float)Get();
            set => Set(value);
        }

        protected void BuildElement<T>(BlockElement<T> e, object model) where T : IElement
        {

            if(Exist(nameof(Height)))
            {
                e.SetHeight( (float)Get(nameof(Height), model) );
            }

            if(Exist(nameof(KeepTogether)))
            {
                e.SetKeepTogether( (bool)Get(nameof(KeepTogether), model) );
            }

            if(Exist(nameof(KeepWithNext)))
            {
                e.SetKeepWithNext( (bool)Get(nameof(KeepWithNext), model) );
            }

            if(Exist(nameof(Margin)))
            {
                e.SetMargin( (float)Get(nameof(Margin), model));
            }

            if(Exist(nameof(MarginLeft)))
            {
                e.SetMarginLeft((float)Get(nameof(MarginLeft), model));
            }

            if (Exist(nameof(MarginRight)))
            {
                e.SetMarginRight((float)Get(nameof(MarginRight), model));
            }

            if (Exist(nameof(MarginTop)))
            {
                e.SetMarginTop((float)Get(nameof(MarginTop), model));
            }

            if (Exist(nameof(MarginBottom)))
            {
                e.SetMarginBottom((float)Get(nameof(MarginBottom), model));
            }

            if(Exist(nameof(MaxHeight)))
            {
                e.SetMaxHeight((float)Get(nameof(MaxHeight), model));
            }

            if (Exist(nameof(MaxWidth)))
            {
                e.SetMaxWidth((float)Get(nameof(MaxWidth), model));
            }

            if (Exist(nameof(MinHeight)))
            {
                e.SetMinHeight((float)Get(nameof(MinHeight), model));
            }

            if (Exist(nameof(MinWidth)))
            {
                e.SetMinWidth((float)Get(nameof(MinWidth), model));
            }


            if (Exist(nameof(Padding)))
            {
                e.SetPadding((float)Get(nameof(Padding), model));
            }

            if (Exist(nameof(PaddingLeft)))
            {
                e.SetPaddingLeft((float)Get(nameof(PaddingLeft), model));
            }

            if (Exist(nameof(PaddingRight)))
            {
                e.SetPaddingRight((float)Get(nameof(PaddingRight), model));
            }

            if (Exist(nameof(PaddingTop)))
            {
                e.SetPaddingTop((float)Get(nameof(PaddingTop), model));
            }

            if (Exist(nameof(PaddingBottom)))
            {
                e.SetPaddingBottom((float)Get(nameof(PaddingBottom), model));
            }

            if(Exist(nameof(RotationAngle)))
            {
                e.SetRotationAngle((double)Get(nameof(RotationAngle), model));
            }

            if(Exist(nameof(SpacingRatio)))
            {
                e.SetSpacingRatio((float)Get(nameof(SpacingRatio), model));
            }

            if(Exist(nameof(VerticalAlignment)))
            {
                e.SetVerticalAlignment((iText.Layout.Properties.VerticalAlignment)((int)(VerticalAlignment)Get(nameof(VerticalAlignment), model)));
            }

            if(Exist(nameof(Width)))
            {
                e.SetWidth((float)Get(nameof(Width), model));
            }

        }
    }
}
