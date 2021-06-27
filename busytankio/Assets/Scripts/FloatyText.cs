using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyText : MonoBehaviour
{
    public float lifeTime;
    public float timer;
    public Vector3 floatdir = Vector3.up;
    Rigidbody rb;
    TMPro.TMP_Text text;
    public bool bilboard = true;
    public string Text
    {
        get
        {
            return text.text;
        }
        set
        {
            text.text = value;
        }
    }

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.velocity = floatdir;
        if (bilboard)
        {
            Bilboard.Calculate(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.faceColor = Color.Lerp(Color.white, Color.clear,(timer/lifeTime));
        text.outlineColor = Color.Lerp(Color.black, Color.clear, (timer / lifeTime));
        if(timer >= lifeTime)
        {
            Destroy(gameObject);
        }

    }

    public static FloatyText Make(FloatyText prefab, string text, Vector3 pos)
    {
        FloatyText ft = Instantiate(prefab.gameObject).GetComponent<FloatyText>();
        ft.transform.position = pos;
        ft.Text = text;
        return ft;
    }
}
