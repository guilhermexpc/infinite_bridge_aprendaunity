using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePonte : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D ponteRb;

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        ponteRb = GetComponent<Rigidbody2D>();
        ponteRb.velocity = new Vector3(_GameController.velocidadePonte, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _GameController.objetoDistanciaDestruir)
        {
            Destroy(this.gameObject);
        }
    }
}
