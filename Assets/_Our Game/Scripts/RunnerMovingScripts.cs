using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class RunnerMovingScripts : MonoBehaviour
{
    public Animator _mAnim;
    public Rigidbody2D rb;

    [Header("[Setting]")]
    public float MoveSpeed = 6;
    public int JumpCount = 2;
    public float jumpForce = 15f;

    public int currentJumpCount = 0;
    public bool isGrounded = false;

    //public GameObject BloodPrefab;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        _mAnim.Play("Demo_Idle");
    }

    protected void prefromJump()
    {
        
        _mAnim.Play("Demo_Jump");

        rb.velocity = new Vector2(0, 0);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        currentJumpCount++;

        isGrounded = false;
       

    }

    void Flip(bool bLeft)
    {

        transform.localScale = new Vector3(bLeft ? 1 : -1, 1, 1);

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _mAnim = this.transform.Find("model").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Flip(false);
        transform.transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        _mAnim.Play("Demo_Run");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentJumpCount < JumpCount)
                prefromJump();
        }
       
    }

    
}
