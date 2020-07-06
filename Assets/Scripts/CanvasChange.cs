using UnityEngine;
using System.Collections;


public class CanvasChange : MonoBehaviour {

    public Material[] _material;           // 割り当てるマテリアル.
   
    static public int canvastime = 0;

    void Start () {
        canvastime = RealTime();
       
        if(canvastime < 132500)
        {
            this.GetComponent<Renderer>().material = _material[0];
        }
        else if (canvastime < 328000)
        {
            this.GetComponent<Renderer>().material = _material[1];
        }
        else if (canvastime < 677000)
        {
            this.GetComponent<Renderer>().material = _material[2];
        }
        else if (canvastime < 768000)
        {
            this.GetComponent<Renderer>().material = _material[3];
        }
        else if (canvastime < 1118000)
        {
            this.GetComponent<Renderer>().material = _material[4];
        }
        else 
        {
            this.GetComponent<Renderer>().material = _material[5];
        }
    }

    int RealTime()
    {
        int D0 = 3;
        int H0 = 0;
        int M0 = 0;
        int S0 = 0;
        int starttime = 0;
        int playertime = 0;
        int canvastime = 0;

        int DD = System.DateTime.Now.Day;
        int HH = System.DateTime.Now.Hour;
        int MM = System.DateTime.Now.Minute;
        int SS = System.DateTime.Now.Second;


        starttime = H0 * 60 * 60 + M0 * 60 + S0;
        playertime = (DD - D0) * 60 * 60 * 24 + HH * 60 * 60 + MM * 60 + SS;
        canvastime = (playertime - starttime) *4;
        Debug.Log(starttime + " " + playertime + " " + canvastime);
        return canvastime;
    }


}