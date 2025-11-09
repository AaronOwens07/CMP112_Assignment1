using UnityEngine;
using TMPro;

public class ArticleGenerator : MonoBehaviour
{
    public ArticleGeneratorData data;

    public TMP_Text articleText;
    public TMP_Text oldArticleText;
    public TMP_Text FinalArticleText;


    public string GenerateArticle()
    {
        if (data == null || data.ArticleTemplates.Length == 0)
        {
            Debug.LogWarning("No text data assigned!");
            return string.Empty;
        }


        string template = data.ArticleTemplates[Random.Range(0, data.ArticleTemplates.Length)].template;


        template = template.Replace("{company}", data.companies[Random.Range(0, data.companies.Length)]);
        template = template.Replace("{positive}", data.positive[Random.Range(0, data.positive.Length)]);
        template = template.Replace("{negative}", data.negative[Random.Range(0, data.negative.Length)]);
        template = template.Replace("{reason}", data.reasons[Random.Range(0, data.reasons.Length)]);
        template = template.Replace("{percentage}", data.percentages[Random.Range(0, data.percentages.Length)]);

        return template;
    }

    public void DisplayNewArticle()
    {
        string article = GenerateArticle();

        if (articleText != null)
        {
            FinalArticleText.text = oldArticleText.text;
            oldArticleText.text = articleText.text;
            articleText.text = article;
        }

        Debug.Log("New article displayed.");
    }

}
