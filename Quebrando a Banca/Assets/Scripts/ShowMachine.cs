using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMachine : MonoBehaviour
{
    [SerializeField] private GameObject UIMachine;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<PlayerController>()){
            Show(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.GetComponent<PlayerController>()){
            Show(false);
        }
    }

    private void Show(bool state)
    {
        UIMachine.SetActive(state);
    }
}