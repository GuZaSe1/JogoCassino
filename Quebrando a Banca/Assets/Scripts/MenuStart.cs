using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
    [SerializeField] private GameObject startObj;
    void Start()
    {
        Time.timeScale = 0; //para o jogo começar parado
        startObj.SetActive(true);
    }

   public void StartButton()
   {
        Time.timeScale = 1;
        startObj.SetActive(false);
   }
}