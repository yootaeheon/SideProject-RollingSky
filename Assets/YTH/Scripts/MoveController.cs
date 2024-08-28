using UnityEngine;

public class MoveController : MonoBehaviour
{

    [SerializeField] Rigidbody rigid;
    [SerializeField] float moveSpeed;
    [SerializeField] float rate;

    private bool y;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool y = Input.GetKeyDown(KeyCode.Space);


        //Debug.Log($"{x}, {z}");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir.magnitude > 1) //GetAxisRaw 가 아니어도 정규화 가능
        {
            moveDir.Normalize();
        }

        rigid.velocity = moveDir * moveSpeed;

        Quaternion lookRot = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, rate * Time.deltaTime);

        //점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }


    }
}
