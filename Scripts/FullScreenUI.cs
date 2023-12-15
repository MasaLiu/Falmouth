using UnityEngine;
using UnityEngine.UI;

public class FullScreenUI : MonoBehaviour
{
    public Toggle fullScreenToggle; // 指定的 UI Toggle

    private void Start()
    {
        // 检查并更新初始的全屏状态
        bool isFullScreen = PlayerPrefs.GetInt("IsFullScreen", 1) == 1; // 从PlayerPrefs中获取全屏状态，默认为全屏
        Screen.fullScreen = isFullScreen;
        fullScreenToggle.isOn = isFullScreen;
    }

    public void ToggleFullScreen()
    {
        // 获取当前的全屏状态
        bool isFullScreen = Screen.fullScreen;

        // 切换全屏状态
        isFullScreen = !isFullScreen;

        // 应用新的全屏状态
        Screen.fullScreen = isFullScreen;

        // 更新 UI Toggle 的状态
        fullScreenToggle.isOn = isFullScreen;

        // 保存全屏状态到PlayerPrefs
        PlayerPrefs.SetInt("IsFullScreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }
}
