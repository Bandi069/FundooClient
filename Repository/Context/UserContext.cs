
namespace Repository.Context
{
    using Microsoft.EntityFrameworkCore;
    
    using Model.Collaborators;
    using Model.LabelModels;
    using Model.NoteModel;
    using Model.UserModel;

    /// <summary>
    /// UserContext class is used to get connected with the database
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class UserContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext"/> class.
        /// </summary>
        /// <param name="contextOptions">The context options.</param>
        public UserContext(DbContextOptions<UserContext> contextOptions) : base(contextOptions)
        {
                
        }
        public DbSet<RegisterModel> Accountregister { get; set; }
         
        public DbSet<NoteModel> Notes { get; set; }
       
        public DbSet<LabelModel> Labels { get; set; }
        
        public DbSet<Collaborator> Collaborators { get; set; }
    }
}