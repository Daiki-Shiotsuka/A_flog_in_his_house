using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    public PlayerStatus playerStatus;
  
    void Awake()
    {
        playerStatus = new PlayerStatus();
        playerStatus = PlayerStatus.InInUpperGround;
    }
}
