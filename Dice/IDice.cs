using UnityEngine;
using System.Collections;

public interface IDice {

	void SpawnMenu();
	void CloseMenu();
	void Roll();
	void SetButtons(int index);
	void SetInteractableTrue();
	void SetInteractableFalse();
}
