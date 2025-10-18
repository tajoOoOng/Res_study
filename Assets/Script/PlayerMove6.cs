using UnityEngine.InputSystem;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //private Vector3 moveDirection;
    //[SerializeField] private float moveSpeed = 4f;


    //void Update()
    //{
    //    bool hasControl = (moveDirection != Vector3.zero);
    //    if (hasControl)
    //    {
    //        transform.rotation = Quaternion.LookRotation(moveDirection);
    //        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    //    }
    //}


    //void OnMove(InputValue value)
    //{
    //    Vector2 input = value.Get<Vector2>();
    //    if (input != null)
    //    {
    //        moveDirection = new Vector3(input.x, 0f, input.y);
    //        Debug.Log($"SEND_MESSAGE : {input.magnitude}");
    //    }

    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xClampRange = 5f;
    [SerializeField] private float yClampRange = 2f;
    [SerializeField] private Vector2 movement;

    private void Update()
    {
        Move();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void Move()
    {
        // 입력값에 따라 이동 계산
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange); // X축 이동 제한

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange); // Y축 이동 제한

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
}
