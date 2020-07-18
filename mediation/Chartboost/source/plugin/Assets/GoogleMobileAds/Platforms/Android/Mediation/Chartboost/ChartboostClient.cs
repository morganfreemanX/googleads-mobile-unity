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

#if UNITY_ANDROID

using UnityEngine;
using System.Reflection;

using GoogleMobileAds.Api.Mediation.Chartboost;
using GoogleMobileAds.Common.Mediation.Chartboost;

namespace GoogleMobileAds.Android.Mediation.Chartboost
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
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass chartboost = new AndroidJavaClass("com.chartboost.sdk.Chartboost");

            AndroidJavaClass chartboostGDPRConsentEnum = new AndroidJavaClass("com.chartboost.sdk.Privacy.model.GDPR$GDPR_CONSENT");
            AndroidJavaObject gdprConsentObject;
            if (gdprConsent == ChartboostGDPRConsent.NON_BEHAVIORAL)
            {
                gdprConsentObject = chartboostGDPRConsentEnum.GetStatic<AndroidJavaObject>("NON_BEHAVIORAL");
            }
            else if (gdprConsent == ChartboostGDPRConsent.BEHAVIORAL)
            {
                gdprConsentObject = chartboostGDPRConsentEnum.GetStatic<AndroidJavaObject>("BEHAVIORAL");
            }
            else
            {
                MonoBehaviour.print("Invalid Chartboost GDPR consent configuration.");
                return;
            }

            AndroidJavaObject dataUseConsent = new AndroidJavaObject("com.chartboost.sdk.Privacy.model.GDPR", gdprConsentObject);
            chartboost.CallStatic("addDataUseConsent", currentActivity, dataUseConsent);
        }

        public void AddDataUseConsent(ChartboostCCPAConsent ccpaConsent)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass chartboost = new AndroidJavaClass("com.chartboost.sdk.Chartboost");

            AndroidJavaClass chartboostCCPAConsentEnum = new AndroidJavaClass("com.chartboost.sdk.Privacy.model.CCPA$CCPA_CONSENT");
            AndroidJavaObject ccpaConsentObject;
            if (ccpaConsent == ChartboostCCPAConsent.OPT_OUT_SALE)
            {
                ccpaConsentObject = chartboostCCPAConsentEnum.GetStatic<AndroidJavaObject>("OPT_OUT_SALE");
            }
            else if (ccpaConsent == ChartboostCCPAConsent.OPT_IN_SALE)
            {
                ccpaConsentObject = chartboostCCPAConsentEnum.GetStatic<AndroidJavaObject>("OPT_IN_SALE");
            }
            else
            {
                MonoBehaviour.print("Invalid Chartboost CCPA consent configuration.");
                return;
            }

            AndroidJavaObject dataUseConsent = new AndroidJavaObject("com.chartboost.sdk.Privacy.model.CCPA", ccpaConsentObject);
            chartboost.CallStatic("addDataUseConsent", currentActivity, dataUseConsent);
        }

        public void AddDataUseConsent(ChartboostConsentType consentType, string customConsent)
        {
            MonoBehaviour.print("This API is not available for Android. " +
                "Please use Chartboost.AddDataUseConsent(string, string).");
        }

        public void AddDataUseConsent(string customConsentName, string customConsentValue)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass chartboost = new AndroidJavaClass("com.chartboost.sdk.Chartboost");

            AndroidJavaObject dataUseConsent = new AndroidJavaObject("com.chartboost.sdk.Privacy.model.Custom", customConsentName, customConsentValue);
            chartboost.CallStatic("addDataUseConsent", currentActivity, dataUseConsent);
        }

        public void ClearDataUseConsent(ChartboostConsentType consentType)
        {
            MonoBehaviour.print("This API is not available for Android. " +
                "Please use Chartboost.ClearDataUseConsent(string).");
        }

        public void ClearDataUseConsent(string privacyStandard)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass chartboost = new AndroidJavaClass("com.chartboost.sdk.Chartboost");

            chartboost.CallStatic<AndroidJavaObject>("clearDataUseConsent", currentActivity, privacyStandard);
        }
    }
}

#endif
