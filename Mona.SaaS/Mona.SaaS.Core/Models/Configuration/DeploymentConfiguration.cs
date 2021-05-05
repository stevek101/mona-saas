﻿// MICROSOFT CONFIDENTIAL INFORMATION
//
// Copyright © Microsoft Corporation
//
// Microsoft Corporation (or based on where you live, one of its affiliates) licenses this preview code for your internal testing purposes only.
//
// Microsoft provides the following preview code AS IS without warranty of any kind. The preview code is not supported under any Microsoft standard support program or services.
//
// Microsoft further disclaims all implied warranties including, without limitation, any implied warranties of merchantability or of fitness for a particular purpose. The entire risk arising out of the use or performance of the preview code remains with you.
//
// In no event shall Microsoft be liable for any damages whatsoever (including, without limitation, damages for loss of business profits, business interruption, loss of business information, or other pecuniary loss) arising out of the use of or inability to use the preview code, even if Microsoft has been advised of the possibility of such damages.

using System.ComponentModel.DataAnnotations;

namespace Mona.SaaS.Core.Models.Configuration
{
    /// <summary>
    /// Provides information regarding the deployment of this Mona application.
    /// </summary>
    public class DeploymentConfiguration
    {
        /// <summary>
        /// Gets/sets the name of this Mona deployment.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets/sets this deployment's Mona version.
        /// </summary>
        [Required]
        public string MonaVersion { get; set; }

        /// <summary>
        /// Gets/sets the connection string needed to push events and metrics to App Insights.
        /// </summary>
        [Required]
        public string AppInsightsConnectionString { get; set; }

        /// <summary>
        /// Gets/sets the Azure subscription ID that Mona has been deployed to.
        /// </summary>
        [Required]
        public string AzureSubscriptionId { get; set; }

        /// <summary>
        /// Gets/sets the Azure resource group name that Mona has been deployed to.
        /// </summary>
        [Required]
        public string AzureResourceGroupName { get; set; }

        /// <summary>
        /// Gets/sets whether or not this Mona deployment currently supports test mode.
        /// </summary>
        public bool IsTestModeEnabled { get; set; }
    }
}