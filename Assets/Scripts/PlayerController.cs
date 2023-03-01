using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform playerCamera = null;

    [SerializeField]
    private float mouseSensitivity = 3.5f;
    
    [SerializeField]
    float walkSpeed = 60f;

    [SerializeField]
    private float distToGround = 0.0f;

    [SerializeField]
    private bool lockCursor = true;

    private float cameraPitch = 0.0f;

    private float horizontalMovement;
    private float verticalMovement;
    Vector3 moveDirection;
    public float footDistance;
    [SerializeField]
    private bool canJump = true;
    public float jumpForce;
    public GameObject winText;

    Rigidbody rb;   
    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }   
    rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
        CheckGrounded();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Launch")
        {
            rb.AddForce(Vector3.up * 50, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            winText.gameObject.SetActive(true);
        }
    }
    void CheckGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, footDistance))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
    void UpdateMouseLook()
    {
        Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.Rotate(Vector3.up * mouseMovement.x * mouseSensitivity);

        cameraPitch -= mouseMovement.y * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
    }

    void UpdateMovement()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        moveDirection.Normalize();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection * walkSpeed, ForceMode.Acceleration);

        if (Input.GetKey("space") && canJump)
        {
            // Debug.Log("Jump!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
