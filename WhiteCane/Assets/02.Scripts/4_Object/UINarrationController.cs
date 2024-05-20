using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public partial class UINarrationController : MonoBehaviour//data
{
    //ÇöÀç index
    public int narrationIndex = 0;

    [SerializeField]
    TMP_Text narrationText;

    [SerializeField]
    UnityEvent activeEvent;
    [SerializeField]
    UnityEvent deactiveEvent;
}
public partial class UINarrationController : MonoBehaviour//initialze
{
    private void Start()
    {
        MainSystem.Instance.DataManager.NarrationData.DynamicAllocate_UINarrationController(this);

    }
    public void Initialize()
    {

    }

}
public partial class UINarrationController : MonoBehaviour//fuction
{

    public void Active()
    {
        activeEvent?.Invoke();
    }
    public void Deactive()
    {
        deactiveEvent?.Invoke();
    }
    public void SetNarration(string narration)
    {
        narrationText.text = narration;
    }
   
}
