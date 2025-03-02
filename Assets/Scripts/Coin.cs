using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            Destroy(gameObject);
        }
        
    }
}
