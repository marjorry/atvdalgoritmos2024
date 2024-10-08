using System;
using Vector3 = UnityEngine.Vector3;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;
    private bool noChao;
    
    private Rigidbody rb;
    private AudioSource Source;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("star");
        TryGetComponent(out rb);
        TryGetComponent(out Source);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!noChao &&  collision.gameObject.tag == "Chão")
        {
            noChao = true;
        } 
            
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UPDATE");
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(x,0,y);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
           Source.Play();
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
        
        

        if (transform.position.y <= -10)
        {
            //jogador caiu
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}






