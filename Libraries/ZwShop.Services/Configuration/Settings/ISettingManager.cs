using System.Collections.Generic;

namespace ZwShop.Services.Configuration.Settings
{
    public partial interface ISettingManager
    {
        Setting GetSettingById(int settingId);

        void DeleteSetting(int settingId);

        Dictionary<string, Setting> GetAllSettings();

        Setting SetParam(string name, string value);

        Setting SetParam(string name, string value, string description);

        Setting SetParamNative(string name, decimal value);

        Setting SetParamNative(string name, decimal value, string description);

        Setting AddSetting(string name, string value, string description);

        Setting UpdateSetting(int settingId, string name, string value, string description);

        bool GetSettingValueBoolean(string name);

        bool GetSettingValueBoolean(string name, bool defaultValue);

        int GetSettingValueInteger(string name);

        int GetSettingValueInteger(string name, int defaultValue);

        long GetSettingValueLong(string name);

        long GetSettingValueLong(string name, int defaultValue);

        decimal GetSettingValueDecimalNative(string name);

        decimal GetSettingValueDecimalNative(string name, decimal defaultValue);

        string GetSettingValue(string name);

        string GetSettingValue(string name, string defaultValue);

        Setting GetSettingByName(string name);

        string StoreName {get;set;}

        string StoreUrl { get; set; }

        string CurrentVersion { get; }
    }
}
