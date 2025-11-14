# CarCollection

Hey! This is my little ASP.NET Core MVC project.  
It’s basically a car collection app where you can see car brands and their models.  

---

## What it does

- Lets you view car brands and models.  
- You can add, edit, delete brands/models **if you’re logged in**.  
- Local login with email/password.  
- Google login (social authentication).  
- Index pages can be seen by anyone, but you can’t change anything if you’re not logged in.  
- I also added a simple theme with a nice font and some colors to make it look professional.  

---

## Instructor Account

To check the site, use:

- **Email:** `rich@gc.ca`  
- **Password:** `Test123$`

This account is automatically added when the app runs (see `SeedData.cs`).  

---

## How to run it locally

1. Clone the repo:

2. Update the connection string in `appsettings.json` (or set it as environment variable).  

3. Add your Google OAuth keys to `appsettings.json`:

```json
"Authentication": {
  "Google": {
    "ClientId": "<your-client-id>",
    "ClientSecret": "<your-client-secret>"
  }
}

4.run migrations:
dotnet ef database update

5.run the app:
dotnet run

