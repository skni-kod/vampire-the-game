using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour, ISaveable
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public object SaveState()
    {
        return new SaveData()
        {
            x = this.transform.position.x,
            y = this.transform.position.y,
            rz= this.rb.rotation
        };
    }
    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        Vector2 poz = new Vector2(saveData.x, saveData.y);
        rb.position = poz;
        Vector3 rot = new Vector3(0,0, saveData.rz);
        transform.rotation = Quaternion.Euler(rot);
    }

    [System.Serializable]
    private struct SaveData
    {
        public float x;
        public float y;
        public float rz;
    }
}
