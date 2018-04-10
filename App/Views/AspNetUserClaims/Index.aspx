<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Index.Master" Inherits="System.Web.Mvc.ViewPage<DAL.AspNetUserClaims>" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AspNetUserClaims
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divQuery">
        
    </div>
    <div class="left03">
        <input class="a4" type="button" value="查 询" onclick="flexiQuery()" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script type="text/javascript" language="javascript">
        $(function () {

            $('#flexigridData').datagrid({
                title: 'AspNetUserClaims', //列表的标题
                iconCls: 'icon-site',
                width: 'auto',
                height: 'auto',
                nowrap: false,
                striped: true,
                collapsible: true,
                url: '../AspNetUserClaims/GetData', //获取数据的url
                sortName: 'Id',
                sortOrder: 'desc',
                idField: 'Id',

                toolbar: [
                 
                     {
                        text: '详细',
                        iconCls: 'icon-search',
                        handler: function () {
                            return getView();
                        }
                    }, {
                        text: '创建',
                        iconCls: 'icon-add',
                        handler: function () {
                            return flexiCreate();
                        }
                    },  {
                        text: '删除',
                        iconCls: 'icon-remove',
                        handler: function () {
                            return flexiDelete();
                        }
                    }, {
                        text: '修改',
                        iconCls: 'icon-edit',
                        handler: function () {
                            return flexiModify();
                        }
                    } ],
                columns: [[
                   
                    
					{ field: 'ClaimType', title: '<%: Html.LabelFor(model => model.ClaimType) %>', width: 339 }
					,{ field: 'ClaimValue', title:  '<%: Html.LabelFor(model => model.ClaimValue) %>', width: 339 }
                ]],
                pagination: true,
                rownumbers: true

            });

             var parent = window.dialogArguments; //获取父页面
            if (parent == "undefined" || parent == null) {
                //    不是在iframe中打开的
            } else {
                //隐藏所有的按钮和分隔符
                $(".l-btn.l-btn-plain").hide();
                $(".datagrid-btn-separator").hide();
                //添加选择按钮
                $('#flexigridData').datagrid("addToolbarItem", [{ "text": "选择", "iconCls": "icon-ok", handler: function () { flexiSelect(); } }]);
            }
        });

        //“查询”按钮，弹出查询框
        function flexiQuery() {

            //将查询条件按照分隔符拼接成字符串
            var search = "";
            $('#divQuery').find(":text,:selected,select,textarea,:hidden,:checked,:password").each(function () {
                search = search + this.id + "&" + this.value + "^";
            });
            //执行查询                        
            $('#flexigridData').datagrid('reload', { search: search });

        };

        //“选择”按钮，在其他（与此页面有关联）的页面中，此页面以弹出框的形式出现，选择页面中的数据
        function flexiSelect() {

            var rows = $('#flexigridData').datagrid('getSelections');
            if (rows.length == 0) {
                $.messager.alert('操作提示', '请选择数据!', 'warning');
                return false;
            }

            var arr = [];
            for (var i = 0; i < rows.length; i++) {
                arr.push(rows[i].Id);
            }
            arr.push("^");
            for (var i = 0; i < rows.length; i++) {
                arr.push(rows[i].UserId);
            }
            //主键列和显示列之间用 ^ 分割   每一项用 , 分割
            if (arr.length > 0) {//一条数据和多于一条
                returnParent(arr.join("&")); //每一项用 & 分割
            }
        }
        //导航到查看详细的按钮
        function getView() {

            var arr = $('#flexigridData').datagrid('getSelections');

            if (arr.length == 1) {
                window.location.href = "../AspNetUserClaims/Details/" + arr[0].Id;
               
            } else {
                $.messager.alert('操作提示', '请选择一条数据!', 'warning');
            }
            return false;
        }
        //导航到创建的按钮
        function flexiCreate() {

            window.location.href = "../AspNetUserClaims/Create";
            return false;
        }
        //导航到修改的按钮
        function flexiModify() {

            var arr = $('#flexigridData').datagrid('getSelections');

            if (arr.length == 1) {
                window.location.href = "../AspNetUserClaims/Edit/" + arr[0].Id;

            } else {
                $.messager.alert('操作提示', '请选择一条数据!', 'warning');
            }
            return false;

        };
        //删除的按钮
        function flexiDelete() {

            var rows = $('#flexigridData').datagrid('getSelections');
            if (rows.length == 0) {
                $.messager.alert('操作提示', '请选择数据!', 'warning');
                return false;
            }

            var arr = [];
            for (var i = 0; i < rows.length; i++) {
                arr.push(rows[i].Id);
            }

            $.messager.confirm('操作提示', "确认删除这 " + arr.length + " 项吗？", function (r) {
                if (r) {
                    $.post("../AspNetUserClaims/Delete", { query: arr.join(",") }, function (res) {
                        if (res == "OK") {
                           //移除删除的数据

                            $.messager.alert('操作提示', '删除成功!', 'info');
                            $("#flexigridData").datagrid("reload");
                            $("#flexigridData").datagrid("clearSelections");
                        }
                        else {
                            if (res == "") {
                                $.messager.alert('操作提示', '删除失败!请查看该数据与其他模块下的信息的关联，或联系管理员。', 'info');
                            }
                            else {
                               $.messager.alert('操作提示', res, 'info');
                            }
                        }
                    });
                }
            });

        };

    </script>
</asp:Content>

