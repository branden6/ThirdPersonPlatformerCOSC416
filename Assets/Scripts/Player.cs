using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField]private float speed = 5.0f;
    [SerializeField]private float jumpHeight = 5.0f;
    [SerializeField]private InputManager inputManager;
    private bool isGrounded;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(OnJump);
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void MovePlayer(Vector2 direction){
        Vector3 moveDirection = new(direction.x, 0f, direction.y);
        playerRb.AddForce(moveDirection * speed);
    }
    private void OnJump(){
        if(isGrounded){
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }
        else
            return;
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
}
