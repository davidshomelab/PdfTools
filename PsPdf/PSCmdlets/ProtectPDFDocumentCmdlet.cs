using System;
using System.Management.Automation;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using PdfSharp.Pdf.IO;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void BeginProcessing()
        {
            if (OwnerPassword == null)
            {
                OwnerPassword = UserPassword;
            }
            if (OutputDocument == null)
            {
                OutputDocument = Document;
            }

        }

        protected override void ProcessRecord()
        {
                Collection<string> resolvedSourceDocument = GetResolvedProviderPathFromPSPath(Document, out ProviderInfo provider);

                string resolvedSourceDocumentPath = resolvedSourceDocument.Single<string>();

                PdfDocument sourceDocument = PdfReader.Open(resolvedSourceDocumentPath, CurrentOwnerPassword, openmode: PdfDocumentOpenMode.Modify);

                PdfDocument sourceBackup = PdfReader.Open(resolvedSourceDocumentPath, CurrentOwnerPassword, openmode: PdfDocumentOpenMode.Modify);

                PdfSecuritySettings securitySettings = sourceDocument.SecuritySettings;

                securitySettings.UserPassword = UserPassword;
                securitySettings.OwnerPassword = OwnerPassword;
            try
            {
                sourceDocument.Save(GetUnresolvedProviderPathFromPSPath(OutputDocument));
            }
            catch (Exception)
            {
                if (OutputDocument == Document && null != sourceBackup)
                {
                    // In the event that we hit an error when saving we restore a backup of the source document to prevent data loss
                    sourceBackup.Save(GetUnresolvedProviderPathFromPSPath(OutputDocument));
                }
                throw;
            }

        }

    }
}
