using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScriptController : MonoBehaviour
{
    public SpeedScript[] scripts;
    
    public void SetSpeed(float speed)
    {
        foreach (var script in scripts)
            script.speedMod = speed;
    }
}
