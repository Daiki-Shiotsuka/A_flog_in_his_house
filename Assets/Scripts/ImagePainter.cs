using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePainter : MonoBehaviour
{
    int flag = 0;
    
    int flogtime = 0;
 
    

    [SerializeField] int horizontalSize; // 
    [SerializeField] int verticalSize;
    [SerializeField] int drawSize;
    [SerializeField] DrawColorStatus drawColorStatus;

    [SerializeField] FlogStatusManager flogStatusManager;
    [SerializeField] AnimeStatusManager animeStatusManager;
    [SerializeField] GameObject targetCanvas; // 塗るべきPlane
    Texture2D drawTexture;
    Color[] colorBuffer;

    [SerializeField] Texture2D tex1;
    [SerializeField] Texture2D tex2;
    [SerializeField] Texture2D tex3;
    [SerializeField] Texture2D tex4;
    [SerializeField] Texture2D tex5;

    void Start()
    {
        Texture2D mainTexture = (Texture2D)targetCanvas.GetComponent<Renderer>().material.mainTexture;
        Color[] pixels = mainTexture.GetPixels();

        colorBuffer = new Color[pixels.Length];
        pixels.CopyTo(colorBuffer, 0);

        drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        drawTexture.filterMode = FilterMode.Point;

        RealTimeDraw();


    }

    void Update()
    {

       
        if (!DrawColorManager.IsDrawColor(drawColorStatus))
        {
            return;
        }

        // 色指定されてる場合は塗る
        SetColor();
        UpdateTexture();
    }

    void SetColor()
    {
        Debug.Log(drawTexture.width);
        Debug.Log(-transform.position.x);

        int drawCenterX = (int)(-transform.position.x * verticalSize + drawTexture.width / 2);
        int drawCenterY = (int)(-transform.position.z * horizontalSize + drawTexture.height / 2);

        // drawCenterの周囲drawSizeピクセルを塗る
        for (int rangeX = -drawSize; rangeX < drawSize; rangeX++)
        {
            for (int rangeY = -drawSize; rangeY < drawSize; rangeY++)
            {
                int drawX = drawCenterX + rangeX;
                int drawY = drawCenterY + rangeY;

                if (0 > drawX || drawX >= drawTexture.width)
                {
                    // 範囲外は塗らない
                    continue;
                }
                if (0 > drawY || drawY >= drawTexture.height)
                {
                    // 範囲外は塗らない
                    continue;
                }

                Color color = DrawColorManager.GetColorCode(drawColorStatus);
                
                Transform myTransform = this.transform;
                Vector3 pos = myTransform.position;
                int pix_x = 0;
                int pix_z = 0;
               

                pix_x = (int)(pos.x * 1000 + 350);
                pix_z = (int)(-pos.z * 1000 + 250);
                

                
                if (pix_x >= 0 && pix_x < 700 && pix_z >= 0 && pix_z < 500)
                {
                    Color c_gray = new Color(0.000f, 0f, 0f);
                    if (flogStatusManager.flogStatus == FlogStatus.f1)
                    {
                        Color c = tex1.GetPixel(pix_x, 500-pix_z);
                        if ((Math.Abs(c.r - c_gray.r) < 0.05f))
                        {
                            animeStatusManager.animeStatus = AnimeStatus.walk;
                        }
                        else
                        {
                            animeStatusManager.animeStatus = AnimeStatus.put;
                            colorBuffer.SetValue(c, pix_x + 699 * (500 - pix_z));
                        }
                   }
                    else if (flogStatusManager.flogStatus == FlogStatus.f2)
                    {
                        Color c = tex2.GetPixel(pix_x, 500 - pix_z);
                        if ((Math.Abs(c.r - c_gray.r) < 0.05f))
                        {
                            animeStatusManager.animeStatus = AnimeStatus.walk;
                        }
                        else
                        {
                            animeStatusManager.animeStatus = AnimeStatus.put;
                            colorBuffer.SetValue(c, pix_x + 699 * (500 - pix_z));
                        }
                    }
                    else if (flogStatusManager.flogStatus == FlogStatus.f3)
                    {
                        Color c = tex3.GetPixel(pix_x, 500 - pix_z);
                        animeStatusManager.animeStatus = AnimeStatus.walkanddraw;
                        if ((Math.Abs(c.r - c_gray.r) < 0.05f))
                        {
                        }
                        else
                        {
                            colorBuffer.SetValue(c, pix_x + 699 * (500 - pix_z));
                        }
                    }
                    else if (flogStatusManager.flogStatus == FlogStatus.f4)
                    {
                        Color c = tex4.GetPixel(pix_x, 500 - pix_z);
                        if (Math.Abs(c.r - c_gray.r) < 0.05f)
                        {
                            animeStatusManager.animeStatus = AnimeStatus.walk;
                        }
                        else
                        {
                            animeStatusManager.animeStatus = AnimeStatus.put;
                            colorBuffer.SetValue(c, pix_x + 699 * (500 - pix_z));
                        }
                    }
                    else if (flogStatusManager.flogStatus == FlogStatus.f5)
                    {
                        Color c = tex5.GetPixel(pix_x, 500 - pix_z);
                        if (Math.Abs(c.r - c_gray.r) < 0.05f)
                        {
                            animeStatusManager.animeStatus = AnimeStatus.walk;
                        }
                        else
                        {
                            animeStatusManager.animeStatus = AnimeStatus.put;
                            colorBuffer.SetValue(c, pix_x + 699 * (500 - pix_z));
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    colorBuffer.SetValue(new Color(0.5f, 0.5f, 0.5f), drawX + 350 * drawY);
                }
                
           

                    

            }
        }
    }

    void UpdateTexture()
    {
        drawTexture.SetPixels(colorBuffer);
        drawTexture.Apply();
        targetCanvas.GetComponent<Renderer>().material.mainTexture = drawTexture;
    }
   
   
    void RealTimeDraw()
    {
        
        if (flogStatusManager.flogStatus == FlogStatus.f0)
        {

            flogtime = CanvasChange.canvastime;
            if (flogtime < 132500)
            {
                int range1 = flogtime + 310 * 699;
                for (int i = 0; i < range1; i++)
                {
                    int x1 = i % 699;
                    int z1 = i / 699 + 1;
                   
                   
                    Color c_gray1 = new Color(0f, 0f, 0f);
                    Color c1 = tex1.GetPixel(x1, 500 - z1);

                    if ((Math.Abs(c1.r - c_gray1.r) < 0.05f))
                    {
                    }
                    else
                    {
                        colorBuffer.SetValue(c1, x1 + 699 * (500 - z1));
                    }

                }
                flogStatusManager.flogStatus = FlogStatus.f1;
            }
            else if (flogtime < 328000)
            {
                int f2flogtime = flogtime - 132500;
                for (int i = 0; i < f2flogtime; i++)
                {
                    int x2 = i % 699;
                    int z2 = i / 699 + 1;

                    Color c_gray2 = new Color(0f, 0f, 0f);
                    Color c2 = tex2.GetPixel(x2, 500 - z2);

                    if ((Math.Abs(c2.r - c_gray2.r) < 0.05f))
                    {
                    }
                    else
                    {
                        colorBuffer.SetValue(c2, x2 + 699 * (500 - z2));
                    }

                }
                flogStatusManager.flogStatus = FlogStatus.f2;

            }
            else if (flogtime < 677000)
            {
                int f3flogtime = flogtime - 328000;
                for (int i = 0; i < f3flogtime; i++)
                {
                    int x3 = i % 699;
                    int z3 = i / 699 + 1;

                    Color c_gray3 = new Color(0.498f, 0.498f, 0.498f);
                    Color c3 = tex3.GetPixel(x3, 500 - z3);
                  
                    if ((Math.Abs(c3.r - 0f) < 0.05f))
                    {
                   
                    }
                    else
                    {
                        colorBuffer.SetValue(c3, x3 + 699 * (500 - z3));
                    }

                }

                flogStatusManager.flogStatus = FlogStatus.f3;
            }
            else if (flogtime < 768000)
            {
                int f4flogtime = flogtime - 677000;
                int rangef4 = f4flogtime + 300 * 699;
                for (int i = 0; i < rangef4; i++)
                {
                    int x4 = i % 699;
                    int z4 = i / 699 + 1;

                    Color c_gray4 = new Color(0f, 0f, 0f);
                    Color c4 = tex4.GetPixel(x4, 500 - z4);

                    if ((Math.Abs(c4.r - c_gray4.r) < 0.05f))
                    {
                    }
                    else
                    {
                        colorBuffer.SetValue(c4, x4 + 699 * (500 - z4));
                    }

                }
                flogStatusManager.flogStatus = FlogStatus.f4;
            }
            else if (flogtime < 1118000)
            {
                int f5flogtime = flogtime - 768000;
                for (int i = 0; i < f5flogtime; i++)
                {
                    int x5 = i % 699;
                    int z5 = i / 699 + 1;

                    Color c_gray5 = new Color(0f, 0f, 0f);
                    Color c5 = tex5.GetPixel(x5, 500 - z5);

                    if ((Math.Abs(c5.r - c_gray5.r) < 0.05f))
                    {
                    }
                    else
                    {
                        colorBuffer.SetValue(c5, x5 + 699 * (500 - z5));
                    }

                }
                flogStatusManager.flogStatus = FlogStatus.f5;
            }

            else
            {
                flogStatusManager.flogStatus = FlogStatus.f6;
            }

        }
    }
}
