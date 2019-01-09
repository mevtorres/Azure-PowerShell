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
using Microsoft.Azure.DataLake.Store;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreDeletedItem"), OutputType(typeof(DataLakeStoreDeletedItem))]
    [Alias("Get-AdlStoreDeletedItem")]
    public class GetAzureDataLakeStoreDeletedItem : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Store account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The query string to match during search")]
        [ValidateNotNullOrEmpty]
        public string Hint { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The NextListAfter token returned in latest progress tracker, if search was interrupted or incomplete")]
        public string ListAfter { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Minimum number of entries to search for")]
        public int NumResults { get; set; }

        public override void ExecuteCmdlet()
        {
            var toReturn = DataLakeStoreFileSystemClient.EnumerateDeletedItems(Account, Hint, ListAfter, NumResults, this, CmdletCancellationToken).Select(entry => new DataLakeStoreDeletedItem(entry)).ToList();
            WriteObject(toReturn, true);
        }
    }
}

