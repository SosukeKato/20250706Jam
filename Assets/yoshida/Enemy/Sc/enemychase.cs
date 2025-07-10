using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemychase : MonoBehaviour
{
    [Header("追いかける対象（タグ名で指定）")]
    [SerializeField] private string playerTag = "Player";
    [Header("プレイヤーを見つける範囲")]
    [SerializeField] private float detectionRange = 10f;
    [Header("追いかけるスピード")]
    [SerializeField] private float moveSpeed = 3f;

    private Transform player;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }
    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);

            rb.velocity = velocity;

            // プレイヤーの方向を見る（左右反転だけしたい場合は scale.x を反転するだけでもOK）
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
