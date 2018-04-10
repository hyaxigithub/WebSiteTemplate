<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Details.Master"Inherits="System.Web.Mvc.ViewPage<DAL.AspNetRoles>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 AspNetRoles
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input class="a2 f2" type="button"  onclick="window.location.href = 'javascript:history.go(-1)';"  value="返回" />   
        </legend>
        <div class="bigdiv">
                
                <div class="display-label">
                      <%: Html.LabelFor(model => model.AspNetUsersId) %>：
                </div>
                <div class="display-field">            
                    <% string ids3 = string.Empty;
                       foreach (var item3 in Model.AspNetUsers)
                       {
                           ids3 += item3.Email;
                           ids3 += " , ";
                    %>               
                    <%}%>
                    
                <%= ids3 %>   
                  
                </div>
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
 
</asp:Content>

