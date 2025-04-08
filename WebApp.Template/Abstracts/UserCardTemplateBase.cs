using System.Text;
using WebApp.Template.Models;

namespace WebApp.Template.Abstracts
{
    public abstract class UserCardTemplateBase
    {
        protected AppUser appUser { get; set; }
        public void SetUser(AppUser appUser)
        {
            this.appUser = appUser;
        }
        public string Build()
        {
            if (appUser == null)
                throw new ArgumentException(nameof(appUser));

            var sb = new StringBuilder();

            sb.Append("<div class='card'>");
            sb.Append(SetPicture());
            sb.Append($@"<div class='card-body'>
                      <h5>{appUser.UserName}</h5>
                      <p>{appUser.Description}</p>");
            sb.Append(SetFooter());
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }

        protected abstract string SetFooter();
        protected abstract string SetPicture();
    }
}
