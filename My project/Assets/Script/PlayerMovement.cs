using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float coyoteTime = 0.18f;
    private float coyoteTimeCounter;
    private float dirX = 0f;
    private enum MovementState { idle , running , jumping , falling };
    [SerializeField] private AudioSource JumpSoundEffect;
    [SerializeField] private float moveSpeed = 7f;
    private float jumpForce = 12f;
    [SerializeField] private LayerMask jumpableGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (IsGrounded()){
            coyoteTimeCounter = coyoteTime;
        }
        else{
            coyoteTimeCounter -= Time.deltaTime;
        }
        if ((CrossPlatformInputManager.GetButtonDown("Jump")) && coyoteTimeCounter > 0f){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            JumpSoundEffect.Play();
        }
        if ((CrossPlatformInputManager.GetButtonUp("Jump")) && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
        UpdateAnimationUpdate();
    }
    private void UpdateAnimationUpdate(){
        MovementState state;
        if (dirX > 0f)
        {
            state= MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        { 
            state= MovementState.running;
            sprite.flipX = true;
        } 
        else
        {
            state= MovementState.idle;
        }
        if(rb.velocity.y > .1f){
            state= MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f){
            state= MovementState.falling;
        }
        
        anim.SetInteger("state", (int)state);
    }
    public void StopMovement(){
        moveSpeed= 0f;
        jumpForce= 0f;
    }
    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
