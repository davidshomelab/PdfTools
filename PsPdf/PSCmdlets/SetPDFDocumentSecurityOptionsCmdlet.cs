using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Linq;
using PdfLib;

namespace PsPdf.PSCmdlets
{
    [Cmdlet(VerbsCommon.Set, "PDFDocumentSecurityOptions")]
    [OutputType(typeof(void))]
    public class SetPDFDocumentSecurityOptionsCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string Document { get; set; }
        [Parameter(HelpMessage = "User Password, required to open the PDF.")]
        public string UserPassword { get; set; }
        [Parameter(HelpMessage = "Owner Password, required to modify permissions. Will default to user password if left blank.")]
        public string OwnerPassword { get; set; }
        [Parameter(HelpMessage = "Current user password if required.")]
        public string CurrentOwnerPassword { get; set; }
        [Parameter()]
        public bool? PermitAccessibilityExtractContent { get; set; }
        [Parameter()]
        public bool? PermitAnnotations { get; set; }
        [Parameter()]
        public bool? PermitAssembleDocument { get; set; }
        [Parameter()]
        public bool? PermitExtractContent { get; set; }
        [Parameter()]
        public bool? PermitFormsFill { get; set; }
        [Parameter()]
        public bool? PermitFullQualityPrint { get; set; }
        [Parameter()]
        public bool? PermitModifyDocument { get; set; }
        [Parameter()]
        public bool? PermitPrint { get; set; }

        protected override void BeginProcessing()
        {
            if (OwnerPassword == null)
            {
                OwnerPassword = UserPassword;
            }
        }

        protected override void ProcessRecord()
        {
            Collection<string> resolvedInputPath = GetResolvedProviderPathFromPSPath(Document, out _);
            string documentPath = resolvedInputPath.Single<string>();

            if (CurrentOwnerPassword != null && (UserPassword == null || OwnerPassword == null))
            {
                WriteWarning("The user and owner passwords must be specified every time the document is saved, the output document will not be encrypted.");
            }


            PdfActions.SetPdfDocumentSecurityOptions(
                documentPath,
                UserPassword,
                OwnerPassword,
                CurrentOwnerPassword,
                PermitAccessibilityExtractContent,
                PermitAnnotations,
                PermitAssembleDocument,
                PermitExtractContent,
                PermitFormsFill,
                PermitFullQualityPrint,
                PermitModifyDocument,
                PermitPrint
                );

        }
    }
}
