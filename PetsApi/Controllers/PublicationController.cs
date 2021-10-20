using PetsApi.Interfaces;

namespace PetsApi.Controllers
{
  public class PublicationController
  {
    private readonly IPublicationRepository publications;

    public PublicationController(IPublicationRepository publicationRepository)
    {
      this.publications = publicationRepository;
    }
  }
}