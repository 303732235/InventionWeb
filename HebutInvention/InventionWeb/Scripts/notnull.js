function notnull() {
    var title = document.getElementById("TxtTitle").value;
    var writer = document.getElementById("txtWriter").value;

    if (title == "") {
        alert("请填写标题！");
        document.getElementById('TxtTitle').focus();
        return false;
    }
    if (writer == "") {
        alert("请填写作者！");
        document.getElementById('txtWriter').focus();
        return false;
    }
    return true;
}
function ImageAdmin() {
    var title = document.getElementById("TxtTitle").value;
    var writer = document.getElementById("txtWriter").value;
    var fileup = document.getElementById("FileUp").value;
    if (title == "") {
        alert("请填写标题！");
        document.getElementById('TxtTitle').focus();
        return false;
    }
    if (writer == "") {
        alert("请填写作者！");
        document.getElementById('txtWriter').focus();
        return false;
    }
    if (fileup == "") {
        alert("上传的为空！");
        document.getElementById('FileUp').focus();
        return false;
    }
    return true;
}
function workdtnull() {
    var title = document.getElementById("TxtTitle").value;
    var writer = document.getElementById("TxtWriter").value;
    var fileup = document.getElementById("FileUp").value;
    if (title == "") {
        alert("请填写标题！");
        document.getElementById('TxtTitle').focus();
        return false;
    }
    if (writer == "") {
        alert("请填写作者！");
        document.getElementById('TxtWriter').focus();
        return false;
    }
    if (fileup == "") {
        alert("上传图片不为空！");
        document.getElementById('FileUp').focus();
        return false;
    }
    return true;
}