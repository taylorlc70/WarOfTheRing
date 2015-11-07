using UnityEngine;
using System.Collections;

public interface IDice {

	void SelectDie();
	void DeselectDie();
	void Roll();
	void SetAvailableActions(int index);
}
