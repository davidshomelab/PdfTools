---
external help file: PsPdf.dll-Help.xml
Module Name: PsPdf
online version:
schema: 2.0.0
---

# Set-PDFDocumentInformation

## SYNOPSIS
Change PDF document metadata.

## SYNTAX

```powershell
Set-PDFDocumentInformation [[-Document] <String>] [-Title <String>] [-Author <String>] [-Subject <String>]
 [-Keywords <String>] [-Creator <String>] [<CommonParameters>]
```

## DESCRIPTION
Update metadata for PDF documents, including Title, Author etc.

## EXAMPLES

### Set document title
```powershell
PS C:\> Set-PDFDocumentInformation -Document file1.pdf -Title "File 1"
```

Change document title for "file1.pdf" to "File 1".

### Set document author
```powershell
PS C:\> Set-PDFDocumentInformation -Document file1.pdf -Title "Bob Smith"
```

Change document author for "file1.pdf" to "Bob Smith".

### Set document subject
```powershell
PS C:\> Set-PDFDocumentInformation -Document file1.pdf -Subject "A PDF Document"
```

Change document subject for "file1.pdf".

## PARAMETERS

### -Author
Name of the document author.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Creator
Name of application which originally created document.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Document
Document to process.

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

### -Keywords
Document keywords.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subject
Document subject.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Title
Document title.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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
