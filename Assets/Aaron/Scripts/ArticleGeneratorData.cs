using UnityEngine;


// adds menu item to create the ScriptableObject in Unity editor
[CreateAssetMenu(fileName = "TextGeneratorData", menuName = "Procedural/Text Generator Data")]
public class ArticleGeneratorData : ScriptableObject
{
    [Header("Templates")]

    // text templates for article generation
    public TextTemplate[] ArticleTemplates;

    // list of words and phrases to use in article generation
    public string[] companies;
    public string[] percentages;
    public string[] reasons;
    public string[] positive;
    public string[] negative;
}
