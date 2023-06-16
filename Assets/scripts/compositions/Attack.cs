using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public void attackObject(GameObject obj, int damage) {
        if (obj.GetComponent<Health>() != null) {
            obj.GetComponent<Health>().takeDamage(damage);
        }
    }


}
