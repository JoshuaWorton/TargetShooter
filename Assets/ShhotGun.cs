using UnityEngine;

public class ShhotGun : MonoBehaviour
{
    public int ammo = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo>0){
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.gameObject.name == "Target"){
                Animation targetAnimation = hitInfo.collider.GetComponentInParent<Animation>();
                targetAnimation.Play("LowerBridge");
                ammo--;
            }
        } else if (Input.GetButtonDown("Fire1") && ammo == 0){
            AudioSource noAmmo = GetComponent<AudioSource>();
            noAmmo.Play();
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "AmmoBox"){
            ammo += 20;
            other.gameObject.SetActive(false);
        }
    }
}
