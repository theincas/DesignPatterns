using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.Template.Abstracts;
using WebApp.Template.Models;
using WebApp.Template.UserCards;

namespace WebApp.Template.TagHelpers
{
    //each properties transform attributes
    public class UserCardTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserCardTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public AppUser AppUser { get; set; }

        //know how the new tag assistant will work
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplateBase userCardTemplate;
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                userCardTemplate = new MemberUserCardTemplate();
            }
            else
            {
                userCardTemplate = new DefaultCardTemplate();
            }

            userCardTemplate.SetUser(AppUser);

            output.Content.SetHtmlContent(userCardTemplate.Build());
        }
    }
}
