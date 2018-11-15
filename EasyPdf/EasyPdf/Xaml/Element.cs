using iText.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EasyPdf.Xaml
{
    public class Element : PdfXamlObject
    {
        public Color BackgroundColor
        {
            get => (Color)Get();
            set => Set(value);
        }

        public float BackgroundOpacity
        {
            get => (float)Get();
            set => Set(value);
        }

        public float BackgroundExtraLeft
        {
            get => (float)Get();
            set => Set(value);
        }

        public float BackgroundExtraRight
        {
            get => (float)Get();
            set => Set(value);
        }

        public float BackgroundExtraTop
        {
            get => (float)Get();
            set => Set(value);
        }

        public float BackgroundExtraBottom
        {
            get => (float)Get();
            set => Set(value);
        }

        public BaseDirection BaseDirection
        {
            get => (BaseDirection)Get();
            set => Set(value);
        }

        public bool Bold
        {
            get => (bool)Get();
            set => Set(value);
        }

        public Border Border
        {
            get => (Border)Get();
            set => Set(value);
        }
        
        public Border BorderBottom
        {
            get => (Border)Get();
            set => Set(value);
        }
        
        public BorderRadius BorderBottomLeftRadius
        {
            get => (BorderRadius)Get();
            set => Set(value);
        }

        public BorderRadius BorderBottomRightRadius
        {
            get => (BorderRadius)Get();
            set => Set(value);
        }

        public BorderRadius BorderRadius
        {
            get => (BorderRadius)Get();
            set => Set(value);
        }
        
        public Border BorderRight
        {
            get => (Border)Get();
            set => Set(value);
        }

        public Border BorderTop
        {
            get => (Border)Get();
            set => Set(value);
        }

        public BorderRadius BorderTopLeftRadius
        {
            get => (BorderRadius)Get();
            set => Set(value);
        }

        public BorderRadius BorderTopRightRadius
        {
            get => (BorderRadius)Get();
            set => Set(value);
        }

        public float CharacterSpacing
        {
            get => (float)Get();
            set => Set(value);
        }

        public Rectangle FixedPosition
        {
            get => (Rectangle)Get();
            set => Set(value);
        }

        public Font Font
        {
            get => (Font)Get();
            set => Set(value);
        }

        public Color FontColor
        {
            get => (Color)Get();
            set => Set(value);
        }

        public float FontColorOpacity
        {
            get => (float)Get();
            set => Set(value);
        }

        public bool FontKerning
        {
            get => (bool)Get();
            set => Set(value);
        }

        public float FontSize
        {
            get => (float)Get();
            set => Set(value);
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get => (HorizontalAlignment)Get();
            set => Set(value);
        }

        public bool Italic
        {
            get => (bool)Get();
            set => Set(value);
        }
        
        public bool LineThrough
        {
            get => (bool)Get();
            set => Set(value);
        }

        public float Opacity
        {
            get => (float)Get();
            set => Set(value);
        }

        public Rectangle RelativePosition
        {
            get => (Rectangle)Get();
            set => Set(value);
        }

        public Color StrokeColor
        {
            get => (Color)Get();
            set => Set(value);
        }

        public float StrokeWidth
        {
            get => (float)Get();
            set => Set(value);
        }

        public TextAlignment TextAlignment
        {
            get => (TextAlignment)Get();
            set => Set(value);
        }

        public int TextRenderingMode
        {
            get => (int)Get();
            set => Set(value);
        }

        public IList<Underline> Underlines
        {
            get;            
        }
        
        public float WordSpacing
        {
            get => (float)Get();
            set => Set(value);
        }

        public Element()
        {
            Underlines = new List<Underline>();
        }

        protected void BuildElement<T>(ElementPropertyContainer<T> e, object model) where T : IPropertyContainer
        {

            //Set the background color
            if (Exist(nameof(BackgroundColor)))
            {
                var color = Helpers.TypeConverter.ToITextColor((Color)Get(nameof(BackgroundColor), model));
                if (Exist(nameof(BackgroundOpacity)))
                {
                    if (Exist(nameof(BackgroundExtraLeft))
                        || Exist(nameof(BackgroundExtraRight)) 
                        || Exist(nameof(BackgroundExtraTop))
                        || Exist(nameof(BackgroundExtraBottom)))
                    {
                        var right = Exist(nameof(BackgroundExtraRight)) ? (float)Get(nameof(BackgroundExtraRight), model) : 0f;
                        var left = Exist(nameof(BackgroundExtraLeft)) ? (float)Get(nameof(BackgroundExtraLeft), model) : 0f;
                        var top = Exist(nameof(BackgroundExtraTop)) ? (float)Get(nameof(BackgroundExtraTop), model) : 0f;
                        var bottom = Exist(nameof(BackgroundExtraBottom)) ? (float)Get(nameof(BackgroundExtraBottom), model) : 0f;

                        e.SetBackgroundColor(color, (float)Get(nameof(BackgroundOpacity), model), left, top, right, bottom);
                    }
                    else
                    {
                        e.SetBackgroundColor(color, (float)Get(nameof(BackgroundOpacity), model));
                    }
                }
                else
                {
                    e.SetBackgroundColor(color);
                }
            }

            //Base Direction
            if(Exist(nameof(BaseDirection)))
            {
                e.SetBaseDirection((iText.Layout.Properties.BaseDirection)((int)(BaseDirection)Get(nameof(BaseDirection), model)));
            }

            //Bold
            if(Exist(nameof(Bold)) && (bool)Get(nameof(Bold), model))
            {
                e.SetBold();
            }

            //Border


            //Character Spacing
            if(Exist(nameof(CharacterSpacing)))
            {
                e.SetCharacterSpacing((float)Get(nameof(CharacterSpacing), model));
            }

            //Fixed Position
            if(Exist(nameof(FixedPosition)))
            {
                var fixedPosition = (Rectangle)Get(nameof(FixedPosition), model);
                e.SetFixedPosition(fixedPosition.Left, fixedPosition.Bottom, fixedPosition.Width);
            }

            //Font
            //Font type
            
            //FontColor
            if(Exist(nameof(FontColor)))
            {
                var color = Helpers.TypeConverter.ToITextColor((Color)Get(nameof(FontColor), model));
                if (Exist(nameof(FontColorOpacity)))
                {
                    e.SetFontColor(color, (float)Get(nameof(FontColorOpacity), model));
                }
                else
                {
                    e.SetFontColor(color);
                }
            }

            //Font Kerning
            if(Exist(nameof(FontKerning)))
            {
                e.SetFontKerning((bool)Get(nameof(FontKerning), model) ? iText.Layout.Properties.FontKerning.YES
                    : iText.Layout.Properties.FontKerning.NO);
            }

            //Font Size
            if(Exist(nameof(FontSize)))
            {
                e.SetFontSize((float)Get(nameof(FontSize), model));
            }


            //Horizontal Aligment
            if(Exist(nameof(HorizontalAlignment)))
            {
                e.SetHorizontalAlignment((iText.Layout.Properties.HorizontalAlignment)((int)(HorizontalAlignment)Get(nameof(HorizontalAlignment), model)));
            }

            //Italic
            if(Exist(nameof(Italic)) && (bool)Get(nameof(Italic), model))
            {
                e.SetItalic();
            }

            //Line Trought
            if(Exist(nameof(LineThrough)) && (bool)Get(nameof(LineThrough), model))
            {
                e.SetLineThrough();
            }

            //Opacity
            if(Exist(nameof(Opacity)))
            {
                e.SetOpacity((float)Get(nameof(Opacity), model));
            }

            //Relative Position
            if(Exist(nameof(RelativePosition)))
            {
                var relativePosition = (Rectangle)Get(nameof(RelativePosition), model);
                e.SetRelativePosition(relativePosition.Left, relativePosition.Top, relativePosition.Right, relativePosition.Bottom);
            }
                
            if(Exist(nameof(StrokeColor)))
            {
                e.SetStrokeColor(Helpers.TypeConverter.ToITextColor((Color)Get(nameof(StrokeColor), model)));
            }

            if(Exist(nameof(StrokeWidth)))
            {
                e.SetStrokeWidth((float)Get(nameof(StrokeWidth), model));
            }

            if(Exist(nameof(TextAlignment)))
            {
                e.SetTextAlignment((iText.Layout.Properties.TextAlignment)((int)(TextAlignment)Get(nameof(TextAlignment), model)));
            }

            if(Exist(nameof(TextRenderingMode)))
            {
                e.SetTextRenderingMode((int)Get(nameof(TextRenderingMode), model));
            }

            //Underlines

            //Word spacing
            if(Exist(nameof(WordSpacing)))
            {
                e.SetWordSpacing((float)Get(nameof(WordSpacing), model));
            }

        }

    }
}
