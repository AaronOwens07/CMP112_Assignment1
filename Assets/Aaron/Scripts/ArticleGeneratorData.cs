using UnityEngine;

[CreateAssetMenu(fileName = "TextGeneratorData", menuName = "Procedural/Text Generator Data")]
public class ArticleGeneratorData : ScriptableObject
{
    [Header("Templates")]
    public TextTemplate[] ArticleTemplates;

    public string[] companies;
    public string[] percentages;
    public string[] reasons;
    public string[] positive;
    public string[] negative;
}
