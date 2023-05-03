using EffundoTest.Models;
using System.Text;

namespace EffundoTest.Services
{
    public class MockPageService
    {
        List<Page> _pages;
        public MockPageService(int pageCount)
        {
            _pages = GeneratePages(pageCount).ToList();
        }

        public List<Page> GetPages()
            => _pages;

        public Page GetPage(string title)
            => _pages.First(x => x.Title == title);

        public IEnumerable<Page> GeneratePages(int numberOfPages)
        {
            for(int i = 1; i <= numberOfPages; i++)
            {
                yield return new Page()
                {
                    Title = "Page" + i.ToString(),
                    Content = LoremIpsum(5, 25, 10, 50, 5)
                };
            }
        }

        static string LoremIpsum(int minWords, int maxWords,
        int minSentences, int maxSentences,
        int numParagraphs)
        {

            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
        "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
        "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                var title = words[rand.Next(words.Length)] + " " + words[rand.Next(words.Length)];
                result.Append("<h4 id='" + title.Replace(" ", "_") + "'>" + title + "</h4>");

                result.Append("<p>");
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                result.Append("</p>");
            }

            return result.ToString();
        }
    }
}
