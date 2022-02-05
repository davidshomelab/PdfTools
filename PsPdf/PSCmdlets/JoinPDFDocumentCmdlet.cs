using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PdfLib;
using System.Management.Automation;

namespace PsPdf.PSCmdlets
{
    [Cmdlet(VerbsCommon.Join, "PDFDocument")]
    [OutputType(typeof(void))]
    public class JoinPDFDocumentCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Array of input documents to merge, processed in order they are given.", Position = 1)]
        public string[] SourceDocuments { get; set; }
        [Parameter(Mandatory = true, HelpMessage = "Location to save output.", Position = 2)]
        public string OutputDocument { get; set; }


        protected override void ProcessRecord()
        {
            List<string> validatedSourceFileNames = new List<string>();


            foreach(string inputPath in SourceDocuments)
            {
                // convert all input paths to absolute paths and prepare array to pass to backend function
                Collection<string> resolvedPaths = GetResolvedProviderPathFromPSPath(inputPath.ToString(), out ProviderInfo resolvedProvider);
                if (resolvedPaths != null)
                {
                    foreach (string fullPath in resolvedPaths)
                    {
                        validatedSourceFileNames.Add(fullPath);
                    }
                }
            }

            string absoluteOutputPath = GetUnresolvedProviderPathFromPSPath(OutputDocument);

            PdfActions.JoinPdfDocuments(validatedSourceFileNames.ToArray(), absoluteOutputPath);

        }
    }
}
