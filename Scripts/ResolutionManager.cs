using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    private void Start()
    {
        // 設定遊戲解析度為1920x1080並進入全螢幕模式
        SetResolutionAndFullscreen(1920, 1080);
    }

    private void SetResolutionAndFullscreen(int width, int height)
    {
        // 搜尋並設定目標解析度
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].width == width && Screen.resolutions[i].height == height)
            {
                Screen.SetResolution(width, height, true);
                break;
            }
        }
    }
}
