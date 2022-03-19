using kr.bbon.Core.Models;

namespace Example;

public class Test
{
    public async Task<IPagedModel<Sample>> GetPagedModel1Async()
    {
        var items = new List<Sample>
        {
            new Sample() {Title = "Hello world!"},
        };
        var pagedModel = new PagedModel<Sample>(1, 1, 1, 1, items);

        await Task.Delay(TimeSpan.FromSeconds(1));

        return pagedModel;
    }

    public Task<IPagedModel<Sample>> GetPagedModel2Async()
    {
        var items = new List<Sample>
        {
            new Sample() {Title = "Hello world!"},
        };
        IPagedModel<Sample> pagedModel = new PagedModel<Sample>(1, 1, 1, 1, items);

        return Task.FromResult(pagedModel);
    }
}