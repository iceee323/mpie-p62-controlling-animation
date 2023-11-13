using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectAmmo : MonoBehaviour
{
    public float ammoLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && ammoLevel > 0)
        {
           Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
           RaycastHit result;
           Physics.Raycast(ray, out result);

            if (result.collider.gameObject.name == "Target")
            {
                GameObject g = result.collider.gameObject;
                Animation a = g.transform.parent.GetComponent<Animation>();
                a.Play("LowerBridge");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("AmmoBox"))
        {
            other.gameObject.SetActive(false);
            ammoLevel += 20;
        }
            
    }
}
