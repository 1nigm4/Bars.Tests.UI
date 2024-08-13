namespace JsonResultParser
{
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class Program
    {
        private const string AllurResultsPath = "E:\\Projects\\Bars\\Bars.Tests.UI\\Bars.Tests.UI.AW.AccountClient\\bin\\Debug\\net8.0\\allure-results";

        static void Main(string[] args)
        {
            var filesPaths = Directory.GetFiles(AllurResultsPath)
                .Where(fileName => fileName.Contains("result.json"));

            var tests = new List<TestCase>();
            foreach (var filePath in filesPaths)
            {
                using (var fileReader = File.OpenText(filePath))
                {
                    using (var jsonReader = new JsonTextReader(fileReader))
                    {
                        var result = JToken.ReadFrom(jsonReader);
                        var labels = result["labels"]!
                            .ToDictionary(l => l.Value<string>("name")!, l => l.Value<string>("value")!);

                        var testClass = labels["testClass"];
                        var testMethod = labels["testMethod"];

                        var steps = result["steps"]!
                            .Select(step => step.Value<string>("name")!)
                            .ToArray();

                        tests.Add(new TestCase
                        {
                            Class = testClass,
                            Method = testMethod,
                            Steps = steps
                        });
                    }
                }
            }

            var sb = new StringBuilder();
            var testCases = tests.GroupBy(tc => tc.Class);
            foreach (var testCase in testCases)
            {
                sb.Append($"{testCase.Key}");
                foreach (var test in testCase)
                {
                    sb.Append($"\t{test.Method}");
                    var steps = string.Join("\n\t\t", test.Steps);
                    sb.AppendLine($"\t{steps}");
                }

                sb.AppendLine();
            }

            var resultFilePath = Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.ToShortDateString() + ".txt");
            File.WriteAllText(resultFilePath, sb.ToString());
        }
    }

    class TestCase
    {
        public string Class { get; set; }
        public string Method { get; set; }
        public string[] Steps { get; set; }
    }
}
