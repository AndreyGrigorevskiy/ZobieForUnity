using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject decal;
    public AudioSource audio;
    public float waitTime = .15f;

    private float wait = 0f;
    
    public void Shoot()
    {
        if(wait <= 0f)
        {
            wait = waitTime;
            audio.Play();

            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if(hit.collider.tag == "Enemy")
                {
                    hit.transform.SendMessage("Damage");
                }
                else
                {
                    GameObject currentDecale = Instantiate<GameObject>(decal);
                    currentDecale.transform.position = hit.point + hit.normal * 0.01f;
                    currentDecale.transform.rotation = Quaternion.LookRotation(-hit.normal);
                    currentDecale.transform.SetParent(hit.transform);

                    Rigidbody r = hit.transform.GetComponent<Rigidbody>();
                    if(r != null)
                    {
                        r.AddForceAtPosition(hit.normal * 0.25f, hit.transform.InverseTransformPoint(hit.point), ForceMode.Impulse);
                    }
                }

            }
        }
    }

    private void Update()
    {
        if(wait>0)
        {
            wait -= Time.deltaTime;
        }
    }
}
