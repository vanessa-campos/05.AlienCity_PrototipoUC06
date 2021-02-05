using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Esmaga : Armadilhas
    {
        public Transform paredeEsq;
        public Transform paredeDir;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                paredeEsq.Translate(5, 0, 0);
                paredeDir.Translate(5, 0, 0);
                Dano();
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