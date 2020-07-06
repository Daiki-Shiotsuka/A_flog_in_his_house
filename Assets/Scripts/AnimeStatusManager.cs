using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeStatusManager : MonoBehaviour
{

    public AnimeStatus animeStatus;
    // Start is called before the first frame update
    void Awake()
    {
        animeStatus = new AnimeStatus();
        animeStatus = AnimeStatus.walkanddraw;
    }
}
