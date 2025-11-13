
using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task CreateInstructorAccountAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var email = "rich@gc.ca";
        var password = "Test123$";

        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            var newUser = new IdentityUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(newUser, password);
            if (!result.Succeeded)
            {
                var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger("SeedData");
                foreach (var e in result.Errors)
                {
                    logger.LogWarning("Seed user creation error: {Code} - {Desc}", e.Code, e.Description);
                }
            }
        }
    }
}