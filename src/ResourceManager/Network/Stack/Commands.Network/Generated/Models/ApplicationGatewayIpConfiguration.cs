// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// IP configuration of application gateway
    /// </summary>
    public partial class ApplicationGatewayIPConfiguration : SubResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ApplicationGatewayIPConfiguration class.
        /// </summary>
        public ApplicationGatewayIPConfiguration() { }

        /// <summary>
        /// Initializes a new instance of the
        /// ApplicationGatewayIPConfiguration class.
        /// </summary>
        public ApplicationGatewayIPConfiguration(string name = default(string), string etag = default(string), SubResource subnet = default(SubResource), string provisioningState = default(string))
        {
            Name = name;
            Etag = etag;
            Subnet = subnet;
            ProvisioningState = provisioningState;
        }

        /// <summary>
        /// Gets name of the resource that is unique within a resource group.
        /// This name can be used to access the resource
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is
        /// updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the reference of the subnet resource.A subnet from
        /// where appliation gateway gets its private address
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnet")]
        public SubResource Subnet { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the application gateway subnet
        /// resource Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

    }
}