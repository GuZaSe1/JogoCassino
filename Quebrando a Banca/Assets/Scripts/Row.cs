using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class Row : MonoBehaviour
{
    private int randomValue; //valor da roleta
    private float timeInterval; // tempo pra trocar entre um item e outro

    public bool rowStopped; //verificar de o slot(row) parou
    public string stoppedSlot; //armazena o nome da imagem que parou na tela

    private const float MARGEM = 0.33f; //tira a mergem de erro do float (0.000000)

    void Start()
    {
        rowStopped = true;
        GameControl.HandlePulled += StartRotating; 
    }
    private void StartRotating()
    {
        stoppedSlot = " ";
        StartCoroutine("Rotate");
        
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.001f;
        randomValue = Random.Range(60,100);
                
        for(int i=0; i<randomValue; i++)
        {
            if(transform.position.y <= -3.8f)
            {
                transform.position = new UnityEngine.Vector2(transform.position.x, 3.9f);
            }
            transform.position = new UnityEngine.Vector2(transform.position.x, transform.position.y -1.3f);
            if (i > Mathf.RoundToInt(randomValue * 0.25f)) timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randomValue * 0.5f)) timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f)) timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f)) timeInterval = 0.2f;
            yield return new WaitForSeconds(timeInterval);
        }   
        var y = transform.position.y;

        if (y >= -3.8f - MARGEM && y < -3.8f + MARGEM) GameControl.Instance.qt7++; // 7
        if (y >= -2.54f - MARGEM && y < -2.54f + MARGEM) GameControl.Instance.qtBar++; // Bar
        if (y >= -1.24f - MARGEM && y < -1.24f + MARGEM) GameControl.Instance.qtSino++; // Sino
        if (y >= 0.07f - MARGEM && y < 0.07f + MARGEM) GameControl.Instance.qtCereja++; //Cereja 
        if (y >= 1.33f - MARGEM && y < 1.33f + MARGEM) GameControl.Instance.qtUva++; // Uva
        if (y >= 2.6f - MARGEM && y < 2.6f + MARGEM) GameControl.Instance.qtLimao++; // Limao
        if (y >= 3.9f - MARGEM && y < 3.9f + MARGEM) GameControl.Instance.qtMelancia++; // Melancia

        rowStopped = true;
    }

    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }

}
