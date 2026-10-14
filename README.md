# Online Event Registration Portal

**Subject:** 01CE1523 – .NET Technologies  
**Aim:** Build an Online Event Registration Portal using ASP.NET controls and validation.

## Files
- `Event.aspx` — registration form UI, ASP.NET Web Forms controls, and validators.
- `Event.aspx.cs` — server-side validation, file upload handling, confirmation, and form reset.
- `Web.config` — ASP.NET configuration for .NET Framework 4.7.2.
- `Uploads/` — uploaded JPG, JPEG, PNG, and PDF documents are saved here when the app runs.

## Features
- Name, email, mobile number, date of birth, gender, college, branch, city, and pass type fields.
- Required-field and format validation.
- Student ID/photo upload validation (JPG, JPEG, PNG, PDF).
- Registration confirmation panel.

## Run locally
1. Open Visual Studio.
2. Create an **ASP.NET Web Application (.NET Framework)** project using **Web Forms** and target **.NET Framework 4.7.2**.
3. Use the project namespace `p4`, or update the `Inherits` value in `Event.aspx` and the namespace in `Event.aspx.cs` to match your project.
4. Add `Event.aspx`, `Event.aspx.cs`, and `Web.config` to the project. Ensure the page is configured as a Web Form with its code-behind.
5. Run the project and open `Event.aspx`.

> This is an ASP.NET Web Forms / .NET Framework project, not a static website. GitHub Pages cannot execute ASP.NET server-side code; run it locally in Visual Studio/IIS or deploy it to a compatible Windows/IIS host.
