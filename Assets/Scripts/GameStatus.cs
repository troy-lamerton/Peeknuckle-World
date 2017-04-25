using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStatus : MonoBehaviour {

	// lose a life when you really needed that, that thing, tea cup or something
	// protected int lives = 3;

	// PROPS sequence, code for each if player chooses to:
		// fight
		// fight OR retreat
		// retreat [AND !fight] [retreat to victory]
			// enemy has shit ton of hp, barely registers damage
		// freeze
			// if you move, the trophy disappears -- is taken away
		// comfort: tea break, elevator music passive break level, you get tea, no opposition?
		// comfort, suspense: elevator on ground

	// score is distance travelled
	protected float score = 0;
	public float DistanceToWin;

	GameObject scoreNumberGob;
	TextMesh scoreNumberText;
	// environment

	public bool levelWasWon = false;
	protected bool gameWon = false;

	// trophies
	public GameObject worldPropsHolder;

	// spawnable enemy prefab
	public GameObject spawnLotsAudio;
	public GameObject levelWonObject;
	
	static GameStatus instance;
	public static GameStatus GetInstance() {
        
		return instance;
	}
	// instance thing
	void Start () {
		if(instance != null) {
			Destroy(this.gameObject);
			return;
		}

		// we are "the one". Let's act like it.
		instance = this;
		GameObject.DontDestroyOnLoad( this.gameObject );
	}

	void Awake () {
		scoreNumberGob = GameObject.FindGameObjectWithTag("ScoreNumber");
		scoreNumberText = scoreNumberGob.GetComponent<TextMesh>();
	}
	
	bool IsLevelWon (float score) {
		return score >= DistanceToWin;
	}

	// trophies collected + trophies missed = score
	void FixedUpdate () {
		if (scoreNumberText == null) {
			scoreNumberGob = GameObject.FindGameObjectWithTag("ScoreNumber");
			if (scoreNumberGob != null) {
				scoreNumberText = scoreNumberGob.GetComponent<TextMesh>();
			}
		}
		if (levelWasWon == true && levelWonObject != null) {
			Debug.Log("IsLevelWon true!!");
			if ((int)(Time.time / Time.deltaTime) % 20 == 0) {
				var spawn = Object.Instantiate(levelWonObject, Vector3.forward, Quaternion.identity);
				GameObject.Destroy(spawn, 3f);
			}
		}
	}

	void Update () {
		// update any canvas scores etc
		var distLeft = DistanceToWin - score;
		int roundedScore = (int)Mathf.Round(distLeft * 10f);
		if (roundedScore < 0) roundedScore = 0;
		var scoreString = (roundedScore / 10).ToString();
		// if (roundedScore % 10 == 0) {
			// scoreString = scoreString + ".0";
		// }
		if (scoreNumberText != null) {
			scoreNumberText.text = scoreString;
		}

		// check is player in the good spot
		// var player = GameObject.FindGameObjectWithTag("Player");

		if (IsLevelWon(score)) {
			if (levelWasWon == false) {
				levelWasWon = true;
			}
			// TODO, load next level
			// just try loading new scene

		} else {
			levelWasWon = false;
		}
	}

	// got to winners area I believe
	public void WonGame() {
		// make sure its legit
		if (levelWasWon) {
			gameWon = true;
			StartCoroutine(VictorySequence());
		}
	}

	IEnumerator VictorySequence () {
		var podium = GameObject.FindGameObjectWithTag("Finish");

		yield return new WaitForSeconds(0.6f);
		while (podium.transform.position.y > 3f) {
			var pt = podium.transform.position;
			podium.transform.position.Set(pt.x, pt.y - 0.01f, pt.z);
			yield return new WaitForSeconds(1.0f);
		}


		yield return new WaitForSeconds(1.2f);
		
		SceneManager.LoadSceneAsync("MainMenu");
	}

	public void AddScore(float s) {
		score += s;
	}

	void OnDestroy() {
		Debug.Log("GameStatus was destroyed, game must be quitting...");

		// Before we get destroyed, we can save data 
		//PlayerPrefs.SetInt("score", score);
	}

	public float GetScore() {
		return score;
	}

	public static void RestartScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public static void ShowObject (GameObject gob, bool show = true) {
		if (show) {
			gob.SetActive(show);
		}
	}
}
