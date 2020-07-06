using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] PlayerStatusManager playerStatusManager;
   

    void Update()
    {
        if (playerStatusManager.playerStatus == PlayerStatus.InitialUpperGround)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            playerStatusManager.playerStatus = PlayerStatus.UpperGround;
      
        }

        if (playerStatusManager.playerStatus == PlayerStatus.UpperGround) 
        {
      


        }

        if (playerStatusManager.playerStatus == PlayerStatus.OnWell)
        {
          
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(1.0f, 0f, 0f);
                playerStatusManager.playerStatus = PlayerStatus.OnWellLookIn;
                
            }
            
        }
        if (playerStatusManager.playerStatus == PlayerStatus.OnWellLookIn)
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(2.0f, 0f, 0f);
            
            }
            if (transform.rotation.eulerAngles.x < 100 && transform.rotation.eulerAngles.x > 80)
            {
                playerStatusManager.playerStatus = PlayerStatus.InWell;
               
            }
        }


            if (playerStatusManager.playerStatus == PlayerStatus.InitialUnderGround) 
        {

            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            playerStatusManager.playerStatus = PlayerStatus.UnderGround;
           
        }
        if (playerStatusManager.playerStatus == PlayerStatus.UnderGround)
        {
          
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0f, -2.0f, 0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0f, 2.0f, 0f);
            }

        }

        if (playerStatusManager.playerStatus == PlayerStatus.BacktoUpperGround)
        {
            transform.eulerAngles = new Vector3(90.0f, 0f, 0f);
        }
        if (playerStatusManager.playerStatus == PlayerStatus.Seeyou)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
       
    }

}