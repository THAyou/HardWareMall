/** EasyWeb iframe v3.1.5 date:2019-10-05 License By http://easyweb.vip */
// 以下代码是配置layui扩展模块的目录，每个页面都需要引入
layui.config({
    version: '315',
    base: getProjectUrl() + 'assets/module/'
}).extend({
    formSelects: 'formSelects/formSelects-v4',
    treetable: 'treetable-lay/treetable',
    dropdown: 'dropdown/dropdown',
    notice: 'notice/notice',
    step: 'step-lay/step',
    dtree: 'dtree/dtree',
    citypicker: 'city-picker/city-picker',
    tableSelect: 'tableSelect/tableSelect',
    Cropper: 'Cropper/Cropper',
    zTree: 'zTree/zTree',
    introJs: 'introJs/introJs',
    fileChoose: 'fileChoose/fileChoose',
    tagsInput: 'tagsInput/tagsInput',
    Drag: 'Drag/Drag',
    CKEDITOR: 'ckeditor/ckeditor',
    Split: 'Split/Split',
    cascader: 'cascader/cascader',
    treeSelect: 'treeSelect/treeSelect'
}).use(['layer', 'admin'], function () {
    var $ = layui.jquery;
    var layer = layui.layer;
    var admin = layui.admin;

    // 移除loading动画
    setTimeout(function () {
        admin.removeLoading();
    }, window == top ? 600 : 100);


    var token = localStorage.getItem('token');
    $.ajaxSetup({
        //ajax请求加上header标头
        beforeSend: function (xhr) {
            //console.log(token);
            if (token) {
                xhr.setRequestHeader("Auth", token);
            }
        },
        error: function (xhr) {
            var msg = xhr.responseText ? xhr.responseText : "服务器异常";
            if (xhr.status == 401) {
                layer.msg(msg, { icon: 5, time: 2000 }, function () {
                    location.replace('/system/login');
                });
            }
            else if (xhr.status == 500) {
                layer.closeAll('loading');
                var res = JSON.parse(msg);
                layer.msg(res.message, { icon: 5, time: 2000 });
            }
            else {
                layer.closeAll('loading');
                layer.msg(msg, { icon: 5, time: 2000 });
            }
        }
    });
});

// 获取当前项目的根路径，通过获取layui.js全路径截取assets之前的地址
function getProjectUrl() {
    var layuiDir = layui.cache.dir;
    if (!layuiDir) {
        var js = document.scripts, last = js.length - 1, src;
        for (var i = last; i > 0; i--) {
            if (js[i].readyState === 'interactive') {
                src = js[i].src;
                break;
            }
        }
        var jsPath = src || js[last].src;
        layuiDir = jsPath.substring(0, jsPath.lastIndexOf('/') + 1);
    }
    return layuiDir.substring(0, layuiDir.indexOf('assets'));
}