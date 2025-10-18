using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5f;
    float rotateSpeed = 5.0f;
    public float jumpForce = 5.0f;
    Rigidbody2D Rigid;
    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
        if (rayhit != false) { Debug.Log("충돌감지!"); }

        // 점프 처리
        if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("입력감지!");
            Rigid.linearVelocity = new Vector3(Rigid.linearVelocity.x, jumpForce);

        }
    }

}