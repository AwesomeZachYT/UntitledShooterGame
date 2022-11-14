using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreation : MonoBehaviour
{
    public GameObject[] spawnAreas;
    public GameObject enemy;

    public float totalTime;
    public int hover;
    float cooldown;
    float time;

    bool called;

    void Start()
    {
        time = totalTime;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (Mathf.Ceil(time) == 0 && !called)
        {
            called = true;

            foreach (GameObject pos in spawnAreas)
            {
               GameObject obj = Instantiate(enemy, pos.transform.position, pos.transform.rotation);
                obj.GetComponent<enemyBehaviour>().drag = false;
                obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                obj.GetComponent<Rigidbody2D>().simulated = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            hover--;
            cooldown--;
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            for (int i = 0; i < Random.Range(1, 6); i++) { Instantiate(enemy); }

            hover = 2;
            cooldown = 2;
            called = false;
            time = totalTime;
        }
    }
}
