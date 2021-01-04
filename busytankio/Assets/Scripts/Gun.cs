using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject player;
    public ParticleSystem particalsystem;
    public GameObject impactEffect;
    public int numPlayer;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot ()
    {
        particalsystem.Play();

        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2);
        }
    }
}
