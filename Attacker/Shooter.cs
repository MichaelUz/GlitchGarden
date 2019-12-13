using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject shootingPoint;
    [SerializeField] int damage;

    //Helper Methods--------------------------------------------------------

    //This method fires a projectile
    public void Fire()
    {
        Projectile proj = Instantiate(projectile, shootingPoint.transform.position, shootingPoint.transform.rotation).GetComponent<Projectile>();
        proj.setDamage(damage);
    }

    //Gets damage
    public int GetDamage() { return damage; }
}
