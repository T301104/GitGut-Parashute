using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private InputAction playerMoveAction;
    private bool moveingWithMouse = false;
    private float mouseX;
    private Rigidbody2D rb;
    private float mouseDeadZone = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerMoveAction = InputSystem.actions.FindAction("Move");
    }

    void FixedUpdate()
    {
        //do the math for the mouse ahead of time, correcting for it taking the entire UI screen size instead of the camera screen size
        mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		//Input.mousePosition.x / 107;
		Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if the mouse is moved use the mouse inputs, otherwise use the keyboard/controller inputs and ignore the mouse potition
        if (Input.mousePositionDelta.x > 0 || Input.mousePositionDelta.x < 0)
        {
            moveingWithMouse = true;
        }
        else if (playerMoveAction.ReadValue<Vector2>().x != 0)
        {
            moveingWithMouse = false;
            //use the input system to move the player left to right
            Vector2 playerMovement = new Vector2(playerMoveAction.ReadValue<Vector2>().x, 0) * speed;
            rb.AddForce(playerMovement);
        }

        //move towards the mouse
        if (moveingWithMouse && ((mouseX - transform.position.x) > mouseDeadZone || (mouseX - transform.position.x) < -mouseDeadZone))
        {
            if (mouseX < transform.position.x)
            {
                rb.AddForce(new(-1 * speed, 0));
            }
            else if (mouseX > transform.position.x)
            {
                rb.AddForce(new(speed, 0));
            }
        }
    }
}
