---
external help file: PsPdf.dll-Help.xml
Module Name: PsPdf
online version:
schema: 2.0.0
---

# Get-PDFDocumentInformation

## SYNOPSIS
Get general information about a PDF Document.

## SYNTAX

```
Get-PDFDocumentInformation [-Document] <String> [[-Password] <String>] [<CommonParameters>]
```

## DESCRIPTION
Returns PDF document metadata. Supports inspecting encrypted documents but if multiple documents are provided at once (e.g. using wildcards), all encrypted documents must use the same password.
Information returned is unaffected by whether the user or owner password is provided.

## EXAMPLES

### Password Protected Source Document
```powershell
PS C:\> Get-PDFDocumentInformation -Document file1.pdf -Password "test123"
```

Get document information for an encrypted document.

### Using Wildcards
```powershell
PS C:\> Get-PDFDocumentInformation -Document *.pdf
```

Get document information for all documents in the working directory.

## PARAMETERS

### -Document
PDF document to inspect.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Password
Password for unlocking encrypted documents.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PdfLib.Containers.PdfDocumentInfo

## NOTES

## RELATED LINKS
