﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggleh
{
    public interface IFormGUI
    {
        void Register(FormPresenter FM);
        void InitialiseForm();
        string TriggerName { get; set; }
        string RewardName { get; set; }
        bool BitsEnabled { get; set; }
        int BitsCondition { get; set; }
        bool BitsConditionEnabled { get; set; }
        int BitsAmount1 { get; set; }
        bool BitsAmount1Enabled { get; set; }
        int BitsAmount2 { get; set; }
        bool BitsAmount2Visible { get; set; }
        string BitsInfo1 { get; set; }
        bool BitsInfo2 { get; set; }
        string Keyword { get; set; }
        int KeywordsIndex { get; set; }
        bool UserLevelEveryone { get; set; }
        bool UserLevelSubs { get; set; }
        bool UserLevelSubsEnabled { get; set; }
        bool UserLevelVips { get; set; }
        bool UserLevelVipsEnabled { get; set; }
        bool UserLevelMods { get; set; }
        bool UserLevelModsEnabled { get; set; }
        int AddKeyword(string keyword);
        bool HasKeyword(string keyword);
        void RemoveKeyword(int index);
        string GetKeywords();
        string CharAnimTriggerKeyChar { get; set; }
        int CharAnimTriggerKeyValue { get; set; }
        int Cooldown { get; set; }
        int CooldownUnit { get; set; }
        string LastTriggered { get; set; }
        // bool NotifyIconVisible { get; set; }

        void ResetDetails();
        void EnableBits(bool enabled);
        void EnableBitsBetween(bool enabled);
        void AllowSubsMods(bool allowed);
        void SetAddKeywordAccept();

        bool RecordingTrigger { get; set; }
        void StartRecordingTrigger();
        void StopRecordingTrigger();

        void ClearTriggers();
        void PopulateTrigger(Trigger trigger);
        void PopulateTriggerDetails(Trigger trigger);
        void SetSelectedTrigger(int index);
        string GetSelectedTrigger();
        int GetNumberRows();

        int Dgv_CurrentRow { get; set; }

        void ShowError(string label, bool showing);
        void ShowValidationError(bool showing);
        void RefreshCharAnimStatus();

        void ShowSettingsForm();

        void SetProfilePicture(string url);
        void UpdateChatStatus(int status);
        void SetLastTriggered(string time);
        void ResetButtonVisible(bool showing);

        void ShowChangesMade(bool showing);

        void EnableAsReward();
        void DisableAsReward();

        void ShowRewardNameHelp();
    }
}
