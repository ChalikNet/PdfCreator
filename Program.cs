using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;
using System.Drawing;
using Color = Aspose.Pdf.Color;

class Program
{
    static void Main(string[] args)
    {
        // ایجاد یک شیء Document
        Document doc = new Document();

        // ایجاد یک صفحه با ابعاد A4
        Page page = doc.Pages.Add();
        

        // ایجاد یک جدول
        Table table = new Table();
        table.ColumnWidths = "100 100 100";
        table.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 0.1f);

        // ایجاد ردیف‌ها و اضافه کردن سلول‌ها به جدول
        Row headerRow = table.Rows.Add();
        headerRow.Cells.Add("Header 1");
        headerRow.Cells.Add("Header 2");
        headerRow.Cells.Add("Header 3");

        for (int i = 0; i < 5; i++)
        {
            Row dataRow = table.Rows.Add();
            dataRow.Cells.Add($"Data {i + 1}, Column 1").BackgroundColor=Color.Orange;
            dataRow.Cells.Add($"Data {i + 1}, Column 2").BackgroundColor = Color.LightBlue;
            dataRow.Cells.Add($"Data {i + 1}, Column 3").BackgroundColor=Color.LightGreen;
        }

        // اضافه کردن جدول به صفحه
        page.Paragraphs.Add(table);

        // اضافه کردن چندین پاراگراف متنی
        for (int i = 0; i < 3; i++)
        {
            TextFragment textFragment = new TextFragment($"این یک پاراگراف متنی است که توسط سینا فلکی ایجاد شده - {i + 1}");
            textFragment.TextState.Font = FontRepository.FindFont("Dast Nevis");
            textFragment.TextState.FontSize = 12;
            textFragment.TextState.ForegroundColor = Color.Black;
            textFragment.Position = new Position(100, 600 - (i * 50));
            page.Paragraphs.Add(textFragment);
        }

        // اضافه کردن تصویر
        Aspose.Pdf.Image image = new Aspose.Pdf.Image();
        image.File = "E:\\Programing Code\\CertificateCreator\\PdfCreator\\sina.png"; // مسیر و نام فایل تصویر خود را اینجا قرار دهید
        image.FixWidth = 300;
        image.FixHeight = 300;
        page.Paragraphs.Add(image);

        // ذخیره فایل PDF
        doc.Save("Output.pdf");


        Console.WriteLine("DONE");
    }
}
