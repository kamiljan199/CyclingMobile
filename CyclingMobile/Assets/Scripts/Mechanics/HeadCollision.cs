using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{
    public BicycleController bc;
    //private BoxCollider2D headCol;
    private GameObject edge;
    private EdgeCollider2D edgeCol;

    // Start is called before the first frame update
    void Start()
    {
        //headCol = GetComponent<BoxCollider2D>();
        edge = GameObject.Find("SpriteShape");
        edgeCol = edge.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == edgeCol)
        {
            Debug.Log("GLOWA ROZBITA");
            bc.lost = true;
        }
    }
}

