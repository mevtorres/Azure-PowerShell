// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataLakeStore.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreDeletedItem"), OutputType(typeof(DataLakeStoreDeletedItem))]
    [Alias("Restore-AdlStoreDeletedItem")]
    public class RestoreAzureDataLakeStoreDeletedItem : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Store account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The trash directory path in enumeratedeleteditems response")]
        [ValidateNotNullOrEmpty]
        public string PathOfFileToRestoreInTrash { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "Path to where the entry should be restored")]
        [ValidateNotNullOrEmpty]
        public string RestoreDestination { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = true,
            HelpMessage = "Type of the entry which is being restored. \"file\" or \"folder\"")]
        public string Type { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Action to take during destination name conflicts - \"overwrite\" or \"copy\"")]
        public string RestoreAction { get; set; }

        public override void ExecuteCmdlet()
        {
            DataLakeStoreFileSystemClient.RestoreDeletedItem(Account, PathOfFileToRestoreInTrash, RestoreDestination, Type, RestoreAction, CmdletCancellationToken);
        }
    }
}

