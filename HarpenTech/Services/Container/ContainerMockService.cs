
namespace HarpenTech.Services.Container;

public class ContainerMockService : IContainerService
{
    public Task GetContainerInfoAsync(string authToken)
    {
        throw new NotImplementedException();
    }

    ContainerInfo IContainerService.GetContainerInfoAsync(string authToken)
    {
        throw new NotImplementedException();
    }
}