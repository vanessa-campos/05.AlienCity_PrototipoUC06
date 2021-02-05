using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Espinhos : Armadilhas
    {
        public Transform chaoEsq;
        public Transform chaoDir;
        bool aberto;
        float time = 0;
        int x = 0;

        private void Start()
        {
            Invoke("Abrir", 3);
        }
        
        private void Update()
        {
            if (ativada && aberto)
            {
                if (time > 0)
                {
                    if ((x % 180) == 0)
                    {
                        Dano();
                    }
                }
                time += Time.deltaTime;
                x += 1;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ativada = false;
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