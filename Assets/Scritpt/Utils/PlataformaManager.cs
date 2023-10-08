using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaManager
{
    public static bool IsRunningOnMobile()
    {
        bool isRunningOnMobile = true;
#if UNITY_STANDALONE
        Debug.Log("Running on Desktop");
        isRunningOnMobile = false;
#elif UNITY_ANDROID || UNITY_IOS
        Debug.Log("Running on Mobile App");
        isRunningOnMobile = false;
#endif
        return isRunningOnMobile;
    }
}
