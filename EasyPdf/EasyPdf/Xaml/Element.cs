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
            get => (Color)Get(nameof(BackgroundColor));
            set => Set(nameof(BackgroundColor), value);
        }

        public float BackgroundOpacity
        {
            get => (float)Get(nameof(BackgroundColor));
            set => Set(nameof(BackgroundColor), value);
        }

        public float BackgroundExtraLeft
        {
            get => (float)Get(nameof(BackgroundExtraLeft));
            set => Set(nameof(BackgroundExtraLeft), value);
        }

        public float BackgroundExtraRight
        {
            get => (float)Get(nameof(BackgroundExtraRight));
            set => Set(nameof(BackgroundExtraRight), value);
        }

        public float BackgroundExtraTop
        {
            get => (float)Get(nameof(BackgroundExtraTop));
            set => Set(nameof(BackgroundExtraTop), value);
        }

        public float BackgroundExtraBottom
        {
            get => (float)Get(nameof(BackgroundExtraBottom));
            set => Set(nameof(BackgroundExtraBottom), value);
        }

        public BaseDirection BaseDirection
        {
            get => (BaseDirection)Get(nameof(BaseDirection));
            set => Set(nameof(BaseDirection), value);
        }

        public bool Bold
        {
            get => (bool)Get(nameof(Bold));
            set => Set(nameof(Bold), value);
        }

        public Border Border
        {
            get => (Border)Get(nameof(Border));
            set => Set(nameof(Border), value);
        }
        
        public Border BorderBottom
        {
            get => (Border)Get(nameof(BorderBottom));
            set => Set(nameof(BorderBottom), value);
        }
        
        public BorderRadius BorderBottomLeftRadius
        {
            get => (BorderRadius)Get(nameof(BorderBottomLeftRadius));
            set => Set(nameof(BorderBottomLeftRadius), value);
        }

        public BorderRadius BorderBottomRightRadius
        {
            get => (BorderRadius)Get(nameof(BorderBottomRightRadius));
            set => Set(nameof(BorderBottomRightRadius), value);
        }

        public BorderRadius BorderRadius
        {
            get => (BorderRadius)Get(nameof(BorderRadius));
            set => Set(nameof(BorderRadius), value);
        }
        
        public Border BorderRight
        {
            get => (Border)Get(nameof(BorderRight));
            set => Set(nameof(BorderRight), value);
        }

        public Border BorderTop
        {
            get => (Border)Get(nameof(BorderTop));
            set => Set(nameof(BorderTop), value);
        }

        public BorderRadius BorderTopLeftRadius
        {
            get => (BorderRadius)Get(nameof(BorderTopLeftRadius));
            set => Set(nameof(BorderTopLeftRadius), value);
        }

        public BorderRadius BorderTopRightRadius
        {
            get => (BorderRadius)Get(nameof(BorderTopRightRadius));
            set => Set(nameof(BorderTopRightRadius), value);
        }

        public float CharacterSpacing
        {
            get => (float)Get(nameof(CharacterSpacing));
            set => Set(nameof(CharacterSpacing), value);
        }

        public Rectangle FixedPosition
        {
            get => (Rectangle)Get(nameof(FixedPosition));
            set => Set(nameof(FixedPosition), value);
        }

        public Font Font
        {
            get => (Font)Get(nameof(Font));
            set => Set(nameof(Font), value);
        }

        public Color FontColor
        {
            get => (Color)Get(nameof(FontColor));
            set => Set(nameof(FontColor), value);
        }

        public float FontColorOpacity
        {
            get => (float)Get(nameof(FontColorOpacity));
            set => Set(nameof(FontColorOpacity), value);
        }

        public bool FontKerning
        {
            get => (bool)Get(nameof(FontKerning));
            set => Set(nameof(FontKerning), value);
        }

        public float FontSize
        {
            get => (float)Get(nameof(FontSize));
            set => Set(nameof(FontSize), value);
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get => (HorizontalAlignment)Get(nameof(HorizontalAlignment));
            set => Set(nameof(HorizontalAlignment), value);
        }

        public bool Italic
        {
            get => (bool)Get(nameof(Italic));
            set => Set(nameof(Italic), value);
        }
        
        public bool LineThrough
        {
            get => (bool)Get(nameof(LineThrough));
            set => Set(nameof(LineThrough), value);
        }

        public float Opacity
        {
            get => (float)Get(nameof(Opacity));
            set => Set(nameof(Opacity), value);
        }

        public Rectangle RelativePosition
        {
            get => (Rectangle)Get(nameof(RelativePosition));
            set => Set(nameof(RelativePosition), value);
        }

        public Color StrokeColor
        {
            get => (Color)Get(nameof(StrokeColor));
            set => Set(nameof(StrokeColor), value);
        }

        public float StrokeWidth
        {
            get => (float)Get(nameof(StrokeWidth));
            set => Set(nameof(StrokeWidth), value);
        }

        public TextAlignment TextAlignment
        {
            get => (TextAlignment)Get(nameof(TextAlignment));
            set => Set(nameof(TextAlignment), value);
        }

        public int TextRenderingMode
        {
            get => (int)Get(nameof(TextRenderingMode));
            set => Set(nameof(TextRenderingMode), value);
        }

        public IList<Underline> Underlines
        {
            get;            
        }
        
        public float WordSpacing
        {
            get => (float)Get(nameof(WordSpacing));
            set => Set(nameof(WordSpacing), value);
        }

        public Element()
        {
            Underlines = new List<Underline>();
        }

        protected void BuildElement<T>(ElementPropertyContainer<T> e) where T : IPropertyContainer
        {
            //Set the background color
            if (Exist(nameof(BackgroundColor)))
            {
                var color = Helpers.TypeConverter.ToITextColor(BackgroundColor);
                if (Exist(nameof(BackgroundOpacity)))
                {
                    if (Exist(nameof(BackgroundExtraLeft))
                        || Exist(nameof(BackgroundExtraRight))
                        || Exist(nameof(BackgroundExtraTop))
                        || Exist(nameof(BackgroundExtraBottom)))
                    {
                        var right = Exist(nameof(BackgroundExtraRight)) ? BackgroundExtraRight : 0f;
                        var left = Exist(nameof(BackgroundExtraRight)) ? BackgroundExtraRight : 0f;
                        var top = Exist(nameof(BackgroundExtraRight)) ? BackgroundExtraRight : 0f;
                        var bottom = Exist(nameof(BackgroundExtraRight)) ? BackgroundExtraRight : 0f;

                        e.SetBackgroundColor(color, BackgroundOpacity, left, top, right, bottom);
                    }
                    else
                    {
                        e.SetBackgroundColor(color, BackgroundOpacity);
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
                e.SetBaseDirection((iText.Layout.Properties.BaseDirection)((int)BaseDirection));
            }

            //Bold
            if(Exist(nameof(Bold)) && Bold)
            {
                e.SetBold();
            }

            //Border


            //Character Spacing
            if(Exist(nameof(CharacterSpacing)))
            {
                e.SetCharacterSpacing(CharacterSpacing);
            }

            //Fixed Position
            if(Exist(nameof(FixedPosition)))
            {
                e.SetFixedPosition(FixedPosition.Left, FixedPosition.Bottom, FixedPosition.Width);
            }

            //Font
            //Font type
            
            //FontColor
            if(Exist(nameof(FontColor)))
            {
                var color = Helpers.TypeConverter.ToITextColor(FontColor);
                if (Exist(nameof(FontColorOpacity)))
                {
                    e.SetFontColor(color, FontColorOpacity);
                }
                else
                {
                    e.SetFontColor(color);
                }
            }

            //Font Kerning
            if(Exist(nameof(FontKerning)))
            {
                e.SetFontKerning(FontKerning ? iText.Layout.Properties.FontKerning.YES
                    : iText.Layout.Properties.FontKerning.NO);
            }

            //Font Size
            if(Exist(nameof(FontSize)))
            {
                e.SetFontSize(FontSize);
            }


            //Horizontal Aligment
            if(Exist(nameof(HorizontalAlignment)))
            {
                e.SetHorizontalAlignment((iText.Layout.Properties.HorizontalAlignment)((int)HorizontalAlignment));
            }

            //Italic
            if(Exist(nameof(Italic)) && Italic)
            {
                e.SetItalic();
            }

            //Line Trought
            if(Exist(nameof(LineThrough)) && LineThrough)
            {
                e.SetLineThrough();
            }

            //Opacity
            if(Exist(nameof(Opacity)))
            {
                e.SetOpacity(Opacity);
            }

            //Relative Position
            if(Exist(nameof(RelativePosition)))
            {
                e.SetRelativePosition(RelativePosition.Left, RelativePosition.Top, RelativePosition.Right, RelativePosition.Bottom);
            }
                
            if(Exist(nameof(StrokeColor)))
            {
                e.SetStrokeColor(Helpers.TypeConverter.ToITextColor(StrokeColor));
            }

            if(Exist(nameof(StrokeWidth)))
            {
                e.SetStrokeWidth(StrokeWidth);
            }

            if(Exist(nameof(TextAlignment)))
            {
                e.SetTextAlignment((iText.Layout.Properties.TextAlignment)((int)TextAlignment));
            }

            if(Exist(nameof(TextRenderingMode)))
            {
                e.SetTextRenderingMode(TextRenderingMode);
            }

            //Underlines

            //Word spacing
            if(Exist(nameof(WordSpacing)))
            {
                e.SetWordSpacing(WordSpacing);
            }
        }

    }
}
