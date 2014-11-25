﻿// ----------------------------------------------------------------------------------
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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.New, "AzureLoadBalancerBackendAddressPoolConfigCmdlet")]
    public class NewBackendAddressPoolConfigCmdletCmdlet : NetworkBaseClient
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "IPConfig IDs of NetworkInterfaces")]
        [ValidateNotNullOrEmpty]
        public List<string> BackendIpConfigurationId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var backendAddressPool = new PSBackendAddressPool();
            backendAddressPool.Name = this.Name;
            backendAddressPool.Properties = new PSBackendAddressPoolProperties();
            backendAddressPool.Properties.BackendIpConfigurations = new List<PSResourceId>();

            foreach (var backendIpConfigurationId in this.BackendIpConfigurationId)
            {
                var resourceId = new PSResourceId();
                resourceId.Id = backendIpConfigurationId;
                backendAddressPool.Properties.BackendIpConfigurations.Add(resourceId);
            }

            WriteObject(backendAddressPool);
        }
    }
}
