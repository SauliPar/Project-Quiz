using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CatalogAsset", menuName = "CatalogAsset", order = 1)]
public class CatalogAsset : ScriptableObject
{
	public List<Question> QuestionAssets = new();
}
