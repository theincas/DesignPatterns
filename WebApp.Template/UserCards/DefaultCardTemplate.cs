using WebApp.Template.Abstracts;

namespace WebApp.Template.UserCards
{
    public class DefaultCardTemplate : UserCardTemplateBase
    {
        protected override string SetFooter()
        {
            return string.Empty;
        }

        protected override string SetPicture()
        {
            return $"<img src='/userpictures/nonmember.png' class='card-img-top'></img>";
        }
    }
}
