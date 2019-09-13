using UnityEngine;

public class EntityHealth : MonoBehaviour {
    public int health;

    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEntere2D(Collider2D collider) {
        Damage entitiyWeaponDamage = collider.GetComponent<Damage>();
        BoxCollider2D entityBoxCollider = collider.gameObject.GetComponent<BoxCollider2D>();

        Debug.Log(entitiyWeaponDamage);
        Debug.Log(entityBoxCollider);
        if (entitiyWeaponDamage && entityBoxCollider.enabled) {
            Debug.Log("Entity has dealth " + entitiyWeaponDamage.damage);
        }
    }
}
