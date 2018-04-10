<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.AspNetUserLogins>" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="Models" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
    修改 AspNetUserLogins
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>
            <input class="a2 f2" type="submit" value="修改" />
            <input class="a2 f2" type="button" onclick="BackList('AspNetUserLogins')" value="返回列表" />
        </legend>
        <div class="bigdiv">
            <%: Html.HiddenFor(model => model.LoginProvider ) %><%: Html.HiddenFor(model => model.ProviderKey ) %><%: Html.HiddenFor(model => model.UserId ) %>
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script type="text/javascript">

        $(function () {
            

        });
              

    </script>
</asp:Content>

