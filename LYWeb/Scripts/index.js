//判断是否手持设备
function isPC() {
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) > 0) {
            flag = false;
            break;
        }
    }
    return flag;
}
var dialogWidth = isPC() ? "80%" : "100%";
var dialogHeight = isPC() ? "80%" : "100%";

function writeWorkLog() {
    var date = new Date().getFullYear() + "-" + (new Date().getMonth() + 1) + "-" + new Date().getDate();
    layer.open({
        type: 2,
        title: '添加日志',
        shadeClose: false,
        shade: 0.8,
        area: [dialogWidth, dialogHeight],
        content: 'Daily_Record/daily_record_add.aspx?date=' + date//iframe的url
    });
}
function openDialog(title,url) {
    layer.open({
        type: 2,
        title: title,
        shadeClose: false,
        shade: 0.8,
        area: [dialogWidth, dialogHeight],
        content: url//iframe的url
    });
}
function edit(title,url) {
    openDialog(title, url);
    return false;
}
function closeDialog() {
    layer.closeAll();
}

//删除确认
function delConfirm(id) {
    var HTML = "<div class='box no-border' style='width:100%;height:100%;'>";
    HTML += '您确定要删除ID为<span style="color:red"> ' + id + ' </span>的记录吗?<br/>请注意，记录一经删除则不可恢复！';
    HTML += '<div id="loading" class="overlay hidden"> <i class="fa fa-refresh fa-spin"></i></div>';
    HTML += "</div>";

    BootstrapDialog.show({
        title: '系统提示',
        message: $(HTML),
        tabindex: 999,
        buttons: [{
            label: '确认',
            action: function (dialog) {
                $("#loading").removeClass("hidden");
                dialog.close();
                //提交到本页面删除数据
                $.ajax({
                    async: false,//异步
                    type: "get",
                    url: "Del",
                    data: { 'id': id },
                    success: function (data) {
                        $("#loading").addClass("hidden");
                        var json = data;
                        if (typeof json == "string")
                            json = eval("(" + data + ")");//转换为json对象
                        msg(json.message);
                        var h = location.href;
                        if (h.indexOf("_oa_article") > 0) {
                            setTimeout('location.href = "MyList"', 1500);
                        } else {
                            setTimeout('location.href = "List"', 1500);
                        }
                    },
                    error: function () {
                        $("#loading").addClass("hidden");
                        alert('出错了，请检查网络');
                    }
                });
            }
        }, {
            label: '取消',
            action: function (dialog) {
                dialog.close();
            }
        }]
    });
}

//简易的弹窗
function msg(content) {

    BootstrapDialog.alert({
        title: '系统提示',
        draggable: true,
        message: content,
        buttons: [{
            label: '确认',
            action: function (dialog) {
                dialog.close();
            }
        }]
    });
}