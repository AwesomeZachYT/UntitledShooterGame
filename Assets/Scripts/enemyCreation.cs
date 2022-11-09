using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreation : MonoBehaviour
{
    public GameObject enemy;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) { Instantiate(enemy); }
    }
}
