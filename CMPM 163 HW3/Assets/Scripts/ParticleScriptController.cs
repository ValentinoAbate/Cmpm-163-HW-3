using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScriptController : MonoBehaviour
{
    public ParticleScript[] scripts;
    public void SetThreshold(float threshold)
    {
        foreach (var script in scripts)
            script.threshold = threshold;
    }

    public void SetNoiseX(float value)
    {
        foreach(var script in scripts)
        {
            var noise = script.ps.noise;
            noise.strengthX = value;
        }
    }

    public void SetNoiseY(float value)
    {
        foreach (var script in scripts)
        {
            var noise = script.ps.noise;
            noise.strengthY = value;
        }
    }

    public void SetNoiseZ(float value)
    {
        foreach (var script in scripts)
        {
            var noise = script.ps.noise;
            noise.strengthZ = value;
        }
    }
}
