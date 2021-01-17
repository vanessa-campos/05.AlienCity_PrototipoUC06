using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Esmaga : MonoBehaviour
    {
        public Transform paredeEsq;
        public Transform paredeDir;
        Armadilhas armadilha;

        private void Start()
        {
            armadilha = GetComponent<Armadilhas>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                paredeEsq.Translate(5, 0, 0);
                paredeDir.Translate(5, 0, 0);
                armadilha.Dano();
                Invoke("Retornar", 1.5f);
            }
        }

        void Retornar()
        {            
            paredeEsq.Translate(-5, 0, 0);
            paredeDir.Translate(-5, 0, 0);
        }

    }
}