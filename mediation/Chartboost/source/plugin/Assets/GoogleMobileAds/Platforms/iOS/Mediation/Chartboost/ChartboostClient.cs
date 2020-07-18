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

#if UNITY_IOS

using UnityEngine;

using GoogleMobileAds.Api.Mediation.Chartboost;
using GoogleMobileAds.Common.Mediation.Chartboost;

namespace GoogleMobileAds.iOS.Mediation.Chartboost
{
    public class ChartboostClient : IChartboostClient
    {
        private static ChartboostClient instance = new ChartboostClient();
        private ChartboostClient() {}

        public static ChartboostClient Instance
        {
            get
            {
                return instance;
            }
        }

        public void AddDataUseConsent(ChartboostGDPRConsent gdprConsent)
        {
            Externs.GADUMChartboostAddGDPRDataUseConsent((int)gdprConsent);
        }

        public void AddDataUseConsent(ChartboostCCPAConsent ccpaConsent)
        {
            Externs.GADUMChartboostAddCCPADataUseConsent((int)ccpaConsent);
        }

        public void AddDataUseConsent(string customConsentName, string customConsentValue)
        {
            MonoBehaviour.print("This API is not available for iOS. " +
                "Please use Chartboost.AddDataUseConsent(ChartboostConsentType, string).");
        }

        public void AddDataUseConsent(ChartboostConsentType consentType, string customConsent)
        {
            if (consentType == ChartboostConsentType.CCPA)
            {
                Externs.GADUMChartboostAddCustomGDPRDataUseConsent(customConsent);
            }
            else if (consentType == ChartboostConsentType.GDPR)
            {
                Externs.GADUMChartboostAddCustomCCPADataUseConsent(customConsent);
            }
        }

        public void ClearDataUseConsent(string privacyStandard)
        {
            MonoBehaviour.print("This API is not available for iOS. " +
                "Please use Chartboost.AddDataUseConsent(ChartboostConsentType).");
        }

        public void ClearDataUseConsent(ChartboostConsentType consentType)
        {
            if (consentType == ChartboostConsentType.CCPA)
            {
                Externs.GADUMChartboostClearGDPRDataUseConsent();
            }
            else if (consentType == ChartboostConsentType.GDPR)
            {
                Externs.GADUMChartboostClearCCPADataUseConsent();
            }
        }
    }
}

#endif
