
namespace HarpenTech.Services.Container
{
    public interface IContainerService
    {
       public ContainerInfo GetContainerInfoAsync(string authToken);
    }
}