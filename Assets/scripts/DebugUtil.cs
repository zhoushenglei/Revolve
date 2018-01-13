using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUtil : MonoBehaviour {

    private static int INFO = 2;
    private static int LEVEL = 0;
    public static void log(string str) {
        if (LEVEL > INFO) {
            Debug.Log(str);
        }
        
    }
}
