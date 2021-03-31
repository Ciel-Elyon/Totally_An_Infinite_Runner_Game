using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour {

    public PlayerController m_root;
    public RunnerMovingScripts r_root;

    // Use this for initialization
    void Start()
    {
        m_root = this.transform.root.GetComponent<PlayerController>();
        
        r_root = this.transform.root.GetComponent<RunnerMovingScripts>();
       
    }

 

    ContactPoint2D[] contacts = new ContactPoint2D[1];

    void OnTriggerStay2D(Collider2D other)
    {
    

        if (other.CompareTag("Ground") || other.CompareTag("Block"))
        {
            if(m_root.isActiveAndEnabled)
            {
                if (other.CompareTag("Ground"))
                {
                    m_root.Is_DownJump_GroundCheck = true;

                }
                else
                {
                    m_root.Is_DownJump_GroundCheck = false;
                }
            }

            
            if(m_root.isActiveAndEnabled)
            {
                if (m_root.m_rigidbody.velocity.y <= 0)
                {

                    m_root.isGrounded = true;
                    m_root.currentJumpCount = 0;
                }
            }
            else
            {
                if(r_root.rb.velocity.y <= 0)
                {
                    r_root.isGrounded = true;
                    r_root.currentJumpCount = 0;
                }
            }
            
         
        
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (m_root.isActiveAndEnabled)
            m_root.isGrounded = false;
        else
            r_root.isGrounded = true;
     
    }



}
