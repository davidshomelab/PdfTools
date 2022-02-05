using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Linq;
using PdfSharp.Pdf;
using PdfLib;
using PdfLib.Containers;

namespace PsPdf.PSCmdlets
{
    [Cmdlet(VerbsCommon.Get, "PDFDocumentInformation")]
    [OutputType(typeof(PdfDocumentInfo))]
    public class GetPDFDocumentInformationCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "PDF document to inspect.", Position = 1)]
        public string Document { get; set; }
        [Parameter(HelpMessage = "Password for unlocking encrypted documents.", Position = 2)]
        public string Password { get; set; }

        protected override void ProcessRecord()
        {
            Collection<string> resolvedInputPath = GetResolvedProviderPathFromPSPath(Document, out _);

            foreach (string document in resolvedInputPath)
            {
                PdfDocumentInfo result = PdfActions.GetPdfDocumentInformation(document, Password);

                WriteObject(result);
            }

        }
    }
}
