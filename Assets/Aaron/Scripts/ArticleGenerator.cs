using UnityEngine;

public class ArticleGenerator : MonoBehaviour
{
    public ArticleGeneratorData data;

    public string GenerateArticle()
    {
        if (data == null || data.ArticleTemplates.Length == 0)
        {
            Debug.LogWarning("No text data assigned!");
            return string.Empty;
        }


        string template = data.ArticleTemplates[Random.Range(0, data.ArticleTemplates.Length)].template;


        template = template.Replace("{company}", data.companies[Random.Range(0, data.companies.Length)]);
        template = template.Replace("{change}", data.change[Random.Range(0, data.change.Length)]);
        template = template.Replace("{reason}", data.reasons[Random.Range(0, data.reasons.Length)]);
        template = template.Replace("{percentage}", data.percentages[Random.Range(0, data.percentages.Length)]);

        return template;
    }

    void Start()
    {
        //working chekc
        Debug.Log(GenerateArticle());
    }
}
