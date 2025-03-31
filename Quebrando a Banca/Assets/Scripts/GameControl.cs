using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;

    public static event Action HandlePulled = delegate { };

    private Collider2D _c2D;

    [SerializeField]
    private Text prizeText; // texto da recompensa

    [SerializeField]
    private Row[] rows; // representa a classe rows linha (slot)

    [SerializeField]
    private Transform handle; // cabo da maquina

    private int prizeValue; // valores dos premios

    private bool resultsChecked; // verifica se os slots pararam

    //Variaveis do jogo
    public int qt7 = 0;
    public int qtBar = 0;
    public int qtSino = 0;
    public int qtCereja = 0;
    public int qtUva= 0;
    public int qtLimao = 0;
    public int qtMelancia = 0;

    public float priceToPlay;

    void Start()
    {
        resultsChecked = false;
        
        _c2D = GetComponent<Collider2D>();

        if(Instance) Destroy(Instance.gameObject);

        Instance = this;
    }

    void Update()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped) // alavanca funciona caso os rows estejam parados
        {
            if(PlayerController.money >= priceToPlay)
            {
                PlayerController.ChangeMoney(-priceToPlay);
                if(Input.GetKeyDown(KeyCode.Space)) 
                StartCoroutine ("PullHandle");
            }
            
            
        }

        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !resultsChecked)
        {
            CheckResults();
            prizeText.enabled = true;
            prizeText.text = "Prize: " + prizeValue.ToString();
        }
    }

    private IEnumerator PullHandle()
    {
        ClearQt();
        //animacao da alavanca
        for (int i = 0; i < 15; i+=5)
        {
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }

        HandlePulled();

        //animacao da alavanca voltar
        for (int i = 0; i < 15; i+=5)
        {
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }


    private void ClearQt()
    {
        qt7 = 0;
        qtBar = 0;
        qtSino = 0;
        qtCereja = 0;
        qtUva= 0;
        qtLimao = 0;
        qtMelancia = 0;

        prizeValue = 0;
        resultsChecked = false;
    }

    private void CheckResults()
    {
        if(qt7 == 2) prizeValue += 50;
        if(qt7 == 3) prizeValue += 100;

        if(qtBar == 2) prizeValue += 500;
        if(qtBar == 3) prizeValue += 1000;
        
        if(qtSino == 2) prizeValue += 20;
        if(qtSino == 3) prizeValue += 40;
    
        if(qtCereja == 2) prizeValue += 100;
        if(qtCereja == 3) prizeValue += 200;
        
        if(qtUva == 2) prizeValue += 50;
        if(qtUva == 3) prizeValue += 100;

        if(qtLimao == 2) prizeValue += 100;
        if(qtLimao == 3) prizeValue += 200;

        if(qtMelancia == 2) prizeValue += 600;
        if(qtMelancia == 3) prizeValue += 1200;

        PlayerController.ChangeMoney(prizeValue);

        resultsChecked = true;
    }

}