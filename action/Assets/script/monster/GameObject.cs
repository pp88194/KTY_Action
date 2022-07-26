using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject : MonoBehaviour
{
    int cnt;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Monster")
        {
            if (Vector3.Distance(transform.position, Monster.Instance.transform.position) < 1.5f)
            {
                cnt++;
                Debug.Log(cnt);
                if (cnt > 3) { gameObject.SetActive(false); }
            }
        }
    }
}
