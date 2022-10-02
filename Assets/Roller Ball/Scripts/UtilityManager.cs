using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityManager 
{
    public static void SetaScreenTimeOut()
    {
        // Set screen timeout, so that it will remain ON
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public static bool IsInternetAvailable()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)   // No internet.
        {
            return false;
        }

        return true;
    }
}
