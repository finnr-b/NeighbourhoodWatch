using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public Gun gun;

    public float fireRate = 0.1f;
    private float nextFireTime = 0f;

    Vector2 moveDirection;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // Movement and Gun Position
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveInput.x, moveInput.y).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            gun.Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    // This is where the fun begins
    private void FixedUpdate()
    {
        rb2d.velocity = moveInput * moveSpeed;
        Vector2 aimDirection = mousePosition - (Vector2) rb2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = aimAngle;
    }
}