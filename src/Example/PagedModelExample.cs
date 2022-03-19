namespace Example;

public class PagedModelExample
{
    public async Task RunAsync()
    {
        var test = new Test();
        var pagedModel1 = await test.GetPagedModel1Async();

        Console.WriteLine("#1 Output: {0}",pagedModel1.Items.First().Title);


        var pagedModel2 = await test.GetPagedModel1Async();

        Console.WriteLine("#2 Output: {0}",pagedModel2.Items.First().Title);
    }
}