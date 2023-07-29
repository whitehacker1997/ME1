using Global.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace Global.EF
{
    public class BaseDbContext :
        DbContext
    {
        private IAuthService _authService;
        public EfConfig Config { get; private set; }

        public BaseDbContext()
        {
        }

        public BaseDbContext([NotNull] DbContextOptions options,
                             EfConfig config)
            : base(options)
        {
            Config = config;
        }

        public BaseDbContext([NotNull] DbContextOptions options)
            : this(options,
                   new EfConfig())
        {
        }

        public void SetAuthService(IAuthService authService)
        {
            _authService = authService;
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (Config.AutoSetProperties.Enabled)
                SetDefaultProperties();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            if (Config.AutoSetProperties.Enabled)
                SetDefaultProperties();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void SetDefaultProperties()
        {
            Dictionary<string, PropertyEntry> propertyEntryDict = null;

            foreach (EntityEntry entityEntry in ChangeTracker.Entries())
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:

                        propertyEntryDict = entityEntry.Properties.ToDictionary((PropertyEntry k) 
                            => k.Metadata.Name);

                        if (Config.AutoSetProperties.CreatedAt.Enabled &&
                            propertyEntryDict.ContainsKey(Config.AutoSetProperties.CreatedAt.PropertyName))
                        {
                            PropertyEntry propertyEntry3 
                                = propertyEntryDict[Config.AutoSetProperties.CreatedAt.PropertyName];

                            propertyEntry3.IsModified = false;
                            propertyEntry3.CurrentValue = DateTime.Now;
                        }

                        if (Config.AutoSetProperties.CreatedBy.Enabled &&
                            propertyEntryDict.ContainsKey(Config.AutoSetProperties.CreatedBy.PropertyName) &&
                            _authService != null)
                        {
                            PropertyEntry propertyEntry4 
                                = propertyEntryDict[Config.AutoSetProperties.CreatedBy.PropertyName];

                            propertyEntry4.IsModified = false;
                            propertyEntry4.CurrentValue = _authService.UserId;
                        }

                        if (Config.AutoSetProperties.StateId.Enabled &&
                            propertyEntryDict.ContainsKey(Config.AutoSetProperties.StateId.PropertyName))
                        {
                            PropertyEntry propertyEntry5 
                                = propertyEntryDict[Config.AutoSetProperties.StateId.PropertyName];

                            propertyEntry5.IsModified = false;
                            propertyEntry5.CurrentValue = StateIdConst.ACTIVE;
                        }

                        propertyEntryDict.Clear();
                        break;

                    case EntityState.Modified:

                        propertyEntryDict = entityEntry.Properties.ToDictionary((PropertyEntry k) 
                                                                        => k.Metadata.Name);

                        if (Config.AutoSetProperties.ModifiedAt.Enabled &&
                            propertyEntryDict.ContainsKey(Config.AutoSetProperties.ModifiedAt.PropertyName))
                        {
                            PropertyEntry propertyEntry 
                                = propertyEntryDict[Config.AutoSetProperties.ModifiedAt.PropertyName];

                            propertyEntry.IsModified = false;
                            propertyEntry.CurrentValue = DateTime.Now;
                        }

                        if (Config.AutoSetProperties.ModifiedBy.Enabled &&
                            propertyEntryDict.ContainsKey(Config.AutoSetProperties.ModifiedBy.PropertyName) &&
                            _authService != null)
                        {
                            PropertyEntry propertyEntry2 
                                = propertyEntryDict[Config.AutoSetProperties.ModifiedBy.PropertyName];

                            propertyEntry2.IsModified = false;
                            propertyEntry2.CurrentValue = _authService.UserId;
                        }

                        propertyEntryDict.Clear();
                        break;
                }
            }
        }
    }
}
