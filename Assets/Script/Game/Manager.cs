using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    [HideInInspector]
    public Lemon lemon;
    [HideInInspector]
    public PlayRoad road;
    [HideInInspector]
    public City city;
    public Sala sala;
    public static Manager gManager;
	// Use this for initialization
    void Awake()
    {
        gManager = this;
        
    }
    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
