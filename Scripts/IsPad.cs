using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPad : MonoBehaviour
{
    public bool isPhone;
    private void Start()
    {
        IsPhoneFunc();
    }
    public bool IsPhoneFunc()
    {
        isPhone = true;
#if UNITY_IPHONE && !UNITY_EDITOR
			string deviceInfo = SystemInfo.deviceModel.ToString();
			isPhone = deviceInfo.Contains("iPhone");
#else
        float physicscreen = 1.0f * Screen.width / Screen.height;
        isPhone = physicscreen > 1.5f; //(the ratio 4:3 = 1.33; 16:9 = 1.777;)
#endif
        return isPhone;
    }
}
