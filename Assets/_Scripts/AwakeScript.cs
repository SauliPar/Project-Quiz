using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        FindObjectOfType<SettingsManager>().Initialize();
    }
}
