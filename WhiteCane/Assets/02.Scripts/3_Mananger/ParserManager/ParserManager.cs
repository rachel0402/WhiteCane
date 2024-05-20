using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ParserManager : MonoBehaviour //Data Field
{
    public JsonParser JsonParser { get; private set; } = default;
}

public partial class ParserManager : MonoBehaviour //Intialize
{
    private void Allocate()
    {
        JsonParser = new JsonParser();
    }
    public void Initialize()
    {
        Allocate();
        JsonParser.Initialize();
    }

}
