using System;
using System.Management.Automation;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PdfLib;
using System.Text;
using System.Threading.Tasks;

namespace PsPdf.PSCmdlets
{
    [Cmdlet(VerbsCommon.Split,"PDFDocument")]
    [OutputType(typeof(void))]
    public class SplitPDFDocumentCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Source document to split.", Position = 1)]
        public string Document { get; set; }
        [Parameter(Mandatory = true, HelpMessage = "Array of page numbers to extract.", Position = 2)]
        public int[] Pages { get; set; }
        [Parameter(Mandatory = true, HelpMessage = "Location to save output.", Position = 3)]
        public string OutputDocument { get; set; }


        protected override void ProcessRecord()
        {
            Collection<string> resolvedSourceDocument = GetResolvedProviderPathFromPSPath(Document, out _);
            string resolvedSourceDocumentPath = resolvedSourceDocument.Single();

            PdfActions.SplitPdfDocument(resolvedSourceDocumentPath, Pages, GetUnresolvedProviderPathFromPSPath(OutputDocument));

        }
    }
}
