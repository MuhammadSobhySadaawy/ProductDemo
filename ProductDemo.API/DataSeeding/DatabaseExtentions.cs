using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductDemo.Domain.Entities;
using ProductDemo.Infrastructure.Data.Db;

namespace DistributedSystems.PurchaseOrder.DataSeeding
{
    public static class DatabaseExtentions
    {
        public static async Task AutoMigrateDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (app.Configuration.GetSection("EnableAutoMigration").Value == "1")
            {
                try
                {
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Migration failed: {ex.Message}");
                }
            }
            await SeedAsync(app);
        }

        private static async Task SeedAsync(WebApplication app)
        {
            try
            {
                await SeedUsersAsync(app);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Seeding failed: {ex.Message}");
            }
        }

        private static async Task SeedUsersAsync(WebApplication app)
        {
            //try
            //{
            //    using var scope = app.Services.CreateScope();
            //    var serviceProvider = scope.ServiceProvider;

            //    var umbracoContext = serviceProvider.GetRequiredService<MOTA1umbracoDbContext>();
            //    var identityContext = serviceProvider.GetRequiredService<EAGPServeBigDbContext>();
            //    var passwordHasher = new UmbracoPasswordHasher<AspNetUser>();

            //    identityContext.ChangeTracker.AutoDetectChangesEnabled = false;

            //    var umbracoUsers = await umbracoContext.Set<CmsMember>()
            //        .AsNoTracking()
            //        .ToListAsync();

            //    Console.WriteLine($"✅ {umbracoUsers.Count} users fetched.");

            //    var existingUserNames = await identityContext.AspNetUsers
            //       .AsNoTracking()
            //       .Select(u => u.UserName)
            //       .ToListAsync();

            //    var newUsers = new List<AspNetUser>();

            //    foreach (var umbracoUser in umbracoUsers)
            //    {
            //        if (existingUserNames.Contains(umbracoUser.LoginName))
            //        {
            //            Console.WriteLine($"⚠️ Skipping duplicate user: {umbracoUser.LoginName}");
            //            continue;
            //        }

            //        var newUser = new AspNetUser
            //        {
            //            Id = Guid.NewGuid().ToString(),
            //            UserName = umbracoUser.LoginName,
            //            Email = umbracoUser.Email,
            //            NormalizedUserName = umbracoUser.LoginName.ToUpper(),
            //            NormalizedEmail = umbracoUser.Email.ToUpper(),
            //            EmailConfirmed = umbracoUser.EmailConfirmedDate.HasValue,
            //            SecurityStamp = umbracoUser.SecurityStampToken ?? Guid.NewGuid().ToString(),
            //            PhoneNumberConfirmed = false,
            //            TwoFactorEnabled = false,
            //            LockoutEnabled = true,
            //            AccessFailedCount = umbracoUser.FailedPasswordAttempts ?? 0,
            //            LockoutEnd = umbracoUser.IsLockedOut ? DateTime.UtcNow.AddYears(100) : null,
            //            IsBlocked = umbracoUser.IsLockedOut,
            //            CreatedAt = DateTime.UtcNow,
            //            LastLoginDate = umbracoUser.LastLoginDate
            //        };

            //        newUser.PasswordHash = passwordHasher.HashPassword(newUser, umbracoUser.Password);
            //        newUsers.Add(newUser);
            //    }

            //    if (newUsers.Any())
            //    {
            //        int batchSize = 10000;
            //        Console.WriteLine("🚀 Inserting users in batches...");

            //        for (int i = 0; i < newUsers.Count; i += batchSize)
            //        {
            //            var batch = newUsers.Skip(i).Take(batchSize).ToList();
            //            await identityContext.BulkInsertAsync(batch);
            //            Console.WriteLine($"✅ Inserted {i + batch.Count} / {newUsers.Count}");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("⚠️ No new users to insert. All users already exist.");
            //    }

            //    identityContext.ChangeTracker.AutoDetectChangesEnabled = true;
            //    Console.WriteLine("🎉 User migration completed successfully!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"❌ User seeding failed: {ex.Message}");
            //}
        }
    }
}
