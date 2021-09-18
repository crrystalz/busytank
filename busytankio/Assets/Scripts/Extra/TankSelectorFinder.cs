using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankSelectorFinder : MonoBehaviour
{
    public Image image;
    public Image image2;
    public Sprite tank1;
    public Sprite tank2;
    public Sprite logo1;
    public Sprite logo2;
    public Sprite logo3;
    public Sprite logo4;
    public Sprite logo5;

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
        if (ts.logoNumber == 1)
        {
            image2.sprite = logo1;
        }
        else if (ts.logoNumber == 2)
        {
            image2.sprite = logo2;
        }
        else if (ts.logoNumber == 3)
        {
            image2.sprite = logo3;
        }
        else if (ts.logoNumber == 4)
        {
            image2.sprite = logo4;
        }
        else
        {
            image2.sprite = logo5;
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

    public void NextLogo()
    {
        if(ts.logoNumber != 5)
        {
            ts.logoNumber += 1;
        }
        else
        {
            ts.logoNumber = 5;
        }
    }
    public void PrevLogo()
    {
        if (ts.logoNumber != 1)
        {
            ts.logoNumber -= 1;
        }
        else
        {
            ts.logoNumber = 1;
        }
    }
}
