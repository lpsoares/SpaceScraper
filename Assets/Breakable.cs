using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{

    public List<GameObject> breakablePieces;
    public float timeToBreak = 2f;
    private float timer = 0f;
    public UnityEvent OnBreak;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject piece in breakablePieces)
        {
            piece.SetActive(false);
        }
    }

    public void Break()
    {

        timer += Time.deltaTime;

        if(timer > timeToBreak)
        {
            foreach(GameObject piece in breakablePieces)
            {
                piece.SetActive(true);
                piece.transform.parent = null;
            }

            OnBreak.Invoke();
            gameObject.SetActive(false);
        }
    }
}
