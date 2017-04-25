using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour {

	Coroutine cutscene = null;

	public Actions riggedFemale;

	public string gameplayScene = "Playing";

	public AudioSource girlInteractAudio;
	public AudioSource girlInteractAudio2;

	public void LoadSceneNamed (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void StartIntroSequence() {
		if (cutscene == null) {
			cutscene = StartCoroutine(AnimationSequence());
		}
	}

	public void LoadGameImmediately() {
		if (cutscene != null) {
			StopCoroutine(cutscene);
		}
		this.LoadSceneNamed(this.gameplayScene);
	}

	public void InteractGirl () {
		if (!girlInteractAudio.isPlaying) {
			girlInteractAudio.Play();
		}
	}

	public void InteractGirl2 () {
		if (!girlInteractAudio2.isPlaying) {
			girlInteractAudio2.Play();
		}
	}

	IEnumerator AnimationSequence () {
		riggedFemale.Walk();

		this.InteractGirl();
		yield return new WaitForSeconds(0.6f);
		this.InteractGirl2();
		yield return new WaitForSeconds(1.0f);

		riggedFemale.Stay();

		yield return new WaitForSeconds(1.2f);
		
		LoadGameImmediately();
	}

}

