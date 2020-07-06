using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextColor : MonoBehaviour
{
    MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material.color = mr.material.color - new Color32(0, 0, 0, 50);
    }
}