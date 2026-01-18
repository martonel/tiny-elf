using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    private GameObject target;
    public float moveSpeed = 3f;      // Mozgási sebesség
    public GameObject[] targets;
    private void Update()
    {
        if(target != null)
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) > 0.05f)
            {
                this.transform.position = Vector3.MoveTowards(
                       this.transform.position,
                       new Vector3(target.transform.position.x, this.transform.position.y, this.transform.position.z),
                       moveSpeed * Time.deltaTime
                      );
            }
            else
            {
                target = null;
            }
        }
    }
    public void SetTarget(int n)
    {
        this.target = targets[n];
    }
}
