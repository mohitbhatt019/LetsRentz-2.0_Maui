

using HarpenTech.Services.RequestProvider;

namespace HarpenTech.Services.Container;

public class ContainerService : IContainerService
{
    private readonly IRequestProvider _requestProvider;

    public ContainerService(IRequestProvider requestProvider)
    {
        _requestProvider = requestProvider;
    }

    public  Task<ContainerInfo> GetContainerInfoAsync(string authToken)
    {
        //var uri = UriHelper.CombineUri(GlobalSetting.Instance.UserInfoEndpoint);

        //var userInfo = await _requestProvider.GetAsync<ContainerInfo>(uri, authToken);
        return null;
    }

    ContainerInfo IContainerService.GetContainerInfoAsync(string authToken)
    {
        throw new NotImplementedException();
    }
}