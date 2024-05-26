using UnityEngine;

public class CoilCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            transform.parent.transform.GetComponent<CoilBehavior>().isFailed = true;
        }
    }

}
