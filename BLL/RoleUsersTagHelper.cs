
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualFair.Models;


namespace VirtualFair.BLL
{
    [HtmlTargetElement("td",Attributes="identity-role")]
    public class RoleUsersTagHelper:TagHelper
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _identityRole;
        public RoleUsersTagHelper(UserManager<User> userManager, RoleManager<IdentityRole> identityRole)
        {
            _userManager = userManager;
            _identityRole = identityRole;
        }

        [HtmlAttributeName("identity-role")]
        public string Role { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> Names = new List<string>();
            var role = await _identityRole.FindByIdAsync(Role);

            if (role != null)
            {
                foreach(var user in _userManager.Users)
                {
                    if (user != null && await _userManager.IsInRoleAsync(user, role.Name)) Names.Add(user.UserName);
                       }
            }
            output.Content.SetContent(Names.Count == 0 ?
                "Kullanıcı Yok" :
                string.Join(", ", Names));
        }
    }
}
