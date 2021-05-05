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

using Mona.SaaS.Core;
using Mona.SaaS.Core.Models;
using Mona.SaaS.Core.Models.Configuration;
using Mona.SaaS.Web.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace Mona.SaaS.Web.Extensions
{
    public static class LandingPageModelExtensions
    {
        /// <summary>
        /// Applies claims-based user information to the provided landing page model.
        /// </summary>
        /// <param name="landingPageModel">The landing page model.</param>
        /// <param name="claimsPrincipal">The claims-based user information.</param>
        /// <returns>The updated landing page model.</returns>
        public static LandingPageModel WithCurrentUserInformation(this LandingPageModel landingPageModel, ClaimsPrincipal claimsPrincipal)
        {
            if (landingPageModel == null)
            {
                throw new ArgumentNullException(nameof(landingPageModel));
            }

            if (claimsPrincipal != null)
            {
                landingPageModel.UserFriendlyName = claimsPrincipal.GetPreferredClaimValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname", "name");
            }

            return landingPageModel;
        }

        /// <summary>
        /// Applies general offer information to the provided landing page model.
        /// </summary>
        /// <param name="landingPageModel">The landing page model.</param>
        /// <param name="offerInfo">The general offer information.</param>
        /// <returns>The updated landing page model.</returns>
        public static LandingPageModel WithOfferInformation(this LandingPageModel landingPageModel, OfferConfiguration offerInfo)
        {
            if (landingPageModel == null)
            {
                throw new ArgumentNullException(nameof(landingPageModel));
            }

            if (offerInfo == null)
            {
                throw new ArgumentNullException(nameof(offerInfo));
            }

            landingPageModel.OfferDisplayName = offerInfo.OfferDisplayName;
            landingPageModel.OfferMarketingPageUrl = offerInfo.OfferMarketingPageUrl;
            landingPageModel.OfferMarketplaceListingUrl = offerInfo.OfferMarketplaceListingUrl;
            landingPageModel.PublisherContactPageUrl = offerInfo.PublisherContactPageUrl;
            landingPageModel.PublisherCopyrightNotice = offerInfo.PublisherCopyrightNotice;
            landingPageModel.PublisherDisplayName = offerInfo.PublisherDisplayName;
            landingPageModel.PublisherHomePageUrl = offerInfo.PublisherHomePageUrl;
            landingPageModel.PublisherPrivacyNoticePageUrl = offerInfo.PublisherPrivacyNoticePageUrl;

            return landingPageModel;
        }

        /// <summary>
        /// Applies subscription information to the provided landing page model.
        /// </summary>
        /// <param name="landingPageModel">The landing page model.</param>
        /// <param name="subscription">The subscription information.</param>
        /// <returns>The updated landing page model.</returns>
        public static LandingPageModel WithSubscriptionInformation(this LandingPageModel landingPageModel, Subscription subscription)
        {
            if (landingPageModel == null)
            {
                throw new ArgumentNullException(nameof(landingPageModel));
            }

            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }

            landingPageModel.BeneficiaryEmailAddress = subscription.Beneficiary.UserEmail;
            landingPageModel.PurchaserEmailAddress = subscription.Purchaser.UserEmail;
            landingPageModel.IsFreeTrial = subscription.IsFreeTrial;
            landingPageModel.OfferId = subscription.OfferId;
            landingPageModel.PlanId = subscription.PlanId;
            landingPageModel.SeatQuantity = subscription.SeatQuantity;
            landingPageModel.SubscriptionId = subscription.SubscriptionId;
            landingPageModel.SubscriptionName = subscription.SubscriptionName;

            return landingPageModel;
        }

        /// <summary>
        /// Applies an error code to the provided landing page model.
        /// </summary>
        /// <param name="landingPageModel">The landing page model.</param>
        /// <param name="errorCode">The error code.</param>
        /// <returns>The updated landing page model.</returns>
        public static LandingPageModel WithErrorCode(this LandingPageModel landingPageModel, string errorCode)
        {
            if (landingPageModel == null)
            {
                throw new ArgumentNullException(nameof(landingPageModel));
            }

            if (string.IsNullOrEmpty(errorCode))
            {
                throw new ArgumentNullException(nameof(errorCode));
            }

            landingPageModel.ErrorCode = errorCode;

            return landingPageModel;
        }
    }
}