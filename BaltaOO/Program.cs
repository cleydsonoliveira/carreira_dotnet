using BaltaOO.ContentContext;

namespace BaltaOO
{
    class program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("Titulo", "Url"));
            foreach (var article in articles)
            {
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
            }

            var courses = new List<Course>();

            var course = new Course("Fundamentos OOP", "fundamentos-00p-url");
            var courseCSharp = new Course("Fundamentos C#", "fundamentos-c#-url");
            var courseAspNet = new Course("Fundamentos ASP.NET", "fundamentos-asp.net-url");

            courses.Add(course);
            courses.Add(courseCSharp);
            courses.Add(courseAspNet);

            var careers = new List<Career>();
            var careerDotnet = new Career("Especialista DOTNET", "esp-dotnet");
            var careerItem = new CareerItem(1, "Começe por aqui", "", null);
            careerDotnet.Items.Add(careerItem);
            careers.Add(careerDotnet);
            foreach (var career in careers)
            {
                Console.WriteLine(career.Title);
                
                foreach (var item in career.Items)
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                }
            }

        }
    }
}