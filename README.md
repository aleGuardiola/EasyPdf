# EasyPdf
EasyPdf is a library to make easier pdf generation using XAML
or a Strong object tree. It use ITextSharp 7.0 as the engine that
generate the resulting pdf file, supporting (or planning to support)
all the elements available in ITextSharp 7.0 with some additions
like customs Layout Manager and an easy flexibility.

### Getting Starting
For now just clone or download the library and reference it
to your project there is plans to make a nuget package for the future.
This library target .net standard that make it compatible with
any .net platform.

#### Make your pdf document

##### XAML
``` xml
<EDocument xmlns="https://github.com/aleGuardiola/EasyPdf" >
    <EPage>        
        <EParagraph>
            <EText FontColor="Red" Bold="true" FontSize="12" >Hello Easy Pdf</EText>            
        </EParagraph> 
    </EPage>    
</EDocument>

```

##### C#
```c#
using EasyPdf.Xaml;


var pdf = new EDocument()
            {
                Children =
                {
                    new EPage()
                    {
                        Children =
                        {
                            new EParagraph()
                            {
                                Content =
                                {
                                   new EText()
                                   {
                                       Text = "Hello Easy Pdf",
                                       FontColor = Color.Red,
                                       Bold = true,
                                       FontSize = 12
                                   }
                                }
                            }
                        }
                    }
                }
            };
```
##### Resulting pdf:
[Click here](test.pdf)