using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public GameObject initialupperground;
    public GameObject upperground;
    public GameObject onwell;
    public GameObject inwell;
    public GameObject inwellLast;
    public GameObject seeyou;
    public GameObject player;
    public GameObject Uppermove;
    public GameObject Underrmove;
    public GameObject TextSeeyou;
    public GameObject memo1;
    public GameObject memo2;
    public GameObject memo3;
    public GameObject memo4;
    public GameObject book;
    [SerializeField] PlayerStatusManager playerStatusManager;
   
    void Start()
    {
        initialupperground.SetActive(true);
        upperground.SetActive(false);
        onwell.SetActive(false);
        inwell.SetActive(false);
        inwellLast.SetActive(false);
        seeyou.SetActive(false);
        Uppermove.SetActive(true);
        Underrmove.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (playerStatusManager.playerStatus == PlayerStatus.UpperGround)
        {
          
            Uppermove.SetActive(true);
            initialupperground.SetActive(false);
            onwell.SetActive(false);
            inwellLast.SetActive(false);
            seeyou.SetActive(false);
            upperground.SetActive(true);

        }
        if (playerStatusManager.playerStatus == PlayerStatus.OnWell)
        {
            Uppermove.SetActive(false);
            seeyou.SetActive(false);
            upperground.SetActive(false);
            onwell.SetActive(true);

        }
        if (playerStatusManager.playerStatus == PlayerStatus.InWell)
        {
            onwell.SetActive(false);
            inwell.SetActive(true);
        }
        if (playerStatusManager.playerStatus == PlayerStatus.InWellLast)
        {
            inwell.SetActive(false);
            inwellLast.SetActive(true);
        }
        if (playerStatusManager.playerStatus == PlayerStatus.UnderGround)
        {
            Underrmove.SetActive(true);
            inwellLast.SetActive(false);
        }
        if (playerStatusManager.playerStatus == PlayerStatus.BacktoUpperGround)
        {
           
            Underrmove.SetActive(false);
            memo1.SetActive(false);
            memo2.SetActive(false);
            memo3.SetActive(false);
            memo4.SetActive(false);
            book.SetActive(false);
        }
         
        if (playerStatusManager.playerStatus == PlayerStatus.Seeyou)
        {
            initialupperground.SetActive(true);
            seeyou.SetActive(true);
           
        }
    }
}
