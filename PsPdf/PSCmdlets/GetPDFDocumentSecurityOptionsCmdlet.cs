using System.Management.Automation;
using System.Collections.ObjectModel;
using PdfLib;
using PdfLib.Containers;

namespace PsPdf.PSCmdlets
{
    [Cmdlet(VerbsCommon.Get, "PDFDocumentSecurityOptions")]
    [OutputType(typeof(PDFDocumentSecurityOptions))]
    public class GetPDFDocumentSecurityOptionsCmdlet : PSCmdlet
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
                PDFDocumentSecurityOptions result = PdfActions.GetPDFDocumentSecurityOptions(document, Password);

                WriteObject(result);
            }

        }
    }
}
