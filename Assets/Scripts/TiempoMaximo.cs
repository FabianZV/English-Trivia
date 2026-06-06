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
     public class TiempoMaximo : MonoBehaviour
    {
        private float TiempoRestante = 360f; // 6 minutos de tiempo
        public Text txt_Tiempo; // Referencia al objeto de texto en la UI

        void Update()
        {
                TiempoRestante -= Time.deltaTime; // Descuenta el tiempo en segundos reales

                // Actualizar el texto del contador en la UI
                txt_Tiempo.text = "Tiempo máximo: " + Mathf.Ceil(TiempoRestante).ToString() + " segundos";

                // Si el tiempo llega a 0, cambiar a la escena "Perder"
                if (TiempoRestante <= 0)
                {
                    TiempoRestante = 0;
                    Debug.Log("Tiempo máximo agotado!");
                    SceneManager.LoadScene("PantallaPrincipal");
                }
            
        }
    }
}

