using Infrastructure.EFCore;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Abstract;
using Infrastructure.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }
}
