using iText.Kernel.Colors;
using iText.Layout.Element;

namespace Sparrow.Export.iTextSharp
{
    public partial class SparrowPdf
    {
        private static void SetProperties<T1, T2>(BlockElement<T1> element, PdfProperties<T2> properties) where T1 : IElement where T2 : class
        {
            if (properties.BackgroundColor != null)
            {
                var color = Color.ConvertRgbToCmyk(properties.BackgroundColor);
                element.SetBackgroundColor(color);
            }
            if (properties.Width.HasValue)
            {
                element.SetWidth(properties.Width.Value);
            }
            if (properties.Height.HasValue)
            {
                element.SetHeight(properties.Height.Value);
            }
            SetPdfBlockElementFont(element, properties);
            SetPdfBlockElementMargin(element, properties);
            SetPdfBlockElementPadding(element, properties);
        }

        private static void SetPdfBlockElementFont<T1, T2>(BlockElement<T1> element, PdfProperties<T2> properties) where T1 : IElement where T2 : class
        {
            element.SetTextAlignment(properties.TextAlignment);
            element.SetVerticalAlignment(properties.VerticalAlignment);
            if (properties.FontItalic)
            {
                element.SetItalic();
            }
            if (properties.FontColor != null)
            {
                var color = Color.ConvertRgbToCmyk(properties.FontColor);
                element.SetFontColor(color);
            }
            if (properties.FontSize.HasValue)
            {
                element.SetFontSize(properties.FontSize.Value);
            }
            if (properties.FontBold)
            {
                element.SetBold();
            }
        }

        private static void SetPdfBlockElementMargin<T1, T2>(BlockElement<T1> element, PdfProperties<T2> properties) where T1 : IElement where T2 : class
        {
            if (properties.MarginLeft.HasValue)
            {
                element.SetMarginLeft(properties.MarginLeft.Value);
            }
            if (properties.MarginTop.HasValue)
            {
                element.SetMarginTop(properties.MarginTop.Value);
            }
            if (properties.MarginRight.HasValue)
            {
                element.SetMarginRight(properties.MarginRight.Value);
            }
            if (properties.MarginBottom.HasValue)
            {
                element.SetMarginBottom(properties.MarginBottom.Value);
            }
        }

        private static void SetPdfBlockElementPadding<T1, T2>(BlockElement<T1> element, PdfProperties<T2> properties) where T1 : IElement where T2 : class
        {
            if (properties.PaddingLeft.HasValue)
            {
                element.SetPaddingLeft(properties.PaddingLeft.Value);
            }
            if (properties.PaddingTop.HasValue)
            {
                element.SetPaddingTop(properties.PaddingTop.Value);
            }
            if (properties.PaddingRight.HasValue)
            {
                element.SetPaddingRight(properties.PaddingRight.Value);
            }
            if (properties.PaddingBottom.HasValue)
            {
                element.SetPaddingBottom(properties.PaddingBottom.Value);
            }
        }
    }
}
