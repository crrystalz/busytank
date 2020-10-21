using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Transform gun;
    public Transform marker;
    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        
    }
    void Shoot()
    {
        Debug.Log("Ho!");
        RaycastHit hit;
        if (Physics.Raycast(gun.position, gun.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            marker.position = hit.point;
        }
        else
        {
            marker.position = gun.position;
        }
    }
}
