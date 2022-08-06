using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10099999999f;
    public Camera fpscam;
    public GameObject haha;
    public float fireRate = 15f;
    float nextTimeToFire = 0f;
    public GameObject muzzle;
    public GameObject damaged;
    public GameObject sound;
    public GameObject grenade;
    public GameObject script;
    public GameObject script2;

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.LeftControl) == true ){
            Debug.Log("succeess");
        }
        if(Input.GetMouseButton(0)){
            muzzle.SetActive(true);
        }
        else{
            muzzle.SetActive(false);
        }
        if(Input.GetMouseButton(0) && Time.time >=nextTimeToFire && Input.GetKey(KeyCode.LeftControl)){
            Instantiate(grenade,gameObject.transform.gameObject.transform.position,Quaternion.identity);
        }
        if(Input.GetMouseButton(0) && Time.time >=nextTimeToFire && !(Input.GetKey(KeyCode.LeftControl))){

            nextTimeToFire=Time.time+1f/fireRate;
            muzzle.SetActive(true);
        RaycastHit hit;
        if(Physics.Raycast(fpscam.transform.position,fpscam.transform.forward,out hit,range)){
            sound.SetActive(true);
            Instantiate(haha,hit.point,Quaternion.identity);
            Debug.Log(hit.transform.gameObject.name);
            if(hit.transform.gameObject.name.Contains("wood")){
                //hit.transform.gameObject.GetComponent<destroy>().Shatter();
                
                Destroy(hit.transform.gameObject);
                Instantiate(damaged,hit.transform.gameObject.transform.position,Quaternion.identity);
                //a 
            }
            if(hit.transform.gameObject.name.Contains("Piece")){
                //hit.transform.gameObject.GetComponent<destroy>().Shatter();
                Debug.Log("cracked");
                Destroy(hit.transform.gameObject);                //a 
            }
        if(hit.transform.gameObject.name.Contains("hand")){
                //hit.transform.gameObject.GetComponent<destroy>().Shatter();
                script.AddComponent<fallDown>();
            }
        if(hit.transform.gameObject.name.Contains("hand2")){
                //hit.transform.gameObject.GetComponent<destroy>().Shatter();
                script2.AddComponent<fallDown>();
            }
            //if(hit.transform.gameObject.name.Contains("Sack")){
                
                //hit.transform.gameObject.GetComponent<destroy>().Shatter();
                hit.rigidbody.AddForce(-1 * hit.normal*100);
            //}
            }

        }
        else{
            sound.SetActive(false);
            }

    }
  

    }
