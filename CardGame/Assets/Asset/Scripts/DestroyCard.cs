using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCard : MonoBehaviour
{
    private GameObject destroyCard;

    void OnCollisionEnter2D(Collision2D coll)
    { 
        if (coll.gameObject.tag.Equals("bounce")) //Change tag
            Destroy(coll.gameObject);
    }


/**    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bounce"))
        {
            Destroy(collision.gameObject);
        }
    }**/

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag.Equals("bounce"))
        {
            Destroy(other.gameObject);
        }
    }

    public void OnClick()
    {
        destroyCard = GameObject.FindGameObjectWithTag("bounce");
        Destroy(destroyCard);


    }

}