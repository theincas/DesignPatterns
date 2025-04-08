using System.Text;
using WebApp.Template.Abstracts;

namespace WebApp.Template.UserCards
{
    public class MemberUserCardTemplate : UserCardTemplateBase
    {
        protected override string SetFooter()
        {
            var sb = new StringBuilder();
            sb.Append("<a href='#' class='card-link'>Mesaj Gönder></a>");
            sb.Append("<a href='#' class='card-link'>Detaylı Profil></a>");
            return sb.ToString();
        }

        protected override string SetPicture()
        {
            return $"<img src='{appUser.PictureUrl}' class='card-img-top'></img>";
        }
    }
}
