using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the players movement from moving left and right to jumping (and also the animations, that accompany this). I have made it
/// so that the player can double jump. I have also included a reset player stats method so that the stats can be reset (this is accessed and used
/// in the player death script).
/// </summary>
public class Character2DController : MonoBehaviour
{
    [SerializeField] private LayerMask groundPlatformLayerMask;
    public float MovementSpeed = 3.5f;
    public float SingleJumpForce = 4f;
    public float DoubleJumpForce = 5f;
    public Transform TransformPlayer;

    private int JumpCount = 0;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public Animator animator;
    public TextMeshProUGUI PowerupText;

    private void Update()
    {
        // Returns to level select if the player presses escape.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level_Select");
        }


        // Get the player sideways movement (by default this is controlled using A and D, or the left and right arrow key). 
        var HorizontalMovement = Input.GetAxis("Horizontal");
        // Player is moving to the left.
        if (HorizontalMovement < 0) {
            // Play the running animation.
            animator.SetBool("IsMoving", true);
            Vector3 playerLocalScale = TransformPlayer.localScale;
            // Flip the player to face the left if they were previous facing right.
            if (playerLocalScale.x > 0)
            {
                playerLocalScale.x *= -1;
                TransformPlayer.localScale = playerLocalScale;
            }
        }
        // Player is moving to the right.
        else if (HorizontalMovement > 0)
        {
            // Play the running animation.
            animator.SetBool("IsMoving", true);
            Vector3 playerLocalScale = TransformPlayer.localScale;
            // Flip the player to face the right if they were previous facing left.
            if (playerLocalScale.x < 0)
            {
                playerLocalScale.x *= -1;
                TransformPlayer.localScale = playerLocalScale;
            }
        }
        // Player is not moving so play idle animation. 
        else
        {
            animator.SetBool("IsMoving", false);
        }

        // Move player along x axis.
        transform.position += new Vector3(HorizontalMovement, 0f, 0f) * Time.deltaTime * MovementSpeed;

        // Detects if the player is trying to jump (by default this is done using the space bar).
        if (Input.GetButtonDown("Jump"))
        {
            // Jump if touching ground
            if (TouchingGround()) {
                // Add upwards force specified by the SingleJumpForce variable
                rb.AddForce(Vector2.up * SingleJumpForce, ForceMode2D.Impulse);
                JumpCount = 1;
                animator.SetBool("IsJumping", true);
            }
            // Jump if there has been one previous jump since touching the ground. 
            else if(JumpCount < 2)
            {
                // Only play jump animation on second jump of double jump.
                animator.SetBool("IsJumping", true);
                // Add upwards force specified by the DoubleJumpForce variable
                rb.AddForce(Vector2.up * DoubleJumpForce, ForceMode2D.Impulse);
                JumpCount += 1;
            }
        }

        // Stop playing jumping animation if touching the ground.
        if (TouchingGround())
        {
            animator.SetBool("IsJumping", false);
        }

    }


    private bool TouchingGround()
    {   
        // Use raycast to detect if touching the ground. Note raycast direction is depends on if gravity has been inverted. 
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, rb.gravityScale>0 ? Vector2.down : Vector2.up, 0.1f, groundPlatformLayerMask);
        return raycastHit2D.collider != null;
    }

    /// <summary>
    /// Resets the player stats (used by the PlayerDeath script to ensure all powerups are deactivated). 
    /// </summary>
    public void ResetPlayerStats()
    {
        MovementSpeed = 3.5f;
        SingleJumpForce = 4f;
        DoubleJumpForce = 5f;
        JumpCount = 0;
        TransformPlayer.localScale = new Vector3(6f, 6f, 6f);
        PowerupText.text = "Powerup: none";
    }
}
