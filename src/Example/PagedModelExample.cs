using System.Text.Encodings.Web;
using System.Text.Json;
using kr.bbon.Core;

namespace Example;

public class PagedModelExample
{
    public async Task RunAsync()
    {
        var test = new Test();
        var pagedModel1 = await test.GetPagedModel1Async();

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreReadOnlyFields = true,
            IgnoreReadOnlyProperties = true,
        };

        Console.WriteLine("#1 Output: {0}", pagedModel1.Items.First().Title);
        Console.WriteLine("Model:\n {0}", pagedModel1.ToJson(jsonSerializerOptions));

        var pagedModel2 = await test.GetPagedModel1Async();

        Console.WriteLine("#2 Output: {0}", pagedModel2.Items.First().Title);
        Console.WriteLine("Model:\n {0}", pagedModel2.ToJson(jsonSerializerOptions));
    }
}