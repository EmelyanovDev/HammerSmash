using UnityEngine;

public class UISound : MonoBehaviour
{
    public static UISound _instance {private set; get;}

    private void Awake() 
    {
        Singleton();    
    }

    private void Singleton()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
