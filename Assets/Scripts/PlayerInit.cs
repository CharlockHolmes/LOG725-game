using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(0, 0, 0);

    void Start()
    {
        transform.position = startPosition;
    }
}
