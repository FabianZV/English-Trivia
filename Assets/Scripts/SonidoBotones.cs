using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class SonidoBotones : MonoBehaviour
    {
        // Referencia al AudioSource
        public AudioSource audioSource;

        // Esta función se asignará al botón
        public void PlaySound()
        {
            audioSource.Play();
        }

    }
}
