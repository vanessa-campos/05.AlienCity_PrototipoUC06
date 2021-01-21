using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma: MonoBehaviour
{
    public Transform cano;
    public GameObject Prefab;
    public AudioSource shootSound;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Prefab, cano.position, Quaternion.identity);
            shootSound.Play();
        }
    }
}
