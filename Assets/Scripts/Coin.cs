using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {  
        if(other.gameObject.CompareTag("Player"))
        {
            gameManager.IncrementScore();
            Destroy(gameObject);
        }
        
    }
}
