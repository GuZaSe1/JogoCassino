using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMachine : MonoBehaviour
{
    [SerializeField] private string nomeCena;

    void Awake()
    {
        // Debug.Log(SceneManager.GetActiveScene().name);
        EnterMachine.inAMachine = true;
    }


    /// <summary>
    /// Esta funcao mata a cena aberta da maquina
    /// </summary>
    public void CloseMachine1()
    {
        SceneManager.UnloadSceneAsync("Maquina1"); //fecha a Maquina1
        EnterMachine.inAMachine = false;
    }

    public void CloseMachine2()
    {
        SceneManager.UnloadSceneAsync("Maquina2"); //fecha a Maquina2
        EnterMachine.inAMachine = false;
    }

    public void CloseMachine3()
    {
        SceneManager.UnloadSceneAsync("Maquina3"); //fecha a Maquina2
        EnterMachine.inAMachine = false;
    }

    public void CloseMachine4()
    {
        SceneManager.UnloadSceneAsync("Maquina4"); //fecha a Maquina2
        EnterMachine.inAMachine = false;
    }

    public void CloseMachine5()
    {
        SceneManager.UnloadSceneAsync("Maquina5"); //fecha a Maquina2
        EnterMachine.inAMachine = false;
    }

    public void CloseMachine6()
    {
        SceneManager.UnloadSceneAsync("Maquina6"); //fecha a Maquina2
        EnterMachine.inAMachine = false;
    }
}
