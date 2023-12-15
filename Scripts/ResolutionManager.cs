using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    private void Start()
    {
        // �]�w�C���ѪR�׬�1920x1080�öi�J���ù��Ҧ�
        SetResolutionAndFullscreen(1920, 1080);
    }

    private void SetResolutionAndFullscreen(int width, int height)
    {
        // �j�M�ó]�w�ؼиѪR��
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
