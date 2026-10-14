using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace p4
{
    public partial class EVENT : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlSuccess.Visible = false;
            }
        }

        protected void cvFile_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = fuStudentDoc.HasFile;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string fileName = string.Empty;

            if (fuStudentDoc.HasFile)
            {
                string extension = Path.GetExtension(fuStudentDoc.FileName).ToLowerInvariant();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };

                if (Array.IndexOf(allowedExtensions, extension) < 0)
                {
                    pnlSuccess.Visible = true;
                    pnlSuccess.CssClass = "error";
                    litConfirmation.Text = "Invalid file type. Only JPG, PNG, and PDF files are allowed.";
                    return;
                }

                try
                {
                    string uploadFolder = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(uploadFolder))
                        Directory.CreateDirectory(uploadFolder);

                    fileName = Path.GetFileName(fuStudentDoc.FileName);
                    string savePath = Path.Combine(uploadFolder, fileName);
                    fuStudentDoc.SaveAs(savePath);
                }
                catch (Exception)
                {
                    pnlSuccess.Visible = true;
                    pnlSuccess.CssClass = "error";
                    litConfirmation.Text = "File upload failed. Please check the Uploads folder permissions and try again.";
                    return;
                }
            }

            StringBuilder confirmation = new StringBuilder();
            confirmation.AppendFormat("<p><strong>Name:</strong> {0}</p>", Server.HtmlEncode(txtName.Text.Trim()));
            confirmation.AppendFormat("<p><strong>Email:</strong> {0}</p>", Server.HtmlEncode(txtEmail.Text.Trim()));
            confirmation.AppendFormat("<p><strong>Mobile No:</strong> {0}</p>", Server.HtmlEncode(txtMobile.Text.Trim()));
            confirmation.AppendFormat("<p><strong>Date of Birth:</strong> {0}</p>", Server.HtmlEncode(txtDOB.Text));
            confirmation.AppendFormat("<p><strong>Gender:</strong> {0}</p>", Server.HtmlEncode(rblGender.SelectedValue));
            confirmation.AppendFormat("<p><strong>College Name:</strong> {0}</p>", Server.HtmlEncode(txtCollege.Text.Trim()));
            confirmation.AppendFormat("<p><strong>Branch:</strong> {0}</p>", Server.HtmlEncode(ddlBranch.SelectedValue));
            confirmation.AppendFormat("<p><strong>City:</strong> {0}</p>", Server.HtmlEncode(txtCity.Text.Trim()));
            confirmation.AppendFormat("<p><strong>Pass Type:</strong> {0}</p>", Server.HtmlEncode(ddlPassType.SelectedValue));
            confirmation.AppendFormat("<p><strong>Uploaded File:</strong> {0}</p>", Server.HtmlEncode(fileName));

            litConfirmation.Text = confirmation.ToString();
            pnlSuccess.Visible = true;
            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtDOB.Text = string.Empty;
            rblGender.ClearSelection();
            txtCollege.Text = string.Empty;
            ddlBranch.SelectedIndex = 0;
            txtCity.Text = string.Empty;
            ddlPassType.SelectedIndex = 0;
        }
    }
}
