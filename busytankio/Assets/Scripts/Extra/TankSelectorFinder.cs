using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankSelectorFinder : MonoBehaviour
{
    public Image image;
    public Sprite tank1;
    public Sprite tank2;
    public TankSelection ts;
    // Start is called before the first frame update
    void Start()
    {
        ts = GameObject.Find("TankSelector").GetComponent<TankSelection>();
        ChangeImage();
    }

    void Update()
    {
        ChangeImage();
    }
    // Update is called once per frame
    public void ChangeImage(){
        if (ts.tankNumber == 1)
            image.sprite = tank1;
        else {
            image.sprite = tank2;
        }
    }
    public void NextTank(){
        if(ts.tankNumber != 2){
            ts.tankNumber += 1;
        }
        else{
            ts.tankNumber = 2;
        }
    }
    public void PrevTank(){
        if(ts.tankNumber != 1){
            ts.tankNumber -= 1;
        }
        else{
            ts.tankNumber = 1;
        }
    }
}
