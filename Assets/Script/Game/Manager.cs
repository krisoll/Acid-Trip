using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    public Lemon lemon;
    public PlayRoad road;
    public City city;
    public static Manager gManager;
	// Use this for initialization
    void Awake()
    {
        gManager = this;
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
