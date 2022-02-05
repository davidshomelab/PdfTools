using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsPdf.Containers
{
    class PDFDocumentSecurityOptions
    {
        public bool PermitAccessibilityExtractContent { get; set; }
        public bool PermitAnnotations { get; set; }
        public bool PermitAssembleDocument { get; set; }
        public bool PermitExtractContent { get; set; }
        public bool PermitFormsFill { get; set; }
        public bool PermitFullQualityPrint { get; set; }
        public bool PermitModifyDocument { get; set; }
        public bool PermitPrint { get; set; }
    }
}
