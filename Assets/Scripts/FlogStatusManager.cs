using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlogStatusManager : MonoBehaviour
{

    public FlogStatus flogStatus;
    // Start is called before the first frame update
    void Awake()
    {
        flogStatus = new FlogStatus();
        flogStatus = FlogStatus.f0;
    }
}
