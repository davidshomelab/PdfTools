using PdfLib;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace PsPdf.PSCmdlets
{
    [Cmdlet(VerbsSecurity.Protect, "PDFDocument")]
    [OutputType(typeof(void))]
    public class ProtectPDFDocumentCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Source document to protect.")]
        public string Document { get; set; }
        [Parameter(HelpMessage = "User Password, required to open the PDF.")]
        public string UserPassword { get; set; }
        [Parameter(HelpMessage = "Owner Password, required to modify permissions. Will default to user password if left blank.")]
        public string OwnerPassword { get; set; }
        [Parameter(HelpMessage = "Current user password if required.")]
        public string CurrentOwnerPassword { get; set; }
        [Parameter(HelpMessage = "Output document. If not specified, the source document will be overwritten.")]
        public string OutputDocument { get; set; }

        protected override void ProcessRecord()
        {
            if (OwnerPassword == null)
            {
                OwnerPassword = UserPassword;
            }
            if (OutputDocument == null)
            {
                OutputDocument = Document;
            }
            Collection<string> resolvedSourceDocument = GetResolvedProviderPathFromPSPath(Document, out ProviderInfo provider);

            string resolvedSourceDocumentPath = resolvedSourceDocument.Single<string>();

            string resolvedOutputDocumentPath = GetUnresolvedProviderPathFromPSPath(OutputDocument);
            string documentpath;
            
            if (resolvedSourceDocumentPath != resolvedOutputDocumentPath)
            {
                File.Copy(resolvedSourceDocumentPath, resolvedOutputDocumentPath, true);
                documentpath = resolvedOutputDocumentPath;
            }
            else
            {
                documentpath = resolvedSourceDocumentPath;
            }

            PdfActions.SetPdfDocumentSecurityOptions(documentpath, UserPassword, OwnerPassword, CurrentOwnerPassword, null, null, null, null, null, null, null, null);


        }

    }
}
