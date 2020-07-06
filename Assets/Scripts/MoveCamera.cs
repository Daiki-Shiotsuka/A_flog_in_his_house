using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] PlayerStatusManager playerStatusManager;
    public GameObject memo1;
    public GameObject memo2;
    public GameObject memo3;
    public GameObject memo4;
    public GameObject memo5;
    public GameObject bookmemo;
    public GameObject Undermove;

    int bf1 = 0;
    int bf2 = 0;
    int bf3 = 0;
    int bf4 = 0;
    int bf5 = 0;

    void Start()
    {
       
    }

 
    void Update()
    {
        
        if(playerStatusManager.playerStatus == PlayerStatus.InInUpperGround)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerStatusManager.playerStatus = PlayerStatus.InitialUpperGround;
            }
        }
        if (playerStatusManager.playerStatus == PlayerStatus.UpperGround)
        {
            float playerpos_x = transform.position.x;
            float playerpos_z = transform.position.z;
            if (Input.GetKey(KeyCode.UpArrow))
            {
               
                transform.Translate(0f, 0f, 0.1f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0f, 0f, -0.1f);
            }
            /*
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //cameraTrans.Translate(Vector3.left * 0.1f);
                transform.Translate(-0.1f, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //cameraTrans.Translate(Vector3.right * 0.1f);
                transform.Translate(0.1f, 0f, 0f);
            }
            */
            if (transform.position.z > -0.5)
            {

                transform.position = new Vector3(playerpos_x, 1.5f, playerpos_z);
            }
          
            if (Math.Abs(transform.position.x)* Math.Abs(transform.position.x) + Math.Abs(transform.position.z)* Math.Abs(transform.position.z) > 50)
            {
                transform.position = new Vector3(playerpos_x, 1.5f, playerpos_z);
            }
            if (Math.Abs(transform.position.x) < 1.0 && transform.position.z > -2.0f)
            {
                playerStatusManager.playerStatus = PlayerStatus.OnWell;
            }
            

        }

        if (playerStatusManager.playerStatus == PlayerStatus.OnWell)
        {
            float playerpos_x = transform.position.x;
            float playerpos_z = transform.position.z;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                
                transform.Translate(0f, 0f, 0.1f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                
                transform.Translate(0f, 0f, -0.1f);
            }
         
            if (transform.position.z > -0.5)
            {
                transform.position = new Vector3(playerpos_x, 1.5f, playerpos_z);
            }
            if (Math.Abs(transform.position.x) > 1.0 || transform.position.z < -2.0f)
            {
                playerStatusManager.playerStatus = PlayerStatus.UpperGround;
            }
        }



        if (playerStatusManager.playerStatus == PlayerStatus.OnWellLookIn)
        {
            transform.position = new Vector3(0f, 1.5f, -0.3f);
        }

            if (playerStatusManager.playerStatus == PlayerStatus.InWell)
        {
            if (Input.GetKey(KeyCode.X))
            {
                transform.Translate(0f, -0.1f, 0f);
            }
          
            if (transform.position.y < -10.0f)
            {
                playerStatusManager.playerStatus = PlayerStatus.InWellLast;
            }

        }

        if (playerStatusManager.playerStatus  == PlayerStatus.InWellLast)
        {
            if (Input.GetKey(KeyCode.Y))
            {
                playerStatusManager.playerStatus = PlayerStatus.InitialUnderGround;
                transform.position = new Vector3(0f, -10.90f, -0.6f);
               
            }
            if (Input.GetKey(KeyCode.N))
            {
                playerStatusManager.playerStatus = PlayerStatus.InitialUpperGround;
                transform.position = new Vector3(0f, 1.5f, -7.03f);
               
            }

            
        }

        if (playerStatusManager.playerStatus == PlayerStatus.UnderGround)
        {
            
            Transform cameraTrans = GameObject.Find("Main Camera").transform;
            Transform m1Trans = GameObject.Find("memoleaf1").transform;
            Transform m2Trans = GameObject.Find("memoleaf2").transform;
            Transform m3Trans = GameObject.Find("memoleaf3").transform;
            Transform m4Trans = GameObject.Find("memoleaf4").transform;
            Transform m5Trans = GameObject.Find("memoleaf5").transform;
            Transform bookTrans = GameObject.Find("books").transform;

            float camerapos_x = cameraTrans.position.x;
            float camerapos_z = cameraTrans.position.z;

            if (Math.Abs((m1Trans.position.x + 0.02)- camerapos_x) < 0.1f && Math.Abs((m1Trans.position.z-0.03)- (camerapos_z)) < 0.1f)
            {
                memo1.SetActive(true);
                bf1 = 1;
            }
            else
            {
                memo1.SetActive(false);
            }
            
            if (Math.Abs((m2Trans.position.x) - camerapos_x) < 0.05f && Math.Abs((m2Trans.position.z) - (camerapos_z)) < 0.05f)
            {
                memo2.SetActive(true);
                bf2 = 1;
            }
            else
            {
                memo2.SetActive(false);
            }
            if (Math.Abs((m3Trans.position.x) - camerapos_x) < 0.1f && Math.Abs((m3Trans.position.z-0.02) - (camerapos_z)) < 0.1f)
            {
                bf3 = 1;
                memo3.SetActive(true);
            }
            else
            {
                memo3.SetActive(false);
            }
            if (Math.Abs((m4Trans.position.x) - camerapos_x) < 0.1f && Math.Abs((m4Trans.position.z) - (camerapos_z)) < 0.1f)
            {
                memo4.SetActive(true);
            }
            else
            {
                memo4.SetActive(false);
            }
            if (Math.Abs((m5Trans.position.x) - camerapos_x) < 0.1f && Math.Abs((m5Trans.position.z) - (camerapos_z)) < 0.1f)
            {
                memo5.SetActive(true);
            }
            else
            {
                memo5.SetActive(false);
            }

            if (Math.Abs((bookTrans.position.x) - camerapos_x) < 0.15f && Math.Abs((bookTrans.position.z ) - (camerapos_z)) < 0.15f && bf1 == 1 && bf2 == 1 &&bf3 == 1 && bf4 == 1 && bf5 == 1)
            {
               Undermove.SetActive(false);
               bookmemo.SetActive(true);
            }
            else
            {
                Undermove.SetActive(true);
                bookmemo.SetActive(false);
            }
             if (Input.GetKey(KeyCode.B))
            {
                cameraTrans.position = new Vector3(0f, -10.90f, 0f);
                playerStatusManager.playerStatus = PlayerStatus.BacktoUpperGround;
               
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                cameraTrans.Translate(Vector3.forward * 0.01f);
             }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                cameraTrans.Translate(Vector3.back * 0.01f);
             }
             if (Math.Abs(cameraTrans.position.x) * Math.Abs(cameraTrans.position.x) + Math.Abs(cameraTrans.position.z) * Math.Abs(cameraTrans.position.z) >= 0.35f)
            {
                cameraTrans.position = new Vector3(camerapos_x, -10.90f, camerapos_z);
            }


        }

        if (playerStatusManager.playerStatus == PlayerStatus.BacktoUpperGround)
        {
            if(transform.position.y <= 1.5f)
            {
                transform.Translate(0f, 0.2f, 0f);
            }
            else
            {
                Transform cameraTrans = GameObject.Find("Main Camera").transform;
                transform.position = new Vector3(0f, 1.5f, -7.03f);
                cameraTrans.localPosition = new Vector3(0f, 0f, 0f);
                playerStatusManager.playerStatus = PlayerStatus.Seeyou;
            }
            
        }
        if (playerStatusManager.playerStatus == PlayerStatus.Seeyou)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerStatusManager.playerStatus = PlayerStatus.InitialUpperGround;
            }
        }
       
    }
    
}