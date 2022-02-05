---
external help file: PsPdf.dll-Help.xml
Module Name: PsPdf
online version:
schema: 2.0.0
---

# Join-PDFDocument

## SYNOPSIS
Combine multiple PDF documents into a single output.

## SYNTAX

```
Join-PDFDocument [-SourceDocuments] <String[]> [-OutputDocument] <String> [<CommonParameters>]
```

## DESCRIPTION
Join multiple PDF documents to produce a single output document. Source files are combined in the order they are given at the command line. All files must be unencrypted.

## EXAMPLES

### Example 1
```powershell
PS C:\> Join-PDFDocument -SourceDocuments file1.pdf, file2.pdf, file3.pdf -OutputDocument output.pdf
```

Combine 3 source files into a single output

## PARAMETERS

### -OutputDocument
Location to save output.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDocuments
Array of input documents to merge, processed in order they are given.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
