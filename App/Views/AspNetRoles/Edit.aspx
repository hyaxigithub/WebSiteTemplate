<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.AspNetRoles>" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="Models" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
    修改 AspNetRoles
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>
            <input class="a2 f2" type="submit" value="修改" />
            <input class="a2 f2" type="button" onclick="BackList('AspNetRoles')" value="返回列表" />
        </legend>
        <div class="bigdiv">
            <%: Html.HiddenFor(model => model.Id ) %><%: Html.HiddenFor(model => model.Name ) %>  
        <div class="editor-label">
            <a class="anUnderLine" onclick="showModalMany('AspNetUsersId','../../AspNetUsers');">
                <%: Html.LabelFor(model => model.AspNetUsersId) %>
            </a>：
        </div>
        <div class="editor-field">
            <div id="checkAspNetUsersId">
                <% string ids3 = string.Empty;
                if(Model!=null)
                {
                   foreach (var item3 in Model.AspNetUsers)
                   {
                       string item31 = string.Empty;
                       item31 += item3.Id + "&" + item3.Email;
                       if (ids3.Length > 0)
                       {
                           ids3 += "^" + item31;
                       }
                       else
                       {
                           ids3 += item31;
                       }
                %>
                <table id="<%: item31 %>"
                    class="deleteStyle">
                    <tr>
                        <td>
                            <img  alt="删除" title="点击删除" onclick="deleteTable('<%: item31 %>','AspNetUsersId');"  src="../../../Images/deleteimge.png" />
                        </td>
                        <td>
                            <%: item3.Email %>
                        </td>
                    </tr>
                </table>
                <%}}%>
                <input type="hidden" value="<%= ids3 %>" name="AspNetUsersIdOld" id="AspNetUsersIdOld" />
                <input type="hidden" value="<%= ids3 %>" name="AspNetUsersId" id="AspNetUsersId" />
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

