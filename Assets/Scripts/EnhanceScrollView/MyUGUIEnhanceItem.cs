using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyUGUIEnhanceItem : EnhanceItem
{
    ///As all the item contain a button component and A rawImage component
    private Button uButton;
    private RawImage rawImage;

    protected override void OnStart() //Calling OnStart() from EnhanceItem as this is a extended class from Enhance Item. Actually monobehaviour class provide OnStart().
    {
        rawImage = GetComponent<RawImage>(); //getting components
        uButton = GetComponent<Button>();
        uButton.onClick.AddListener(OnClickUGUIButton);//OnClickUGUIButton method will be called when we click the button
    }

    private void OnClickUGUIButton()
    {
        Debug.Log("Calling  OnClickEnhanceItem() from EnhanceItem Class");
        OnClickEnhanceItem(); //this method is from the parent=EnhanceItem class.
    }

    // Set the item "depth" 2d or 3d
    protected override void SetItemDepth(float depthCurveValue, int depthFactor, float itemCount)
    {
        int newDepth = (int)(depthCurveValue * itemCount);

        this.transform.SetSiblingIndex(newDepth);
    }

    //this mkethod changes the center item color into white and others into gray
    public override void SetSelectState(bool isCenter)
    {
        if (rawImage == null)
            rawImage = GetComponent<RawImage>();
        rawImage.color = isCenter ? Color.white : Color.gray; //this line works great it makes center item color white and others gray
    }
}
