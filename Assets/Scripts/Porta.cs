using System.Collections;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public int chaves;
    public GameManager GM;

    private void Start()
    {
        chaves = GameObject.FindGameObjectsWithTag("Chave").Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (chaves <= 0)
            {
                PlayerPrefs.SetInt("PPAberto", 1);
                gameObject.SetActive(false);
                GM.Invoke("Fim", 3);
            }
        }
    }
}
