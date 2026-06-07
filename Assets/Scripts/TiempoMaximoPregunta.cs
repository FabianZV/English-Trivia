using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class TiempoMaximoPregunta : MonoBehaviour
    {
        public float TiempoRestantePregunta = 20; // Tiempo restante para la pregunta
        public GameObject pnl_InformacionComplementaria; // Panel de información complementaria
        public Text txt_TiempoPregunta; // Texto de la UI para mostrar el tiempo
        private bool PausaTiempo = false; // Estado de pausa
        private bool tiempoRestablecido = false; // Estado para verificar si el tiempo ya fue restablecido

        void Update()
        {
            // Verifica si el panel está activo para pausar o reanudar
            PausaTiempo = pnl_InformacionComplementaria.activeSelf;

            // Si está en pausa
            if (PausaTiempo)
            {
                // Resetea el indicador de tiempo restablecido cuando se activa la pausa
                tiempoRestablecido = false;
            }
            // Si no está en pausa y hay tiempo restante
            else if (TiempoRestantePregunta > 0)
            {
                // Si se desactiva el panel, restablece el contador a 20 solo una vez
                if (!pnl_InformacionComplementaria.activeSelf && !tiempoRestablecido)
                {
                    TiempoRestantePregunta = 20; // Restablecer el tiempo a 20 segundos
                    tiempoRestablecido = true; // Marca que el tiempo ha sido restablecido
                }

                // Descuenta el tiempo en segundos reales
                TiempoRestantePregunta -= Time.deltaTime;
                txt_TiempoPregunta.text = "Time Left: " + Mathf.Ceil(TiempoRestantePregunta).ToString() + " Seconds";

                // Si el tiempo llega a 0, cambiar a la escena "Perder"
                if (TiempoRestantePregunta <= 0)
                {
                    TiempoRestantePregunta = 0;
                    Debug.Log("Tiempo para responder agotado!");
                    SceneManager.LoadScene("Perder");
                }
            }

            // Actualizar el texto del contador en la UI
            txt_TiempoPregunta.text = "Time Left: " + Mathf.Ceil(TiempoRestantePregunta).ToString() + " Seconds";
        }
    }
}