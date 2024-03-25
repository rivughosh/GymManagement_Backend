using GymManagementWebAPI.BLL.DTOs.Responses;
using GymManagementWebAPI.DAL.DBContext;
using GymManagementWebAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace GymManagementWebAPI.DAL.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude);
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition);
    }
    public abstract class RepositoryBase<T> : IBaseRepository<T> where T : class
    {
        private readonly GymDBContext dbContext;
        private readonly DbSet<T> dbSet;

        public RepositoryBase(GymDBContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            var result = await this.dbSet.AddAsync(entity);
            return result.Entity;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            var result = this.dbSet.Remove(entity);
            return Task.FromResult(result.Entity is not null);
        }

        //----------------------------- made the method generic ---------------------------------//
        public async Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude)
        {
            IQueryable<T> query = this.dbSet;
            if (navsToInclude.Length > 0)
            {
                foreach (var item in navsToInclude)
                {
                    query = query.Include(item);
                }
            }
            var result = query.AsEnumerable();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            var result = this.dbSet.Where(condition);
            return await Task.FromResult(result.AsEnumerable());
        }

        public async Task<T?> GetById(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public Task<T> UpdateAsync(T entity)
        {
            var result = this.dbSet.Update(entity);
            return Task.FromResult(result.Entity);
        }
    }
    public interface IGymWalletRepository : IBaseRepository<GymWallet> 
    {
        IEnumerable<GymWallet?> GetGymWalletByMemberId(int id);
        GymWallet? GetGymWalletByMemberIdforPackage(int id);
    }

    public class GymWalletRepository : RepositoryBase<GymWallet>, IGymWalletRepository
    {
        private readonly GymDBContext dbContext;
        public GymWalletRepository(GymDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<GymWallet?> GetGymWalletByMemberId(int id)
        {
            var MembersWallet = dbContext.GymWallets.Include(x => x.Member).Include(x => x.Package).Where(x => x.MemberId == id).AsEnumerable();
            return MembersWallet;
        }


        public GymWallet? GetGymWalletByMemberIdforPackage(int id)
        {
            var MembersWallet = dbContext.GymWallets.Include(x => x.Member).Include(x => x.Package).OrderBy(x => x.MemberId).LastOrDefault(x => x.MemberId == id);
            return MembersWallet;
        }

    }
    public interface IMemberRepository : IBaseRepository<Member> 
    {
        Task<Member?> GetByIdWithTrainer(int id);
        Task<Member?> ValidateUser(string userId, string Password);
    }

    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        private readonly GymDBContext dbContext;
        public MemberRepository(GymDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Member?> GetByIdWithTrainer(int id)
            {
                var member = await dbContext.Members.Include(x=>x.Trainer).SingleOrDefaultAsync(x=>x.Id == id);
                return member;
            }

        public async Task<Member?> ValidateUser(string userId, string Password)
        {
            var result = await dbContext.Members.FirstOrDefaultAsync(x => x.UserId == userId && x.PasswordHash == Password);
            if (result != null)
            {
                return result;
            }
            return null;
        }

    }

    public interface IPackageRepository : IBaseRepository<Package> { }

    public class PackageRepository : RepositoryBase<Package>, IPackageRepository
    {
        public PackageRepository(GymDBContext dbContext) : base(dbContext)
        {
        }
    }
    public interface ITrainerRepository : IBaseRepository<Trainer> { }

    public class TrainerRepository : RepositoryBase<Trainer>, ITrainerRepository
    {
        public TrainerRepository(GymDBContext dbContext) : base(dbContext)
        {
        }
    }
    public interface IRepositoryWrapper
    {
        public IGymWalletRepository GymWalletRepository { get; set; }
        public IMemberRepository MemberRepository { get; set; }
        public IPackageRepository PackageRepository { get; set; }
        public ITrainerRepository TrainerRepository { get; set; }

        Task<int> SaveAsync();
    }
    //-----------------------------Make properties of every entities here-----------------------------------//
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly GymDBContext dbContext = null!;
        public IGymWalletRepository GymWalletRepository { get; set; } = null!;
        public IMemberRepository MemberRepository { get; set; } = null!;
        public IPackageRepository PackageRepository { get; set; } = null!;
        public ITrainerRepository TrainerRepository { get; set; } = null!;

        public RepositoryWrapper(GymDBContext dbContext)
        {
            this.dbContext = dbContext;
            GymWalletRepository = new GymWalletRepository(dbContext);
            MemberRepository = new MemberRepository(dbContext);
            PackageRepository = new PackageRepository(dbContext);
            TrainerRepository = new TrainerRepository(dbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }
    }

}

