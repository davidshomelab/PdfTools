using PdfSharp.Pdf.IO;
using System.IO;

namespace PdfLibTests.TestUtilities
{
    public static class DocumentValidation
    {
        public static bool DocumentEmpty(string filePath)
        {
            FileInfo file = new FileInfo(filePath);

            return file.Length == 0;
        }

        public static void DocumentReadable(string filePath)
        {
            PdfReader.Open(filePath);

        }
    }
}
