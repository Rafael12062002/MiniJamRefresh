using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguePlayer : MonoBehaviour
{
    public MovePlayer player;
    public GameObject segue;
    public float camVel = 0.25f;

    void Start()
    {
        player = FindObjectOfType<MovePlayer>();
        segue = GameObject.FindWithTag("segue");
    }

    void Update()
    {
        transform.position = segue.transform.position + new Vector3(0, 0, -1);
    }
}
