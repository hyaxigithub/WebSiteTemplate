<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Create.Master" Inherits="System.Web.Mvc.ViewPage<DAL.AspNetUsers>" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CurentPlace" runat="server">
      创建 AspNetUsers
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>
            <input class="a2 f2" type="submit" value="创建" />
            <input class="a2 f2" type="button" onclick="BackList('AspNetUsers')" value="返回" />
        </legend>
        <div class="bigdiv">
            
            <br style="clear: both;" />
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>：
            </div>
            <div class="textarea-box">
                <%: Html.TextAreaFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EmailConfirmed) %>：
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.EmailConfirmed) %>
                <%: Html.ValidationMessageFor(model => model.EmailConfirmed) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PasswordHash) %>：
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PasswordHash) %>
                <%: Html.ValidationMessageFor(model => model.PasswordHash) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SecurityStamp) %>：
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.SecurityStamp) %>
                <%: Html.ValidationMessageFor(model => model.SecurityStamp) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumber) %>：
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PhoneNumber) %>
                <%: Html.ValidationMessageFor(model => model.PhoneNumber) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumberConfirmed) %>：
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PhoneNumberConfirmed) %>
                <%: Html.ValidationMessageFor(model => model.PhoneNumberConfirmed) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TwoFactorEnabled) %>：
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.TwoFactorEnabled) %>
                <%: Html.ValidationMessageFor(model => model.TwoFactorEnabled) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LockoutEndDateUtc) %>：
            </div>
            <div class="editor-field">
                <%: Html.TextBox("LockoutEndDateUtc", ((Model != null && Model.LockoutEndDateUtc != null) ? Model.LockoutEndDateUtc.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { style = "width: 214px;", @class="easyui-datebox" })%>
                <%: Html.ValidationMessageFor(model => model.LockoutEndDateUtc) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LockoutEnabled) %>：
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.LockoutEnabled) %>
                <%: Html.ValidationMessageFor(model => model.LockoutEnabled) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AccessFailedCount) %>：
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AccessFailedCount, new {  onkeyup = "isInt(this)", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.AccessFailedCount) %>
            </div>   <div class="editor-label">
            <a class="anUnderLine" onclick="showModalMany('AspNetRolesId','../../AspNetRoles');">
                <%: Html.LabelFor(model => model.AspNetRolesId) %>
            </a>：
        </div>
        <div class="editor-field">
            <div id="checkAspNetRolesId">
                <% 
                if (Model != null && !string.IsNullOrWhiteSpace(Model.AspNetRolesId))
                {
                   foreach (var item13 in Model.AspNetRolesId.Split('^'))
                   {
                        string[] it = item13.Split('&');
                        if (it != null && it.Length == 2 && !string.IsNullOrWhiteSpace(it[0]) && !string.IsNullOrWhiteSpace(it[1]))
                        {                        
                %>
                <table id="<%: item13 %>"
                    class="deleteStyle">
                    <tr>
                        <td>
                            <img  alt="删除" title="点击删除" onclick="deleteTable('<%: item13  %>','AspNetRolesId');"  src="../../../Images/deleteimge.png" />
                        </td>
                        <td>
                            <%: it[1] %>
                        </td>
                    </tr>
                </table>
                <%}}}%>
               <%: Html.HiddenFor(model => model.AspNetRolesId) %>
            </div>
        </div>
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script type="text/javascript">

        $(function () {
            

        });
              

    </script>
</asp:Content>

