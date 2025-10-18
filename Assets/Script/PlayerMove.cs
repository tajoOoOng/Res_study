using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows;
public class PlayerMOve:MonoBehaviour
{   
    public float speed = 5f;
    public float jumpForce = 10.0f;
    Rigidbody2D Rigid;
    bool rayhit;
    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float inputX = UnityEngine.Input.GetAxis("Horizontal");
        //float inputY = ;

        Vector3 velocity = new Vector3(inputX, 0, 0);
        Rigid.linearVelocity = velocity * speed;
        transform.position += velocity * speed * Time.deltaTime;


        Debug.DrawRay(Rigid.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(Rigid.position, Vector3.down, 1f);       

        if (rayhit && UnityEngine.Input.GetButtonDown("Jump"))
        {
            Debug.Log("rayhit, 점프인식");
            Rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }



}
