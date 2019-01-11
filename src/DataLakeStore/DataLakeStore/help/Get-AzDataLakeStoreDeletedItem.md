---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStore.dll-Help.xml
Module Name: Az.DataLakeStore
ms.assetid: ECA70C6C-E0B0-445D-BCAD-041625FAC632
online version: https://docs.microsoft.com/en-us/powershell/module/az.datalakestore/get-azdatalakestoreitem
schema: 2.0.0
---

# Get-AzDataLakeStoreDeletedItem

## SYNOPSIS
Searches for deleted entries in trash which match the hint.

## SYNTAX

```
Get-AzDataLakeStoreDeletedItem [-Account] <String> [-Hint] <String> [-ListAfter] <String> [-NumResults] <String>
```

## DESCRIPTION
The **Get-AzDataLakeStoreDeletedItem** cmdlet searches the deleted file or folder in Data Lake Store which match the given hint.
Displays the following attributes of the deleted items - TrashDirPath, OriginalPath, Type, CreationTime.

## EXAMPLES

### Example 1: Get details of a file from the Data Lake Store
```
PS> Get-AzDataLakeStoreDeletedItem

cmdlet Get-AzDataLakeStoreDeletedItem at command pipeline position 1
Supply values for the following parameters:
(Type !? for Help.)
Account: ml1ptrashtest
Hint: test10/file_1111
Searched = 6139794, Found = 2, NextListAfter =

TrashDirPath                                                                                                                      OriginalPath                                           Type  CreationTime
------------                                                                                                                      ------------                                           ----  ------------
adl://ml1ptrashtest.azuredatalake.com/$temp/trash/131914656000000000/me1sch201110513/deleted_cc099508-d9fe-418d-9533-6b5a58029413 adl://ml1ptrashtest.azuredatalake.com/test10/file_1111 FILE 1547028995596
adl://ml1ptrashtest.azuredatalake.com/$temp/trash/131914656000000000/me1sch201111512/deleted_f33a3dfc-c23d-4e30-9ffd-d62d6ee3b73a adl://ml1ptrashtest.azuredatalake.com/test10/file_1111 FILE 1547029302628

```

This command gets the details of the file Test.csv from the Data Lake Store.

## PARAMETERS

### -Account
Specifies the name of the Data Lake Store account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Hint
Specifies the search query. A more specific value gives more relevant results.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ListAfter
Specifies the checkpoint to start search at. Must be the value returned from a previous output. 

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: 

Required: False
Position:
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NumResults
Specifies the number of results the user wants to find. The query runs until it finds NumResults results or it searches through entire trash, whichever happens first.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: 

Required: False
Position:
Default value: 1
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

[Restore-AzDataLakeStoreDeletedItem](./Export-AzDataLakeStoreDeletedItem.md)