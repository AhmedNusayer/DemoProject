using EntityProject;

namespace InfrastructureProject.Data
{
    public class ProfilePictureRepository : GenericRepository<ProfilePicture>
    {
        public ProfilePictureRepository(AppDbContext context) : base(context)
        {
        }
    }
}
