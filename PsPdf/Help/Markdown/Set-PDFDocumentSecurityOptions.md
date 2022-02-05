---
external help file: PsPdf.dll-Help.xml
Module Name: PsPdf
online version:
schema: 2.0.0
---

# Set-PDFDocumentSecurityOptions

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

```
Set-PDFDocumentSecurityOptions [-Document] <String> [-UserPassword <String>] [-OwnerPassword <String>]
 [-CurrentOwnerPassword <String>] [-PermitAccessibilityExtractContent <Boolean>] [-PermitAnnotations <Boolean>]
 [-PermitAssembleDocument <Boolean>] [-PermitExtractContent <Boolean>] [-PermitFormsFill <Boolean>]
 [-PermitFullQualityPrint <Boolean>] [-PermitModifyDocument <Boolean>] [-PermitPrint <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -CurrentOwnerPassword
Current user password if required.

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
{{ Fill Document Description }}

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

### -OwnerPassword
Owner Password, required to modify permissions.
Will default to user password if left blank.

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

### -PermitAccessibilityExtractContent
{{ Fill PermitAccessibilityExtractContent Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermitAnnotations
{{ Fill PermitAnnotations Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermitAssembleDocument
{{ Fill PermitAssembleDocument Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermitExtractContent
{{ Fill PermitExtractContent Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermitFormsFill
{{ Fill PermitFormsFill Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermitFullQualityPrint
{{ Fill PermitFullQualityPrint Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermitModifyDocument
{{ Fill PermitModifyDocument Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermitPrint
{{ Fill PermitPrint Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPassword
User Password, required to open the PDF.

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
