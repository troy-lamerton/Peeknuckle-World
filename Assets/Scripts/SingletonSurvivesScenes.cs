using UnityEngine;

public class SingletonSurvivesScenes : MonoBehaviour {

	static SingletonSurvivesScenes instance;

	public static SingletonSurvivesScenes GetInstance() {
		return instance;
	}

	void Start () {
		if(instance != null) {
			Destroy(this.gameObject);
			return;
		}

		instance = this;
		GameObject.DontDestroyOnLoad( this.gameObject );
	}
}
