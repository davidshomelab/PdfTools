using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfLib;
using PdfLib.Containers;
using PdfLibTests.TestUtilities;
using PdfSharp;
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
            PDFDocumentSecurityOptions securityOptions = PdfActions.GetPDFDocumentSecurityOptions(SampleDoc, "");
            Assert.AreEqual(securityOptions.PermitAccessibilityExtractContent, true);
            Assert.AreEqual(securityOptions.PermitAnnotations, true);
            Assert.AreEqual(securityOptions.PermitAssembleDocument, true);
            Assert.AreEqual(securityOptions.PermitExtractContent, true);
            Assert.AreEqual(securityOptions.PermitFormsFill, true);
            Assert.AreEqual(securityOptions.PermitFullQualityPrint, true);
            Assert.AreEqual(securityOptions.PermitModifyDocument, true);
            Assert.AreEqual(securityOptions.PermitPrint, true);
        }

        [TestMethod()]
        public void JoinPdfDocumentsTest()
        {
            string OutputDoc = "JoinedDoc.pdf";
            PdfActions.JoinPdfDocuments(new string[] { SampleDoc, SampleDoc }, OutputDoc);
            DocumentValidation.DocumentReadable(OutputDoc);
            PdfDocument joined = PdfReader.Open(OutputDoc);

            Assert.AreEqual(joined.PageCount, 8);
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
            PdfActions.SetPdfDocumentInformation(SampleDoc, "Title", "Author", "Subject", "Keywords", "Creator");
            DocumentValidation.DocumentReadable(SampleDoc);
            PdfDocumentInfo documentInfo = PdfActions.GetPdfDocumentInformation(SampleDoc, "");

            Assert.AreEqual(documentInfo.Title, "Title");
            Assert.AreEqual(documentInfo.Author, "Author");
            Assert.AreEqual(documentInfo.Subject, "Subject");
            Assert.AreEqual(documentInfo.Keywords, "Keywords");
            Assert.AreEqual(documentInfo.Creator, "Creator");
        }

        [TestMethod()]
        public void SetPdfDocumentSecurityOptionsTest()
        {
            // Encrypt document
            PdfActions.SetPdfDocumentSecurityOptions(SampleDoc, "123", "456", "", true, true, true, true,
                 true, true, true, true);

            // Check it cannot be read without password

            Assert.ThrowsException<PdfReaderException>(() => (PdfActions.GetPdfDocumentInformation(SampleDoc, "")));

            // Check it can be read with correct password

            PdfActions.GetPdfDocumentInformation(SampleDoc, "456");

            // Check password cannot be removed with user password

            Assert.ThrowsException<PdfReaderException>(() => PdfActions.SetPdfDocumentSecurityOptions(SampleDoc, "", "", "123", true, true, true,
                true, true, true, true, true));

            // Check password can be removed with owner password
            Assert.ThrowsException<PdfSharpException>(() => PdfActions.SetPdfDocumentSecurityOptions(SampleDoc, "", "", "456", true, true, true,
                true, true, true, true, true));

            DocumentValidation.DocumentReadable(SampleDoc);
        }

        [TestMethod()]
        public void SplitPdfDocumentTest()
        {
            string OutputDocument = "Split.pdf";
            PdfActions.SplitPdfDocument(SampleDoc, new int[] { 1, 3 }, OutputDocument);

            DocumentValidation.DocumentReadable(OutputDocument);
        }
    }
}