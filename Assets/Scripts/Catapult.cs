using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour {
    public int fireSpeed = 1;
    public int reloadSpeed = 1;
    public Transform rotPoint;
    public List<int> objectForces = new List<int>();
    public List<GameObject> Ammo = new List<GameObject>();
    public Camera cam;
    public float camMod;

    private int selectedProjectile;
    private List<GameObject> Projectiles = new List<GameObject>();
    private Vector3 zAxis = new Vector3(0, 0, 1);
    private Vector2 coord1;
    private Vector2 coord2;
    private int state = 1;

    private void Update()
    {
        if (state == 1)
        {
            Reload();
        }
        if (state == 2)
        {
            Aim();
        }
        if (state == 3)
        {
            Fire();
        }
    }

    private void Reload()
    {
        this.transform.RotateAround(rotPoint.position, zAxis, -reloadSpeed);
        if (this.transform.eulerAngles.z >= 330 && this.transform.eulerAngles.z <= 350)
        {
            selectedProjectile = Random.Range(0, Ammo.Count);
            Projectiles.Add(Instantiate(Ammo[selectedProjectile], this.transform));
            Projectiles[Projectiles.Count - 1].GetComponent<Rigidbody2D>().isKinematic = true;
            state = 2;
        }
    }

    private void Aim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float x1 = Input.mousePosition.x;
            float y1 = Input.mousePosition.y;
            coord1.x = x1;
            coord1.y = y1;
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            float x2 = Input.mousePosition.x;
            float y2 = Input.mousePosition.y;
            coord2.x = x2;
            coord2.y = y2;
            state = 3;
        }
    }

    private void Fire()
    {
        this.transform.RotateAround(rotPoint.position, zAxis, fireSpeed);

        if (this.transform.eulerAngles.z >= 100 && this.transform.eulerAngles.z <= 120 && Projectiles[Projectiles.Count - 1] != null)
        {
            Projectiles[Projectiles.Count - 1].GetComponent<Rigidbody2D>().isKinematic = false;
            Projectiles[Projectiles.Count - 1].transform.parent = null;
            Vector2 A = (coord1 - coord2);
            Vector2 B = A.normalized;
            Projectiles[Projectiles.Count - 1].GetComponent<Rigidbody2D>().AddForce((B) * objectForces[selectedProjectile]);
            state = 1;
        }
    }
}