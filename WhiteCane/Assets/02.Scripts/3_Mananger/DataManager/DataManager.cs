using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DataManager : MonoBehaviour
{
	public NarrationData NarrationData { get; private set; } = default;
}
public partial class DataManager : MonoBehaviour
{
    private void Allocate()
    {
        NarrationData = new NarrationData();
    }
    public void Initialize()
    {
        Allocate();
        NarrationData.Initialize();
    }
}
