using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float JumpForce = 350;

    private Rigidbody2D _rig = null;
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Jump()
    {
        _rig.AddForce(new Vector2(0, JumpForce));
    }
}
