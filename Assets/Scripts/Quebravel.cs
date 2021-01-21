using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quebravel : MonoBehaviour
{
    public int resistencia;
    AudioSource collisionSound;

    private void Start()
    {
        collisionSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(resistencia <= 0)
        {
            Destroy(gameObject, .3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projetil"))
        {
            collisionSound.Play();
        }
    }
}
