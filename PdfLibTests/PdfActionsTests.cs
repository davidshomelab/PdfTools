using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfLib;
using PdfLib.Containers;
using PdfLibTests.TestUtilities;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfLibTests
{
    [TestClass()]
    public class PdfActionsTests
    {

        private const string SampleDoc = "SampleDocs\\SamplePdf.pdf";

        [TestMethod()]
        public void GetPdfDocumentInformationTest()
        {
            // Check expected properties of 
            PdfDocumentInfo documentInfo = PdfActions.GetPdfDocumentInformation(SampleDoc, "");
            Assert.AreEqual(documentInfo.Title, "Sample Doc");
            Assert.AreEqual(documentInfo.Author, "davidshomelab");
        }


        [TestMethod()]
        public void GetPDFDocumentSecurityOptionsTest()
        {
        }

        [TestMethod()]
        public void JoinPdfDocumentsTest()
        {
        }

        [TestMethod()]
        public void RotatePdfDocumentTest()
        {
            PdfActions.RotatePdfDocument(SampleDoc, new int[] { 1, 2 }, 90);

            // Check document isn't corrupted
            DocumentValidation.DocumentReadable(SampleDoc);

            PdfDocument pdfDocument = PdfReader.Open(SampleDoc);

            Assert.AreEqual(pdfDocument.Pages[0].Rotate, 90);

        }

        [TestMethod()]
        public void SetPdfDocumentInformationTest()
        {
        }

        [TestMethod()]
        public void SetPdfDocumentSecurityOptionsTest()
        {
        }

        [TestMethod()]
        public void SplitPdfDocumentTest()
        {
        }
    }
}