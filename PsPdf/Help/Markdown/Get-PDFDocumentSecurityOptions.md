---
external help file: PsPdf.dll-Help.xml
Module Name: PsPdf
online version:
schema: 2.0.0
---

# Get-PDFDocumentSecurityOptions

## SYNOPSIS
Get user permissions for encrypted PDF document.

## SYNTAX

```powershell
Get-PDFDocumentSecurityOptions [-Document] <String> [[-Password] <String>] [<CommonParameters>]
```

## DESCRIPTION
Show current permissions for PDF documents. These permissions restrict access to limit what non-owners can do with the document.

## EXAMPLES

### Example
```powershell
PS C:\> Get-PDFDocumentSecurityOptions -Document file1.pdf -Password test123
```

Get document security options for "file1.pdf" encrypted with password "test123".

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

### PdfLib.Containers.PDFDocumentSecurityOptions

## NOTES

## RELATED LINKS
