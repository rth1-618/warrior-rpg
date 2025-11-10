using UnityEngine;

public class Player : MonoBehaviour
{
    private float xInput;
    private float yInput;
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 3.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");


        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q is being pressed");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P is pressed");
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            Debug.Log("V is released");
        }

    }
}
