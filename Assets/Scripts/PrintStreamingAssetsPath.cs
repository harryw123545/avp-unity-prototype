using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintStreamingAssetsPath : MonoBehaviour
{
    void Start()
    {
        Debug.Log("StreamingAssetsPath: " + Application.streamingAssetsPath);
    }
}
