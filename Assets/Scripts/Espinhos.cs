using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Espinhos : MonoBehaviour
    {
        public Transform chaoEsq;
        public Transform chaoDir;
        Armadilhas armadilha;
        bool aberto;
        bool tocando = false;
        float time = 0;
        int x = 0;

        private void Start()
        {
            armadilha = GetComponent<Armadilhas>();
            Invoke("Abrir", 3);
        }
        private void Update()
        {
            if (tocando && aberto)
            {
                if (time > 0)
                {
                    if ((x % 180) == 0)
                    {
                        armadilha.Dano();
                    }
                }
                time += Time.deltaTime;
                x += 1;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                tocando = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                tocando = false;
                time = 0;
                x = 0;
            }
        }

        void Abrir()
        {
            aberto = true;
            chaoEsq.localPosition = new Vector3(10, 4, 0);
            chaoEsq.localRotation = Quaternion.Euler(180, -90, -90);
            chaoDir.localPosition = new Vector3(-10, 4, 0);
            chaoDir.localRotation = Quaternion.Euler(180, -90, -90);
            Invoke("Fechar", 7);
        }

        void Fechar()
        {
            aberto = false;
            chaoEsq.localPosition = new Vector3(5, 0, 0);
            chaoEsq.localRotation = Quaternion.Euler(90, 0, 0);
            chaoDir.localPosition = new Vector3(-5, 0, 0);
            chaoDir.localRotation = Quaternion.Euler(90, 0, 0);
            Invoke("Abrir", 3.5f);
        }
    }
}