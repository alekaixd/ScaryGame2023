using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform movePoint;
    public int liikkuvuus;
    private int askelia = 0;
    private float nolla = 0f;

    public LayerMask whatStopsMovement;

    // Start is called before the first frame update
    void Start()
    {
        //irrotetaan movePoint vanhemmasta
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != movePoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        }
        else if (askelia<liikkuvuus) {
            askelia++;
            //pelaaja seuraa movePointtia jos se ei koske movePointtiin tai jos edessä ei ole objekti
            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), nolla, nolla), .3f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * 3, nolla, nolla);
                    }
                }

                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(nolla, Input.GetAxisRaw("Vertical"), nolla), .3f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(nolla, Input.GetAxisRaw("Vertical") * 3, nolla);
                    }
                }
            }
        }
    }
}
