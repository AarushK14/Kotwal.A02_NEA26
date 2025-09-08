using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dropdown : MonoBehaviour {
	public class Dropdown : MonoBehaviour
	{
		[SerializeField] private TMP_Dropdown dropdown;

		public void GetDropdownValue()
		{
			int pickedEntryIndex = dropdown.value;
			Debug.Log (pickedEntryIndex);
		}
	}
}
