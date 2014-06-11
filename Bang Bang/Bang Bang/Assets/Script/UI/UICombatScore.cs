using UnityEngine;
using System.Collections;

public class UICombatScore : MonoBehaviour
{
	public TextMesh victoryOne;
	public TextMesh victoryTwo;

	void Start() 
	{
		this.placingText();
	}

	private void placingText()
	{
		if(CombatController.playerOne != null && !CombatController.playerTwo != null)
		{
			victoryOne.text = CombatController.playerOne.GetComponent<GeneralBehaviour>().victorys.ToString();
			victoryTwo.text = CombatController.playerTwo.GetComponent<GeneralBehaviour>().victorys.ToString();
		}
	}

}
