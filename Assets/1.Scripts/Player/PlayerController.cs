using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;
        tr.position += nextPos;
    }
}
