using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private static bool cooldown;

    [SerializeField] private GameObject Destination;

    void OnTriggerStay2D(Collider2D col)
    {
        if(cooldown) return;
        var o = col.GetComponent<PlayerController>();
        if(o){
            o.transform.position = Destination.transform.position;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(1f);
        cooldown = false;
    }
}
