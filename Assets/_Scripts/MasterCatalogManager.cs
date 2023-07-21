using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MasterCatalogManager : Manager<MasterCatalogManager>
{
    public CatalogAsset MasterCatalog;

    private Dictionary<string, Question> _questionDictionary = new();
    public override void Initialize()
    {
        foreach (var question in MasterCatalog.QuestionAssets)
        {
            _questionDictionary.Add(question.questionId, question);
        }
    }
    public List<Question> GetAllQuestions() => _questionDictionary.Values.ToList();
}
