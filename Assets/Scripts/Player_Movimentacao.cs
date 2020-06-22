using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movimentacao : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D playerRb;

    public Vector3 vt3LimiteMovimentacao;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        ConfigurarQualidade();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        playerRb.velocity = new Vector2(moveHorizontal * _GameController.velocidadeMovimento, moveVertical * _GameController.velocidadeMovimento);
        LimitarMovimento(transform.position.x, transform.position.y);
    }
    
    private void LimitarMovimento(float posicaoX, float posicaoY)
    {
        vt3LimiteMovimentacao = new Vector3(Mathf.Clamp(posicaoX, _GameController.limiteXMin, _GameController.limiteXMax),
                                        Mathf.Clamp(posicaoY, _GameController.limiteYMin, _GameController.limiteYMax), 0);
        transform.position = vt3LimiteMovimentacao;
    }

    private void ConfigurarQualidade()
    {
        QualitySettings.vSyncCount = 1;
    }
}
