// Copyright 2018 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;

using GoogleMobileAds.Common.Mediation.Chartboost;
using GoogleMobileAds.Mediation;

namespace GoogleMobileAds.Api.Mediation.Chartboost
{
    public enum ChartboostConsentType
    {
        GDPR = 0,
        CCPA
    }

    public enum ChartboostGDPRConsent
    {
        NON_BEHAVIORAL = 0,
        BEHAVIORAL,
    }

    public enum ChartboostCCPAConsent
    {
        OPT_OUT_SALE = 0,
        OPT_IN_SALE,
    }

    public class Chartboost
    {
        public static readonly IChartboostClient client = GetChartboostClient();

        private static IChartboostClient GetChartboostClient()
        {
            return ChartboostClientFactory.ChartboostInstance ();
        }

        public static void AddDataUseConsent(ChartboostGDPRConsent gdprConsent)
        {
            client.AddDataUseConsent(gdprConsent);
        }

        public static void AddDataUseConsent(ChartboostCCPAConsent ccpaConsent)
        {
            client.AddDataUseConsent(ccpaConsent);
        }

        public static void AddDataUseConsent(ChartboostConsentType consentType, string customConsent)
        {
            client.AddDataUseConsent(consentType, customConsent);
        }

        public static void AddDataUseConsent(string customConsentName, string customConsentValue)
        {
            client.AddDataUseConsent(customConsentName, customConsentValue);
        }

        public static void ClearDataUseConsent(ChartboostConsentType consentType)
        {
            client.ClearDataUseConsent(consentType);
        }

        public static void ClearDataUseConsent(string privacyStandard)
        {
            client.ClearDataUseConsent(privacyStandard);
        }
    }
}
