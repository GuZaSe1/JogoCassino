using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance;

    private void Start()
    {
        if(Instance) Destroy(gameObject);

        Instance = this;
        PlayerController.ChangeMoney(0);
    }

    public TMP_Text MoneyText;
}
