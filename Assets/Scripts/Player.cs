using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    int health = 3;

    [SerializeField]
    RawImage[] hearts;

    [SerializeField]
    private AudioSource laserSoundEffect;

 
    // Update is called once per frame
    void Update()
    {
        RenderHealth (health);

        transform.position += moveDirection * Time.deltaTime * speed;


	    Mira();
	    Disparar();
    }
    
    
    
	void Mira()
	{
		
		//  Movimiento de la mira
		facingDirection =
			camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		aim.position =
			transform.position + (Vector3) facingDirection.normalized;
	}
    
	void Disparar()
	{
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
			laserSoundEffect.Play();
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

    public void RenderHealth(int health)
    {
        switch (health)
        {
            case 0:
                hearts[0].GetComponent<RawImage>().enabled = false;
                break;
            case 1:
                hearts[1].GetComponent<RawImage>().enabled = false;
                break;
            case 2:
                hearts[2].GetComponent<RawImage>().enabled = false;
                break;
        }
    }
}
