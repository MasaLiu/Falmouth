using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResSetting : MonoBehaviour
{
    public Dropdown resolutionDropdown; // 指定的 UI Dropdown
    public Toggle fullScreenToggle; // 指定的 UI Toggle

    private List<Resolution> resolutions; // 可用的分辨率列表

    private void Start()
    {
        // 指定解析度列表
        resolutions = new List<Resolution>()
        {
            new Resolution { width = 1280, height = 720 },
            new Resolution { width = 1366, height = 768 },
            new Resolution { width = 1920, height = 1080 },
            new Resolution { width = 2560, height = 1440 }
        };

        // 清空 Dropdown 的选项
        resolutionDropdown.ClearOptions();

        // 创建分辨率选项列表
        List<string> options = new List<string>();

        // 添加分辨率选项到列表
        foreach (Resolution resolution in resolutions)
        {
            string option = $"{resolution.width} x {resolution.height}";
            options.Add(option);
        }

        // 将选项列表分配给 Dropdown
        resolutionDropdown.AddOptions(options);

        // 检查并更新初始的分辨率
        int currentResolutionIndex = GetCurrentResolutionIndex();
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // 检查并更新初始的全屏状态
        bool isFullScreen = PlayerPrefs.GetInt("IsFullScreen", 1) == 1; // 从PlayerPrefs中获取全屏状态，默认为全屏
        Screen.fullScreen = isFullScreen;
        fullScreenToggle.isOn = isFullScreen;
    }

    private int GetCurrentResolutionIndex()
    {
        // 获取当前的分辨率
        Resolution currentResolution = Screen.currentResolution;

        // 在分辨率列表中查找匹配的索引
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                return i;
            }
        }

        return 0; // 默认返回第一个分辨率
    }

    public void ChangeResolution()
    {
        // 获取用户选择的分辨率索引
        int selectedResolutionIndex = resolutionDropdown.value;

        // 获取选择的分辨率
        Resolution selectedResolution = resolutions[selectedResolutionIndex];

        // 应用新的分辨率
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);

        // 保存分辨率到PlayerPrefs
        PlayerPrefs.SetInt("ScreenWidth", selectedResolution.width);
        PlayerPrefs.SetInt("ScreenHeight", selectedResolution.height);
        PlayerPrefs.Save();
    }

    public void ToggleFullScreen()
    {
        // 获取当前的全屏状态
        bool isFullScreen = fullScreenToggle.isOn;

        // 应用新的全屏状态
        Screen.fullScreen = isFullScreen;

        // 保存全屏状态到PlayerPrefs
        PlayerPrefs.SetInt("IsFullScreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void Awake()
    {
        // 恢复上次的分辨率设置
        int screenWidth = PlayerPrefs.GetInt("ScreenWidth", Screen.currentResolution.width);
        int screenHeight = PlayerPrefs.GetInt("ScreenHeight", Screen.currentResolution.height);
        Screen.SetResolution(screenWidth, screenHeight, Screen.fullScreen);

        // 恢复上次的全屏设置
        bool isFullScreen = PlayerPrefs.GetInt("IsFullScreen", 1) == 1;
        Screen.fullScreen = isFullScreen;
        fullScreenToggle.isOn = isFullScreen;
    }
}
