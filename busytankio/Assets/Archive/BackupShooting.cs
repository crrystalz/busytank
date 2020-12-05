using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupShooting : MonoBehaviour
{
    /*
    private CharacterController _controller;
    [SerializeField]

    private bool _isReLoading = false;

    

    public bool hasCoin = false;
    [SerializeField]
    

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        

        if (Input.GetKeyDown(KeyCode.R) && _isReLoading == false)
        {
            _isReLoading = true;
            StartCoroutine(Reload());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        CalculateMovement();
    }
    void Shoot()
    {

        Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Hit: " + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        _isReLoading = false;
    }

    public void EnableWeapons()
    {
        _weapon.SetActive(true);
    }
    */
}
