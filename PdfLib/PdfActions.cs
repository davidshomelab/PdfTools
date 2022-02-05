using System;
using System.IO;
using System.Collections.Generic;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System.Linq;
using PdfLib.Containers;
using PdfLib.Utilities;

namespace PdfLib
{
    public class PdfActions
    {
        public static PdfDocumentInfo GetPdfDocumentInformation(string Document, string Password)
        {
            PdfDocument pdfDocument = PdfReader.Open(Document, Password, PdfDocumentOpenMode.ReadOnly);

            FileInfo fileInfo = new FileInfo(Document);

            PdfDocumentInformation documentInfo = pdfDocument.Info;


            PdfDocumentInfo pdfDocumentInfo = new PdfDocumentInfo
            {
                Author = documentInfo.Author,
                CreationDate = documentInfo.CreationDate,
                Creator = documentInfo.Creator,
                Keywords = documentInfo.Keywords,
                ModificationDate = documentInfo.ModificationDate,
                Producer = documentInfo.Producer,
                Subject = documentInfo.Subject,
                Title = documentInfo.Title,
                FileName = fileInfo.Name,
                FullPath = fileInfo.FullName,
                FileSize = pdfDocument.FileSize
            };

            return pdfDocumentInfo;
        }

        public static PDFDocumentSecurityOptions GetPDFDocumentSecurityOptions(string Document, string Password)
        {
            PdfDocument pdfDocument = PdfReader.Open(Document, Password, PdfDocumentOpenMode.ReadOnly);

            PdfSecuritySettings pdfSecuritySettings = pdfDocument.SecuritySettings;

            PDFDocumentSecurityOptions documentSecurityOptions = new PDFDocumentSecurityOptions
            {
                PermitAccessibilityExtractContent = pdfSecuritySettings.PermitAccessibilityExtractContent,
                PermitAnnotations = pdfSecuritySettings.PermitAnnotations,
                PermitAssembleDocument = pdfSecuritySettings.PermitAssembleDocument,
                PermitExtractContent = pdfSecuritySettings.PermitExtractContent,
                PermitFormsFill = pdfSecuritySettings.PermitFormsFill,
                PermitFullQualityPrint = pdfSecuritySettings.PermitFullQualityPrint,
                PermitModifyDocument = pdfSecuritySettings.PermitModifyDocument,
                PermitPrint = pdfSecuritySettings.PermitPrint
            };

            return documentSecurityOptions;

        }

        public static void JoinPdfDocuments(string[] SourceFiles, string OutputFile)
        {
            List<PdfDocument> pdfDocuments = new List<PdfDocument>();

            foreach (string SourceFile in SourceFiles)
            {
                pdfDocuments.Add(PdfReader.Open(SourceFile, PdfDocumentOpenMode.Import));
            }

            PdfDocument outputDocument = new PdfDocument();

            foreach (PdfDocument pdfDocument in pdfDocuments)
            {
                foreach (PdfPage page in pdfDocument.Pages)
                {
                    outputDocument.AddPage(page);
                }
            }

            outputDocument.Save(OutputFile);
        }

        public static void RotatePdfDocument(string DocumentPath, int[] Pages, int Rotation, bool AbsoluteRotation = false)
        {
            if (Rotation % 90 != 0)
            {
                throw new InvalidOperationException("Rotation must be a multiple of 90.");
            }

            PdfDocument pdfDocument = PdfReader.Open(DocumentPath, PdfDocumentOpenMode.Modify);

            if (Pages == null)
            {
                Pages = Enumerable.Range(1, pdfDocument.Pages.Count).ToArray();
            }

            foreach (int page in Pages)
            {
                PdfPage pdfPage = pdfDocument.Pages[page - 1];
                if (AbsoluteRotation)
                {
                    pdfPage.Rotate = 0;
                }
                pdfPage.Rotate = (pdfPage.Rotate + Rotation) % 360;
            }

            pdfDocument.Save(DocumentPath);
        }

        public static void SetPdfDocumentInformation(
            string Document,
            string Title,
            string Author,
            string Subject,
            string Keywords,
            string Creator
            )
        {
            PdfDocument document = PdfReader.Open(Document);

            PdfDocumentInformation documentInfo = document.Info;

            documentInfo.Title = Title ?? documentInfo.Title;
            documentInfo.Author = Author ?? documentInfo.Author;
            documentInfo.Subject = Subject ?? documentInfo.Subject;
            documentInfo.Keywords = Keywords ?? documentInfo.Keywords;
            documentInfo.Creator = Creator ?? documentInfo.Creator;

            document.Save(Document);

        }

        public static void SetPdfDocumentSecurityOptions(
             string Document,
             string UserPassword,
             string OwnerPassword,
             string CurrentOwnerPassword,
             bool? PermitAccessibilityExtractContent,
             bool? PermitAnnotations,
             bool? PermitAssembleDocument,
             bool? PermitExtractContent,
             bool? PermitFormsFill,
             bool? PermitFullQualityPrint,
             bool? PermitModifyDocument,
             bool? PermitPrint)
        {
            PdfDocument document = PdfReader.Open(Document, CurrentOwnerPassword, PdfDocumentOpenMode.Modify);
            PdfDocument documentBackup = PdfReader.Open(Document, CurrentOwnerPassword, PdfDocumentOpenMode.Modify);

            PdfSecuritySettings securitySettings = document.SecuritySettings;

            PDFDocumentSecurityOptions documentSecurityOptions = new PDFDocumentSecurityOptions
            {
                PermitAccessibilityExtractContent = PermitAccessibilityExtractContent ?? securitySettings.PermitAccessibilityExtractContent,
                PermitAssembleDocument = PermitAssembleDocument ?? securitySettings.PermitAssembleDocument,
                PermitAnnotations = PermitAnnotations ?? securitySettings.PermitAnnotations,
                PermitExtractContent = PermitExtractContent ?? securitySettings.PermitExtractContent,
                PermitFormsFill = PermitFormsFill ?? securitySettings.PermitFormsFill,
                PermitFullQualityPrint = PermitFullQualityPrint ?? securitySettings.PermitFullQualityPrint,
                PermitModifyDocument = PermitModifyDocument ?? securitySettings.PermitModifyDocument,
                PermitPrint = PermitPrint ?? securitySettings.PermitPrint
            };

            if (UserPassword != null)
            {
                securitySettings.UserPassword = UserPassword;

                if (OwnerPassword == null)
                {
                    OwnerPassword = UserPassword;
                }
            }

            if (OwnerPassword != null)
            {
                securitySettings.OwnerPassword = OwnerPassword;
            }

            Reflection.CopyProperties(documentSecurityOptions, securitySettings);


            try
            {
                document.Save(Document);
            }
            catch (Exception)
            {
                documentBackup.Save(Document);
                throw;
            }
        }

        public static void SplitPdfDocument(string SourceDocument, int[] Pages, string OutputDocument)
        {
            PdfDocument sourceDocument = PdfReader.Open(SourceDocument, PdfDocumentOpenMode.Import);

            PdfDocument outputDocument = new PdfDocument();

            foreach (int page in Pages)
            {
                outputDocument.AddPage(sourceDocument.Pages[page - 1]); // as our array of pages is 0 indexed but GUI pdf viewers 1 index, we adjust to allow page numbers to be entered more naturally
            }
            outputDocument.Save(OutputDocument);
        }
    }
}
