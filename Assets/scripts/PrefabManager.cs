using UnityEngine;

public class PrefabManager : MonoBehaviour 
{ 
    // Assign the prefab in the inspector 
    public GameObject BalloonPrefab; 
    
    //Singleton 
    private static PrefabManager m_Instance = null; 
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static PrefabManager Instance 
    { 
        get 
        { 
            if (m_Instance == null) 
            { 
                m_Instance = (PrefabManager)FindObjectOfType(typeof(PrefabManager)); 
            } return m_Instance; 
        } 
    } 
}
