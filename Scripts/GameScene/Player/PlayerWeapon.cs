using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float attackRate = 0.1f;
    [SerializeField]
    private float CallunaAmplificationTime = 10f;
    
    private bool  CallunaAmplification = false;

    public void ActivateCallunaAmplification() {
        StartCoroutine("CallunaAmplificationCoroutine");
    }

    private IEnumerator CallunaAmplificationCoroutine() {
        CallunaAmplification = true;
        yield return new WaitForSeconds(CallunaAmplificationTime);
        CallunaAmplification = false;
    }

    public void StartFiring() {
        StartCoroutine("TryAttack");
    }

    public void StopFiring() {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack() {
        while (true) {
            if (CallunaAmplification == true) {
                Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, 0f) + Vector3.left * 0.3f, Quaternion.identity);
                Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, 0f) + Vector3.right * 0.3f, Quaternion.identity);
            }
            else {
                Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
            }

            yield return new WaitForSeconds(attackRate);
        }
    }
}
