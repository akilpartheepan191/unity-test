using UnityEngine;

public class playermovement : MonoBehaviour
{   
    public CharacterController con;
    public float speed = 12;
    public float gravity_num = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight;

    bool isGrounded;
    Vector3 velocity;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded=Physics.CheckSphere(groundCheck.position , groundDistance, groundMask);
        if (isGrounded && velocity.y >0)
        {
            velocity.y = -2f;
        }
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        con.Move(move * speed * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity_num);

        }

        velocity.y += gravity_num * Time.deltaTime;
        con.Move(velocity * Time.deltaTime);

    }
}
