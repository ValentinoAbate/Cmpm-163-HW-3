using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public Material mat;
    public string colorName = "_StartColor";
    public Color start;
    public bool initNoiseSetting = false;

    private void Start()
    {
        mat.SetColor(colorName, start);
        NoiseAffectsColor(initNoiseSetting);
    }

    public void SetRed(float r)
    {
        Color c = mat.GetColor(colorName);
        mat.SetColor(colorName, new Color(r, c.g, c.b));
    }

    public void SetGreen(float g)
    {
        Color c = mat.GetColor(colorName);
        mat.SetColor(colorName, new Color(c.r, g, c.b));
    }

    public void SetBlue(float b)
    {
        Color c = mat.GetColor(colorName);
        mat.SetColor(colorName, new Color(c.r, c.g, b));
    }

    public void NoiseAffectsColor(bool value)
    {
        if (value)
            mat.SetFloat("_NoiseAffectsColor", 1);
        else
            mat.SetFloat("_NoiseAffectsColor", 0);
    }

}
