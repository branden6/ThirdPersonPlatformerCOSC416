using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField]private float speed = 5.0f;
    [SerializeField]private float jumpHeight = 5.0f;
    [SerializeField]private InputManager inputManager;
    [SerializeField] Transform camera;
    private bool isGrounded;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(OnJump);
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void MovePlayer(Vector2 inputDirection){
        Vector3 cameraForward = camera.forward;
        Vector3 cameraRight = camera.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();


        Vector3 moveDirection = (cameraForward * inputDirection.y + cameraRight * inputDirection.x).normalized;
        playerRb.linearVelocity = new Vector3(moveDirection.x * speed, playerRb.linearVelocity.y, moveDirection.z * speed);
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
