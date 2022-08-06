using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Heavy_08");
        gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
