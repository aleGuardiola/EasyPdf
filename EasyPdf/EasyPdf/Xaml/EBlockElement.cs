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
            get => (float)Get(nameof(Height));
            set => Set(nameof(Height), value);
        }

        public bool KeepTogether
        {
            get => (bool)Get(nameof(KeepTogether));
            set => Set(nameof(KeepTogether), value);
        }

        public bool KeepWithNext
        {
            get => (bool)Get(nameof(KeepWithNext));
            set => Set(nameof(KeepWithNext), value);
        }
        
        public float Margin
        {
            get => (float)Get(nameof(Margin));
            set => Set(nameof(Margin), value);
        }

        public float MarginBottom
        {
            get => (float)Get(nameof(MarginBottom));
            set => Set(nameof(MarginBottom), value);
        }

        public float MarginLeft
        {
            get => (float)Get(nameof(MarginLeft));
            set => Set(nameof(MarginLeft), value);
        }
        
        public float MarginRight
        {
            get => (float)Get(nameof(MarginRight));
            set => Set(nameof(MarginRight), value);
        }
        
        public float MarginTop
        {
            get => (float)Get(nameof(MarginTop));
            set => Set(nameof(MarginTop), value);
        }
        
        public float MaxHeight
        {
            get => (float)Get(nameof(MaxHeight));
            set => Set(nameof(MaxHeight), value);
        }

        public float MaxWidth
        {
            get => (float)Get(nameof(MaxWidth));
            set => Set(nameof(MaxWidth), value);
        }

        public float MinHeight
        {
            get => (float)Get(nameof(MinHeight));
            set => Set(nameof(MinHeight), value);
        }

        public float MinWidth
        {
            get => (float)Get(nameof(MinWidth));
            set => Set(nameof(MinWidth), value);
        }

        public float Padding
        {
            get => (float)Get(nameof(Padding));
            set => Set(nameof(Padding), value);
        }
        
        public float PaddingBottom
        {
            get => (float)Get(nameof(PaddingBottom));
            set => Set(nameof(PaddingBottom), value);
        }

        public float PaddingLeft
        {
            get => (float)Get(nameof(PaddingLeft));
            set => Set(nameof(PaddingLeft), value);
        }
        
        public float PaddingRight
        {
            get => (float)Get(nameof(PaddingRight));
            set => Set(nameof(PaddingRight), value);
        }

        public float PaddingTop
        {
            get => (float)Get(nameof(PaddingTop));
            set => Set(nameof(PaddingTop), value);
        }
        
        public double RotationAngle
        {
            get => (double)Get(nameof(RotationAngle));
            set => Set(nameof(RotationAngle), value);
        }
                
        public float SpacingRatio
        {
            get => (float)Get(nameof(SpacingRatio));
            set => Set(nameof(SpacingRatio), value);
        }
        
        public VerticalAlignment VerticalAlignment
        {
            get => (VerticalAlignment)Get(nameof(VerticalAlignment));
            set => Set(nameof(VerticalAlignment), value);
        }
        
        public float Width
        {
            get => (float)Get(nameof(Width));
            set => Set(nameof(Width), value);
        }

        protected void BuildElement<T>(BlockElement<T> e) where T : IElement
        {
            if(Exist(nameof(Height)))
            {
                e.SetHeight(Height);
            }

            if(Exist(nameof(KeepTogether)))
            {
                e.SetKeepTogether(KeepTogether);
            }

            if(Exist(nameof(KeepWithNext)))
            {
                e.SetKeepWithNext(KeepWithNext);
            }

            if(Exist(nameof(Margin)))
            {
                e.SetMargin(Margin);
            }

            if(Exist(nameof(MarginLeft)))
            {
                e.SetMarginLeft(MarginLeft);
            }

            if (Exist(nameof(MarginRight)))
            {
                e.SetMarginRight(MarginRight);
            }

            if (Exist(nameof(MarginTop)))
            {
                e.SetMarginTop(MarginTop);
            }

            if (Exist(nameof(MarginBottom)))
            {
                e.SetMarginBottom(MarginBottom);
            }

            if(Exist(nameof(MaxHeight)))
            {
                e.SetMaxHeight(MaxHeight);
            }

            if (Exist(nameof(MaxWidth)))
            {
                e.SetMaxWidth(MaxWidth);
            }

            if (Exist(nameof(MinHeight)))
            {
                e.SetMinHeight(MinHeight);
            }

            if (Exist(nameof(MinWidth)))
            {
                e.SetMinWidth(MinWidth);
            }


            if (Exist(nameof(Padding)))
            {
                e.SetPadding(Padding);
            }

            if (Exist(nameof(PaddingLeft)))
            {
                e.SetPaddingLeft(PaddingLeft);
            }

            if (Exist(nameof(PaddingRight)))
            {
                e.SetPaddingRight(MarginRight);
            }

            if (Exist(nameof(PaddingTop)))
            {
                e.SetPaddingTop(PaddingTop);
            }

            if (Exist(nameof(PaddingBottom)))
            {
                e.SetPaddingBottom(PaddingBottom);
            }

            if(Exist(nameof(RotationAngle)))
            {
                e.SetRotationAngle(RotationAngle);
            }

            if(Exist(nameof(SpacingRatio)))
            {
                e.SetSpacingRatio(SpacingRatio);
            }

            if(Exist(nameof(VerticalAlignment)))
            {
                e.SetVerticalAlignment((iText.Layout.Properties.VerticalAlignment)((int)VerticalAlignment));
            }

            if(Exist(nameof(Width)))
            {
                e.SetWidth(Width);
            }

        }
    }
}
