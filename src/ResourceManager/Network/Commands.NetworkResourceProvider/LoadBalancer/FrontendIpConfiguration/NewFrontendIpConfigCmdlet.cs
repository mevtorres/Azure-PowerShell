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

using System.Management.Automation;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.New, "AzureLoadBalancerFrontendIpConfig")]
    public class NewLoadBalancerFrontendIpConfigCmdlet : NetworkBaseClient
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the FrontendIpConfiguration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The public IP address allocation method.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Management.Network.Models.IpAllocationMethod.Dynamic, IgnoreCase = true)]
        public string AllocationMethod { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "id",
            HelpMessage = "SubnetId")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "object",
            HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "id",
            HelpMessage = "PublicIpAddressId")]
        public string PublicIpAddressId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "object",
            HelpMessage = "PublicIpAddress")]
        public PSPublicIpAddress PublicIpAddress { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // Get the subnetId and publicIpAddressId from the object if specified
            if (string.Equals(ParameterSetName, "id"))
            {
                this.SubnetId = this.Subnet.Id;

                if (PublicIpAddress != null)
                {
                    this.PublicIpAddressId = this.PublicIpAddress.Id;
                }
            }

            var frontendIpConfig = new PSFrontendIpConfiguration();
            frontendIpConfig.Name = this.Name;
            frontendIpConfig.Properties = new PSFrontendIpConfigurationProperties();
            frontendIpConfig.Properties.PrivateIpAllocationMethod = this.AllocationMethod;
            frontendIpConfig.Properties.Subnet = new PSResourceId();
            frontendIpConfig.Properties.Subnet.Id = this.SubnetId;


            if (!string.IsNullOrEmpty(this.PublicIpAddressId))
            {
                frontendIpConfig.Properties.PublicIpAddress = new PSResourceId();
                frontendIpConfig.Properties.PublicIpAddress.Id = this.PublicIpAddressId;
            }

            WriteObject(frontendIpConfig);

        }
    }
}
