using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneScript: MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeedAgain = 5f;
    public float jumpForce = 7f;
    private Vector3 cubeDirection;
    private Rigidbody rb;

    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 10f;

    public Animator Anim;

    private void Awake() //Starts as soon as the game runs
        //Start starts on the first fram
    {
        rb = GetComponent<Rigidbody>(); // Ensure cube has a Rigidbody component
        Anim = GetComponent<Animator>();
    }

    public void MovePlayerOne(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector2 playerInput = ctx.ReadValue<Vector2>();
            cubeDirection.x = playerInput.x;
            cubeDirection.z = playerInput.y;
        }
        else if (ctx.canceled)
        {
            cubeDirection = Vector3.zero;
        }
    }

    public void JumpPlayerOne(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Anim.SetTrigger("Jump");
        }
    }

    public void ShootPlayerOne(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            Rigidbody projRb = projectile.GetComponent<Rigidbody>();
            projRb.linearVelocity = transform.forward * projectileSpeed;

            Destroy(projectile, 3f);
        }
    }

    private void Update()
    {
        Vector3 movement = new Vector3(cubeDirection.x, 0, cubeDirection.z) * moveSpeedAgain * Time.deltaTime;
        transform.Translate(movement);
    }

}
