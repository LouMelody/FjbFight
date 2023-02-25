using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    public float jumpSpeed = 3f;
    public AnimCon animCon;

    private Rigidbody2D rbody;
    private bool isJump = false;
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(nameof(Jump));
            if(!isJump)
                animCon.PlayJump();
        }
        if (Input.GetKeyDown(KeyCode.L))
            animCon.PlayPunch();
        if (Input.GetKeyDown(KeyCode.I))
            animCon.PlayUpper();
        if (Input.GetKeyDown(KeyCode.K))
            animCon.PlayBodyBlow();
    }
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        if(!isJump) animCon.ChangeDirection(inputVector.magnitude);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        if(!isJump) rbody.MovePosition(newPos);
    }

    private IEnumerator Jump()
    {
        if (isJump) yield break;

        yield return null;

        isJump = true;
        float elapsed = 0f;
        while (true)
        {
            if (elapsed <= 0.5f)
            {
                //var posY = transform.position.y;
                //var newPos = new Vector2(transform.position.x, posY + Abs(posY * jumpSpeed * Time.deltaTime));
                //rbody.MovePosition(newPos);
                elapsed += Time.deltaTime;
            }
            else if (elapsed <= 1f)
            {
                // var posY = transform.position.y;
                // var newPos = new Vector2(transform.position.x,  posY + -Abs(posY * -jumpSpeed * Time.deltaTime));
                // rbody.MovePosition(newPos);
                elapsed += Time.deltaTime;
            }
            else
            {
                isJump = false;
                yield break;
            }
            yield return null;
        }
    }
}
