using UnityEngine;

public class EntityAttack : MonoBehaviour {
    GameObject weapon;
    Collider2D weaponCollider;

    public bool hasAttacked = false;
    public float timeBetweenAttacks;

    float tba;
    [SerializeField]bool canAttack = true;

    void Start() {
        weapon = GetComponentInChildren<Damage>().gameObject;
        weaponCollider = weapon.GetComponent<Collider2D>();

        weaponCollider.enabled = false;
        tba = timeBetweenAttacks;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && canAttack) {
            Debug.Log("Attack");
            // Enable the collider of the weapon in order to deal damage
            // timeout before disable the collider again
            hasAttacked = true;
            weaponCollider.enabled = true;
        }

        if (hasAttacked) {
            timeBetweenAttacks -= Time.deltaTime;
            canAttack = false;

            if (timeBetweenAttacks <= 0f) {
                canAttack = true;
                hasAttacked = false;
                timeBetweenAttacks = tba;
                weaponCollider.enabled = false;
            }
        }
    }


}
