---
external help file: PsPdf.dll-Help.xml
Module Name: PsPdf
online version:
schema: 2.0.0
---

# Set-PDFDocumentRotation

## SYNOPSIS
Rotate PDF document pages.

## SYNTAX

```powershell
Set-PDFDocumentRotation [-Document] <String> [[-Pages] <Int32[]>] [-Rotation] <String> [-AbsoluteRotation]
 [<CommonParameters>]
```

## DESCRIPTION
Set rotation of one or more PDF pages. Rotation angle can be provided relative to the current page rotation or as an absolute rotation from the original rotation from when the page was created.
Rotation angles are given in degrees, must be a multiple of 90 and are treated as clockwise.

## EXAMPLES

### Rotate single page
```powershell
PS C:\> Set-PDFDocumentRotation -Document file1.pdf -Pages 2 -Rotation 90
```

Rotate the second page of "file1.pdf" 90 degrees clockwise.

### Rotate multiple pages
```powershell
PS C:\> Set-PDFDocumentRotation -Document file1.pdf -Pages 2,3,7 -Rotation 90
```

Rotate the second, third and seventh pages of "file1.pdf" 90 degrees clockwise.

### Rotate range of pages
```powershell
PS C:\> Set-PDFDocumentRotation -Document file1.pdf -Pages (4..10) -Rotation 270
```

Rotate pages 4 to 10 of "file1.pdf" 90 degrees anticlockwise.

### Set absolute rotation
```powershell
PS C:\> Set-PDFDocumentRotation -Document file1.pdf -Rotation 0 -AbsoluteRotation
```

Set all pages back to their default rotation.

## PARAMETERS

### -AbsoluteRotation
Whether rotation value given is an absolute value or relative to the current page rotation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
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

### -Pages
Pages to process.

```yaml
Type: Int32[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rotation
Angle of rotation. Must be a multiple of 90.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: 0, 90, 180, 270

Required: True
Position: 3
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
