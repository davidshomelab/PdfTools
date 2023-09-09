using PdfLib;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;

namespace PsPdf.PSCmdlets
{
    [Cmdlet(VerbsCommon.Set, "PDFDocumentInformation")]
    [OutputType(typeof(void))]
    public class SetPDFDocumentInformationCmdlet : PSCmdlet
    {
        [Parameter(Position = 1, Mandatory = true)]
        public string Document;
        [Parameter()]
        public string Title;
        [Parameter()]
        public string Author;
        [Parameter()]
        public string Subject;
        [Parameter()]
        public string Keywords;
        [Parameter()]
        public string Creator;

        protected override void ProcessRecord()
        {
            Collection<string> resolvedFilePath = GetResolvedProviderPathFromPSPath(Document, out _);

            PdfActions.SetPdfDocumentInformation(resolvedFilePath.Single(), Title, Author, Subject, Keywords, Creator);

        }
    }
}
