using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil: MonoBehaviour
{
    public float Speed = 2f;
    GameObject target;
    Quebravel qb;

    private void Awake()
    {
        qb = FindObjectOfType<Quebravel>();
        target = GameObject.FindGameObjectWithTag("Target");
    }

    private void Start()
    {
        transform.rotation = target.transform.rotation; 
        Vector3 dir = target.transform.position - transform.position;
        GetComponent<Rigidbody>().velocity = dir * Speed;
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Quebravel"))
        {
            qb.resistencia -= 1;
            Debug.Log(other.name);
            Debug.Log(qb.resistencia);
            Destroy(gameObject);
        }
    }
}
