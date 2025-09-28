using System.Collections.Generic;
using UnityEngine;

public class RewindController : MonoBehaviour
{
    public bool isRewinding = false;
    public float rewindTime = 5f;

    private List<Vector3> positions;
    private float recordTime = 0.02f;
    private float timer;

    private void Start()
    {
        positions = new List<Vector3>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            isRewinding = true;
        } else if(Input.GetKeyUp(KeyCode.E)) {
            isRewinding = false;
        }
    }

    private void FixedUpdate() {
        if(isRewinding) {
            Rewind();
        } else {
            Record();
        }
    }

    private void Record()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= recordTime)
        {
            timer = 0f;
            positions.Insert(0, transform.position);
            if (positions.Count > Mathf.Round(rewindTime / recordTime))
            {
                positions.RemoveAt(positions.Count - 1);
            }
        }

    }

    private void Rewind() {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            isRewinding = false;
        }
    }

    
}
