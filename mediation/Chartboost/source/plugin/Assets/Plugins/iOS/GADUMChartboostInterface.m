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

#import <Chartboost/Chartboost.h>

void GADUMChartboostAddGDPRDataUseConsent(int gdprConsent) {
  CHBGDPRDataUseConsent *chbGDPRconsent;
  if (gdprConsent == (int)CHBGDPRConsentNonBehavioral) {
    chbGDPRconsent = [CHBGDPRDataUseConsent gdprConsent:CHBGDPRConsentNonBehavioral];
  } else if (gdprConsent == (int)CHBGDPRConsentBehavioral) {
    chbGDPRconsent = [CHBGDPRDataUseConsent gdprConsent:CHBGDPRConsentBehavioral];
  }
  [Chartboost addDataUseConsent:chbGDPRconsent];
}

void GADUMChartboostAddCCPADataUseConsent(int ccpaConsent) {
  CHBCCPADataUseConsent *chbCCPAconsent;
  if (ccpaConsent == (int)CHBCCPAConsentOptOutSale) {
    chbCCPAconsent = [CHBCCPADataUseConsent ccpaConsent:CHBGDPRConsentBehavioral];
  } else if (ccpaConsent == (int)CHBCCPAConsentOptInSale) {
    chbCCPAconsent = [CHBCCPADataUseConsent ccpaConsent:CHBGDPRConsentNonBehavioral];
  }
  [Chartboost addDataUseConsent:chbCCPAconsent];
}

void GADUMChartboostAddCustomGDPRDataUseConsent(const char *_Nonnull customConsent) {
  CHBCustomDataUseConsent *customDataConsent =
      [CHBCustomDataUseConsent customConsentWithPrivacyStandard:CHBPrivacyStandardGDPR
                                                        consent:@(customConsent)];
  [Chartboost addDataUseConsent:customDataConsent];
}

void GADUMChartboostAddCustomCCPADataUseConsent(const char *_Nonnull customConsent) {
  CHBCustomDataUseConsent *customDataConsent =
      [CHBCustomDataUseConsent customConsentWithPrivacyStandard:CHBPrivacyStandardCCPA
                                                        consent:@(customConsent)];
  [Chartboost addDataUseConsent:customDataConsent];
}

void GADUMChartboostClearGDPRDataUseConsent() {
  [Chartboost clearDataUseConsentForPrivacyStandard:CHBPrivacyStandardGDPR];
}

void GADUMChartboostClearCCPADataUseConsent() {
  [Chartboost clearDataUseConsentForPrivacyStandard:CHBPrivacyStandardCCPA];
}
