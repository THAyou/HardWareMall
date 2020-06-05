/*
 Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
*/
// 渲染富文本编辑器
var xmlHttp = new XMLHttpRequest();
var token = localStorage.getItem('token');
var data = [];
xmlHttp.onreadystatechange = function () {
    if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
        data = JSON.parse(xmlHttp.responseText);
    }
}
xmlHttp.open("GET", APIURL + "/EmailTemplate/GetCkTemps", false);
if (token) {
    xmlHttp.setRequestHeader("Auth", token);
}
xmlHttp.send();
CKEDITOR.addTemplates("default", {
    imagesPath: CKEDITOR.getUrl(CKEDITOR.plugins.getPath("templates") + "templates/images/"),
    templates: data
});