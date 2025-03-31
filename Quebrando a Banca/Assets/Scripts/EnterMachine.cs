using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMachine : MonoBehaviour
{
    public static bool inAMachine = false;
    public void Play1()
    {
        if(inAMachine) return;
        SceneManager.LoadScene("Maquina1", LoadSceneMode.Additive); //carregar "Maquina1"    //additive abre uma cena e nao fecha as outras 
    }

    public void Play2()
    {
        if(inAMachine) return;
        SceneManager.LoadScene("Maquina2", LoadSceneMode.Additive); //carregar "Maquina2"
    }

    public void Play3()
    {
        if(inAMachine) return;
        SceneManager.LoadScene("Maquina3", LoadSceneMode.Additive); //carregar "Maquina3"
    }

    public void Play4()
    {
        if(inAMachine) return;
        SceneManager.LoadScene("Maquina4", LoadSceneMode.Additive); //carregar "Maquina4"
    }

    public void Play5()
    {
        if(inAMachine) return;
        SceneManager.LoadScene("Maquina5", LoadSceneMode.Additive); //carregar "Maquina5"
    }

        public void Play6()
    {
        if(inAMachine) return;
        SceneManager.LoadScene("Maquina6", LoadSceneMode.Additive); //carregar "Maquina6"
    }


}
 