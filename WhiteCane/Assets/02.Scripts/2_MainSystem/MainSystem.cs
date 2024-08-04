using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class MainSystem : GenericSingleton<MainSystem> //data field
{
    public DataManager DataManager { get; private set; } = default;

    public ParserManager ParserManager { get; private set; } = default;
    public ObjectManager ObjectManager { get; private set; } = default;


}
public partial class MainSystem : GenericSingleton<MainSystem> //data field
{
    private void Allocate()
    {
        DataManager = gameObject.AddComponent<DataManager>();
        ParserManager = gameObject.AddComponent<ParserManager>();
        ObjectManager = gameObject.AddComponent<ObjectManager>();
    }
    public void Initialize()
    {
        Allocate();
        ParserManager.Initialize();
        DataManager.Initialize();
        ObjectManager.Initialize();
    }

    public void ActiveMainSystem()
    {
        Initialize();

        SceneManager.LoadScene("NatureQuiz");
    }
}