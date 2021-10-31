﻿using UnityEngine;

public class Character2DController : MonoBehaviour
{
    [SerializeField] private LayerMask groundPlatformLayerMask;
    public float MovementSpeed;
    public Rigidbody2D rb;
    public float SingleJumpForce = 3.5f;
    public float DoubleJumpForce = 5f;
    public BoxCollider2D bc;
    private int JumpCount = 0;
    public Transform TransformPlayer; 



    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("Touching Ground: " + TouchingGround());
        var HorizontalMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(HorizontalMovement, 0f, 0f) * Time.deltaTime * MovementSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            
            if (TouchingGround()) {
                Debug.Log("jump count: " + JumpCount);
                rb.AddForce(Vector2.up * SingleJumpForce, ForceMode2D.Impulse);
                JumpCount = 1;
            }
            else if(JumpCount < 2)
            {
                Debug.Log("jump count: " + JumpCount);
                rb.AddForce(Vector2.up * DoubleJumpForce, ForceMode2D.Impulse);
                JumpCount += 1;
            }
        }
    }

    private bool TouchingGround()
    {
/*        Debug.Log("box collider: " + bc);
        Debug.Log("rigid body: " + rb);*/
        
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, groundPlatformLayerMask);
        Debug.Log("raycastHit2D.collider: " + raycastHit2D.collider); 
        return raycastHit2D.collider != null;


    }
}