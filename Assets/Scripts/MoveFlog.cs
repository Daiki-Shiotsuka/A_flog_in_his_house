using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class MoveFlog : MonoBehaviour
{
    public GameObject treeedge;
    public GameObject blackstone;
    public GameObject whitestone;
    public GameObject finishplate;
    [SerializeField] FlogStatusManager flogStatusManager;
    // Update is called once per frame
    int drawdirection = 0;
    //int flogflogtime = 0;

    int flogflogtime = 0;
    float x = 0.0f;
    float z = 0.0f;
    void Start()
    {
        finishplate.SetActive(false);
        treeedge.SetActive(false);
        blackstone.SetActive(false);
        whitestone.SetActive(false);

        flogflogtime = CanvasChange.canvastime;
        if (flogflogtime < 132500)
        {
            x = (flogflogtime % 699.0f - 5 - 350.0f) / 1000.0f;
            z = (-(flogflogtime / 699 + 1) + 250.0f) / 1000.0f - 0.31f; 
        }
        
        else if(flogflogtime <328000)
        {
            int f1flogtime = flogflogtime - 132500;
            x = (f1flogtime % 699.0f - 5 - 350.0f) / 1000.0f;
            z = ((-(f1flogtime / 699 + 1) + 250.0f) / 1000.0f);
      
        }
        else if(flogflogtime < 677000)
        {
            int f3flogtime = flogflogtime - 328000;
            x = (f3flogtime % 699.0f - 5 - 350.0f) / 1000.0f;
            z = ((-(f3flogtime / 699 + 1) + 250.0f) / 1000.0f);
        
        }
        else if(flogflogtime < 768000)
        {
            int f4flogtime = flogflogtime - 677000;
            x = (f4flogtime % 699.0f - 5 - 350.0f) / 1000.0f;
            z = (-(f4flogtime / 699 + 1) + 250.0f) / 1000.0f - 0.30f;

        }
        else if (flogflogtime < 1118000)
        {
            int f4flogtime = flogflogtime - 768000;
            x = (f4flogtime % 699.0f - 5 - 350.0f) / 1000.0f;
            z = (-(f4flogtime / 699 + 1) + 250.0f) / 1000.0f;

        }

        else
        {
            flogStatusManager.flogStatus = FlogStatus.f6;
            x = -0.350f;
            z = -0.280f;
        }
      
        
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.x = x;
        pos.z = z;
        myTransform.position = pos;

    }
    void Update()
    {
       
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        if (flogStatusManager.flogStatus == FlogStatus.f6)
        {
            switch (drawdirection)
            {
                case 0:
                    pos.x += 0.002f;
                    //pos.x += 0.001f;
                    if (pos.x >= 0.350f)
                    {
                        transform.Rotate(new Vector3(0f, 180f, 0f));
                        drawdirection = 1;
                    }
                    break;
                case 1:
                    pos.x -= 0.002f;
                    if (pos.x <= -0.350f)
                    {
                        transform.Rotate(new Vector3(0f, 180f, 0f));
                        drawdirection = 0;
                    }
                    break;
            }
        }
        else
        {
            switch (drawdirection)
            {
                case 0:
                    pos.x += 0.0003f;
                    //pos.x += 0.001f;
                    if (pos.x >= 0.350f)
                    {
                        transform.Rotate(new Vector3(0f, 180f, 0f));
                        pos.z -= 0.001f;
                        drawdirection = 1;
                    }
                    break;
                case 1:
                    pos.x -= 0.0003f;
                    //pos.x -= 0.001f;
                    if (pos.x <= -0.350f)
                    {
                        transform.Rotate(new Vector3(0f, 180f, 0f));
                        pos.z -= 0.001f;
                        drawdirection = 0;
                    }
                    break;

            }



        }
        Transform flogTrans = GameObject.Find("Flog0616").transform;
        if (flogStatusManager.flogStatus == FlogStatus.f6)
        {
            flogTrans.localPosition = new Vector3(0f, 0f, 0f);
            finishplate.SetActive(true);
            treeedge.SetActive(false);
            blackstone.SetActive(false);
            whitestone.SetActive(false);
        }
        if (flogStatusManager.flogStatus == FlogStatus.f5)
        {
            flogTrans.localPosition = new Vector3(140f, 0f, 0f);
            treeedge.SetActive(false);
            blackstone.SetActive(false);
            whitestone.SetActive(true);
           
            if (pos.z <= -0.250f)
            {

                pos.x = -0.350f;
                pos.z = -0.280f;
                flogStatusManager.flogStatus = FlogStatus.f6;
            }
        }

        if (flogStatusManager.flogStatus == FlogStatus.f4)
        {
            flogTrans.localPosition = new Vector3(140f, 0f, 0f);
            treeedge.SetActive(false);
            blackstone.SetActive(false);
            whitestone.SetActive(true);

            if (pos.z <= -0.180f)
            {
                pos.x = -0.350f;
                pos.z = 0.250f;
                flogStatusManager.flogStatus = FlogStatus.f5;
   
            }
        }

        if (flogStatusManager.flogStatus == FlogStatus.f3)
        {
           
            flogTrans.localPosition = new Vector3(257.0f, 0f, 0f);
            treeedge.SetActive(true);
            blackstone.SetActive(false);
            whitestone.SetActive(false);

            if (pos.z <= -0.250f)
            {
                pos.x = -0.350f;
                pos.z = -0.050f;
                
                flogStatusManager.flogStatus = FlogStatus.f4;
            }
        }


        if (flogStatusManager.flogStatus == FlogStatus.f2)
        {
            flogTrans.localPosition = new Vector3(140f, 0f, 0f);
            treeedge.SetActive(false);
            blackstone.SetActive(true);
            whitestone.SetActive(false);

            if (pos.z <= -0.030f)
            {
                pos.x = -0.350f;
                pos.z = 0.250f;
               
                flogStatusManager.flogStatus = FlogStatus.f3;
            }
        }

        if (flogStatusManager.flogStatus == FlogStatus.f1)
        {
            flogTrans.localPosition = new Vector3(140f, 0f, 0f);
            treeedge.SetActive(false);
            blackstone.SetActive(true);
            whitestone.SetActive(false);
           
            if (pos.z <= -0.250f)
            {
                pos.x = -0.350f;
                pos.z = 0.250f;
                flogStatusManager.flogStatus = FlogStatus.f2;

            }
        }

        myTransform.position = pos;



      

    }
    
}