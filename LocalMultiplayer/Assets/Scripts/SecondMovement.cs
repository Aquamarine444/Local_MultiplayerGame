using UnityEngine;
using UnityEngine.InputSystem;

public class SecondMovement: MonoBehaviour
{
    public float moveSpeedAgain = 5;
    private Vector2 cubeDirection;
    public void MoveTheCube(InputAction.CallbackContext ctx)
    {
        if (ctx.performed == true)
        {
            Vector2 playerInput = ctx.ReadValue<Vector2>();
            cubeDirection.x = playerInput.x; //left and right movement
            cubeDirection.y = playerInput.y; //up and down movement
        }
        else
        {
            cubeDirection = Vector2.zero;
        }
    }
    public void Update()
    {
        Vector2 movement = new Vector2(cubeDirection.x, cubeDirection.y) * moveSpeedAgain *
        Time.deltaTime;
        transform.Translate(movement);
    }
}
