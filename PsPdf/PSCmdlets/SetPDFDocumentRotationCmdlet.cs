using System;
using System.Management.Automation;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PdfLib;
using System.Text;
using System.Threading.Tasks;

namespace PsPdf.PSCmdlets
{
    [Cmdlet(VerbsCommon.Set, "PDFDocumentRotation")]
    [OutputType(typeof(void))]
    public class SetPDFDocumentRotationCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string Document { get; set; }
        [Parameter(Position = 2)]
        public int[] Pages { get; set; }
        [Parameter(Mandatory = true, Position = 3)]
        [ValidateSet("0","90","180","270")]
        public string Rotation { get; set; }
        [Parameter(Position = 4, HelpMessage = "Whether rotation value given is an absolute value or relative to the current page rotation.")]
        public SwitchParameter AbsoluteRotation { get; set; }

        protected override void ProcessRecord()
        {
            int rotation = int.Parse(Rotation);
            Collection<string> resolvedInputPath = GetResolvedProviderPathFromPSPath(Document, out _);
            string documentPath = resolvedInputPath.Single<string>();

            PdfActions.RotatePdfDocument(documentPath, Pages, rotation, AbsoluteRotation);
        }
    }


}
