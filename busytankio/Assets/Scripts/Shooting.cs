using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        void Shoot() 
        {
            RaycastHit hit;
            if (Physics.Raycast(GameObject.Find("Player").transform.position, GameObject.Find("Player").transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
