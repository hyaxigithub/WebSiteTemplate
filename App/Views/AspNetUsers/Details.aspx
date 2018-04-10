<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Details.Master"Inherits="System.Web.Mvc.ViewPage<DAL.AspNetUsers>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 AspNetUsers
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input class="a2 f2" type="button"  onclick="window.location.href = 'javascript:history.go(-1)';"  value="返回" />   
        </legend>
        <div class="bigdiv">
            
                <br style="clear: both;" />
                <div class="display-label">
                    <%: Html.LabelFor(model => model.Email) %>：
                </div>
                <div class="textarea-box">
                    <%: Html.TextAreaFor(model => model.Email, new {  @readonly=true}) %>                  
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.EmailConfirmed) %>：
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.EmailConfirmed) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.PasswordHash) %>：
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.PasswordHash) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.SecurityStamp) %>：
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.SecurityStamp) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.PhoneNumber) %>：
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.PhoneNumber) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.PhoneNumberConfirmed) %>：
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.PhoneNumberConfirmed) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.TwoFactorEnabled) %>：
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.TwoFactorEnabled) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.LockoutEndDateUtc) %>：
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.LockoutEndDateUtc) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.LockoutEnabled) %>：
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.LockoutEnabled) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.AccessFailedCount) %>：
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.AccessFailedCount) %>
                </div>    
                <div class="display-label">
                      <%: Html.LabelFor(model => model.AspNetRolesId) %>：
                </div>
                <div class="display-field">            
                    <% string ids13 = string.Empty;
                       foreach (var item13 in Model.AspNetRoles)
                       {
                           ids13 += item13.Name;
                           ids13 += " , ";
                    %>               
                    <%}%>
                    
                <%= ids13 %>   
                  
                </div>
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
 
</asp:Content>

