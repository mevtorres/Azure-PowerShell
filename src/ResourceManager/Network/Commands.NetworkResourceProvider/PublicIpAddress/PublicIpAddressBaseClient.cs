﻿
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

using System;
using AutoMapper;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    public abstract class PublicIpAddressBaseClient : NetworkResourceBaseClient
    {
        public const string PublicIpAddressCmdletName = "AzurePublicIpAddress";

        public IPublicIpAddressOperations PublicIpAddressClient
        {
            get
            {
                return NetworkClient.NetworkResourceProviderClient.PublicIpAddresses;
            }
        }

        public bool IsPublicIpAddressPresent(string resourceGroupName, string name)
        {
            try
            {
                GetPublicIpAddress(resourceGroupName, name);
            }
            catch (CloudException exception)
            {
                if (string.Equals(exception.ErrorCode, ResourceNotFound, StringComparison.OrdinalIgnoreCase))
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSPublicIpAddress GetPublicIpAddress(string resourceGroupName, string name)
        {
            var getPublicIpAddressResponse = this.PublicIpAddressClient.Get(resourceGroupName, name);

            var publicIpAddress = Mapper.Map<PSPublicIpAddress>(getPublicIpAddressResponse.PublicIpAddress);
            publicIpAddress.ResourceGroupName = resourceGroupName;

            return publicIpAddress;
        }
    }
}