using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D playerRigidbody2D; //RIGIDBODY
    private Animator    playerAnimator;
    public float        playerSpeed; //VELOCIDADE DA MOVIMENTAÇÃO
    private float       playerInitialSpeed; //guardar a velocudade padrao
    public float        playerRunSpeed; //velocidade correndo
    private Vector2     playerDirection; //EIXO EM QUE SE LOCOMOVE
    
    public static float money = 200f;

    private bool isAttack = false; //ataque normal
    private bool isAttackSpecial = false; //ateque especial
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>(); //PARA ASSOCIAR AS INFORMAÇÕES DO RIGIDBODY DA UNITY PARA O CODIGO
        playerAnimator = GetComponent<Animator>();

        playerInitialSpeed = playerSpeed;
    }

    
    void Update()
    {
        playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), (Input.GetAxisRaw("Vertical"))); //declarando assim, nao preciso declarar as teclas, pois ja esta configurado no input manager
        
        if(playerDirection.sqrMagnitude > 0) //p calcular distancias ou proximidades
        {
            playerAnimator.SetInteger("Movimento", 1); //transiçao da animaçao para correr
        }
        else
        {
            playerAnimator.SetInteger("Movimento", 0);
        }

        Flip();

        PlayerRun();

        OnAttack();

        if(isAttack) //verdadeira
        {
            playerAnimator.SetInteger("Movimento", 2);
        }

        OnAttackSpecial();
        
        if(isAttackSpecial) //verdadeira
        {
            playerAnimator.SetInteger("Movimento", 3);
        }
    }

    void FixedUpdate() //movimentaçao no fixed pq a movimentação nao vai variar
    {
        playerRigidbody2D.MovePosition(playerRigidbody2D.position + playerDirection.normalized * playerSpeed * Time.fixedDeltaTime);
    }

        void Flip() //para inverter o lado quando andar para a esquerda
    {
        if(playerDirection.x > 0) //aqui continua normal, pois esta andando para a direita
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (playerDirection.x < 0) //aqui inverte em 180g para q o boneco fique para a esquerda
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

    }

    void PlayerRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed = playerRunSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed = playerInitialSpeed;
        }
    }

    void OnAttack() // funçao ataque normal
    {
        if(Input.GetMouseButtonDown(0))
        {
            isAttack = true;
            playerSpeed = 0;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isAttack = false;
            playerSpeed = playerInitialSpeed;
        }
    }
     void OnAttackSpecial() // funçao ataque especial
    {
        if(Input.GetMouseButtonDown(1))
        {
            isAttackSpecial = true;
            playerSpeed = 0;
        }
        if(Input.GetMouseButtonUp(1))
        {
            isAttackSpecial = false;
            playerSpeed = playerInitialSpeed;
        }
    }

    public static void ChangeMoney(float amount)
    {
        money += amount;


        UIHandler.Instance.MoneyText.text = "$" + money.ToString("000000000");
        // Fazer a logica para atualizar a tela
    }






}
