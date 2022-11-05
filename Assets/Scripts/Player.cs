using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 moveDirection;

    [SerializeField]
    float speed = 3;

    [SerializeField]
    Transform aim;

    [SerializeField]
    Camera camera;

    Vector2 facingDirection;

    [SerializeField]
    Transform bulletPrefab;

    bool gunLoaded = true;

    [SerializeField]
    float fireRate = 1;

    [SerializeField]
    int health = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * speed;

        //  Movimiento de la mira
        facingDirection =
            camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position =
            transform.position + (Vector3) facingDirection.normalized;

        //  Disparar bala
        if (Input.GetMouseButton(0) && gunLoaded)
        {
            gunLoaded = false;

            //Botón izquierdo
            float angle =
                Mathf.Atan2(facingDirection.y, facingDirection.x) *
                Mathf.Rad2Deg; // Ángulo rotación entre mira y player (grados)
            Quaternion targetRotation =
                Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(bulletPrefab, transform.position, targetRotation);

            StartCoroutine(ReloadGun());
        }
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / fireRate);
        gunLoaded = true;
    }

    public void TakeDamage()
    {
        health--;
    }
}
