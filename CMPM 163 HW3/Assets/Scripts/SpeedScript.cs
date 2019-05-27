using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotateAround))]
public class SpeedScript : MonoBehaviour
{
    public float speedMod = 10;
    public float pow = 2;
    private RotateAround rot;
    // Start is called before the first frame update
    void Start()
    {
        rot = GetComponent<RotateAround>();  
    }

    // Update is called once per frame
    void Update()
    {
        int numPartitions = 1;
        float[] aveMag = new float[numPartitions];
        float partitionIndx = 0;
        int numDisplayedBins = 512 / 2;

        for (int i = 0; i < numDisplayedBins; i++)
        {
            if (i < numDisplayedBins * (partitionIndx + 1) / numPartitions)
            {
                aveMag[(int)partitionIndx] += AudioPeer.spectrumData[i] / (512 / numPartitions);
            }
            else
            {
                partitionIndx++;
                i--;
            }
        }

        for (int i = 0; i < numPartitions; i++)
        {
            aveMag[i] = (float)0.5 + aveMag[i] * 100;
            if (aveMag[i] > 100)
            {
                aveMag[i] = 100;
            }
        }

        float mag = aveMag[0];


        rot.speedMultiplier = Mathf.Pow((mag - 0.5f) * speedMod, pow);
    }
}
