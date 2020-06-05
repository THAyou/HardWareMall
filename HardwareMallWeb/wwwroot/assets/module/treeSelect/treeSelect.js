layui.define('jquery', function (exports) {
    var $ = layui.$;
    layui.link(layui.cache.base + 'treeSelect/treeSelect.css');
    //id div 的id，isMultiple 是否多选，default 默认选择，chkboxType 多选框类型{"Y": "ps", "N": "s"} 详细请看ztree官网
    var obj = {
        initSelectTree: function (id, zNodes, isMultiple, selectValue, chkboxType) {
            var setting = {
                view: {
                    dblClickExpand: false,
                    showLine: false
                },
                data: {
                    simpleData: {
                        enable: true
                    }
                },
                check: {
                    enable: false,
                    chkboxType: { "Y": "ps", "N": "s" }
                },
                callback: {
                    onClick: obj.onClick,
                    onCheck: obj.onCheck
                }
            };
            if (isMultiple) {
                setting.check.enable = isMultiple;
            }
            if (chkboxType !== undefined && chkboxType != null) {
                setting.check.chkboxType = chkboxType;
            }

            var html = '<div class = "layui-select-title" >' +
                '<input id="' + id + 'Show"' + 'type = "text" placeholder = "选择" value = "" class = "layui-input" lay-vertype="tips" lay-verify="required" readonly>' +
                '<i class= "layui-edge" ></i>' +
                '</div>';
            $("#" + id).append(html);
            $("#" + id).parent().append('<div class="tree-content scrollbar">' +
                '<input type="hidden" id="' + id + 'Hide" ' +
                'name="' + id + '" value="0" />' +
                '<ul id="' + id + 'Tree" class="ztree scrollbar" style="margin-top:0;"></ul>' +
                '</div>');
            $("#" + id).bind("click", function () {
                if ($(this).parent().find(".tree-content").css("display") !== "none") {
                    obj.hideMenu()
                } else {
                    $(this).addClass("layui-form-selected");
                    var Offset = $(this).offset();
                    var width = $(this).width() - 2;
                    $(this).parent().find(".tree-content").css({
                        left: Offset.left + "px",
                        top: Offset.top + $(this).height() + "px"
                    }).slideDown("fast");
                    $(this).parent().find(".tree-content").css({
                        width: width
                    });
                    $("body").bind("mousedown", obj.onBodyDown);
                }
            });
            $.fn.zTree.init($("#" + id + "Tree"), setting, zNodes);
            var treeObj = $.fn.zTree.getZTreeObj("" + id + "Tree");
            var node = treeObj.getNodeByParam("id", selectValue);//根据ID找到该节点
            if (node != null) {
                $("#" + id + "Show").attr("value", node.name);
                $("#" + id + "Show").attr("title", node.name);
                treeObj.selectNode(node);//根据该节点选中
                var parent = node.getParentNode();
                treeObj.expandNode(parent, true, true);
            }
        },

        initSelectTreeV: function (id, zNodes, isMultiple, selectValue, IsValidation, TipsText, chkboxType) {
            var setting = {
                view: {
                    dblClickExpand: false,
                    showLine: false
                },
                data: {
                    simpleData: {
                        enable: true
                    }
                },
                check: {
                    enable: false,
                    chkboxType: { "Y": "ps", "N": "s" }
                },
                callback: {
                    onClick: obj.onClick,
                    onCheck: obj.onCheck
                }
            };
            if (isMultiple) {
                setting.check.enable = isMultiple;
            }
            if (chkboxType !== undefined && chkboxType != null) {
                setting.check.chkboxType = chkboxType;
            }

            var html = '<div class = "layui-select-title" >' +
                '<input id="' + id + 'Show"' + 'type = "text" placeholder = "' + TipsText + '" value = "" class = "layui-input" ' + (IsValidation ? 'lay-vertype="tips" lay-verify="required"' : '') + ' readonly>' +
                '<i class= "layui-edge" ></i>' +
                '</div>';
            $("#" + id).append(html);
            $("#" + id).parent().append('<div class="tree-content scrollbar">' +
                '<input type="hidden" id="' + id + 'Hide" ' +
                'name="' + id + '" value="0" />' +
                '<ul id="' + id + 'Tree" class="ztree scrollbar" style="margin-top:0;"></ul>' +
                '</div>');
            $("#" + id).bind("click", function () {
                if ($(this).parent().find(".tree-content").css("display") !== "none") {
                    obj.hideMenu()
                } else {
                    $(this).addClass("layui-form-selected");
                    var Offset = $(this).offset();
                    var width = $(this).width() - 2;
                    $(this).parent().find(".tree-content").css({
                        left: Offset.left + "px",
                        top: Offset.top + $(this).height() + "px"
                    }).slideDown("fast");
                    $(this).parent().find(".tree-content").css({
                        width: width
                    });
                    $("body").bind("mousedown", obj.onBodyDown);
                }
            });
            $.fn.zTree.init($("#" + id + "Tree"), setting, zNodes);
            var treeObj = $.fn.zTree.getZTreeObj("" + id + "Tree");
            var node = treeObj.getNodeByParam("id", selectValue);//根据ID找到该节点
            if (node != null) {
                $("#" + id + "Show").attr("value", node.name);
                $("#" + id + "Show").attr("title", node.name);
                treeObj.selectNode(node);//根据该节点选中
                var parent = node.getParentNode();
                treeObj.expandNode(parent, true, true);
            }
        },

        initSelectTreeVSimple: function (id, zNodes, isMultiple, selectValue, chkboxType) {
            var setting = {
                view: {
                    dblClickExpand: false,
                    showLine: false
                },
                data: {
                    simpleData: {
                        enable: true
                    }
                },
                check: {
                    enable: false,
                    chkboxType: { "Y": "ps", "N": "s" }
                },
                callback: {
                    onClick: obj.onClick,
                    onCheck: obj.onCheck
                }
            };
            if (isMultiple) {
                setting.check.enable = isMultiple;
            }
            if (chkboxType !== undefined && chkboxType != null) {
                setting.check.chkboxType = chkboxType;
            }

            var html = '<div class = "layui-select-title" >' +
                '<input id="' + id + 'Show"' + 'type = "text" placeholder = "选择" value = "" class = "layui-input" lay-vertype="tips" lay-verify="required" readonly>' +
                '<i class= "layui-edge" ></i>' +
                '</div>';
            $("#" + id).append(html);
            $("#" + id).parent().append('<div class="tree-content scrollbar">' +
                '<input type="hidden" id="' + id + 'Hide" ' +
                'name="' + id + '" value="0" />' +
                '<ul id="' + id + 'Tree" class="ztree scrollbar" style="margin-top:0;"></ul>' +
                '</div>');
            $("#" + id).bind("click", function () {
                if ($(this).parent().find(".tree-content").css("display") !== "none") {
                    obj.hideMenu()
                } else {
                    $(this).addClass("layui-form-selected");
                    var Offset = $(this).offset();
                    var width = $(this).width() - 2;
                    $(this).parent().find(".tree-content").css({
                        left: Offset.left + "px",
                        top: Offset.top + $(this).height() + "px"
                    }).slideDown("fast");
                    $(this).parent().find(".tree-content").css({
                        width: width
                    });
                    $(this).parent().find(".noline_docu").hide();
                    $("body").bind("mousedown", obj.onBodyDown);
                }
            });
            $.fn.zTree.init($("#" + id + "Tree"), setting, zNodes);

            var treeObj = $.fn.zTree.getZTreeObj("" + id + "Tree");
            var node = treeObj.getNodeByParam("id", selectValue);//根据ID找到该节点
            if (node != null) {
                $("#" + id + "Show").attr("value", node.name);
                $("#" + id + "Show").attr("title", node.name);
                treeObj.selectNode(node);//根据该节点选中
                var parent = node.getParentNode();
                treeObj.expandNode(parent, true, true);
            }
        },

        beforeClick: function (treeId, treeNode) {
            var check = (treeNode && !treeNode.isParent);
            if (!check) alert("只能选择...");
            return check;
        },
        onClick: function (event, treeId, treeNode) {
            var zTree = $.fn.zTree.getZTreeObj(treeId);
            if (zTree.setting.check.enable == true) {
                zTree.checkNode(treeNode, !treeNode.checked, false)
                obj.assignment(treeId, zTree.getCheckedNodes());
            } else {
                obj.assignment(treeId, zTree.getSelectedNodes());
                obj.hideMenu();
            }
        },
        onCheck: function (event, treeId, treeNode) {
            var zTree = $.fn.zTree.getZTreeObj(treeId);
            obj.assignment(treeId, zTree.getCheckedNodes());
        },
        hideMenu: function () {
            $(".select-tree").removeClass("layui-form-selected");
            $(".tree-content").fadeOut("fast");
            $("body").unbind("mousedown", obj.onBodyDown);
        },
        assignment: function (treeId, nodes) {
            var names = "";
            var ids = "";
            for (var i = 0, l = nodes.length; i < l; i++) {
                names += nodes[i].name + ",";
                ids += nodes[i].id + ",";
            }
            if (names.length > 0) {
                names = names.substring(0, names.length - 1);
                ids = ids.substring(0, ids.length - 1);
            }
            treeId = treeId.substring(0, treeId.length - 4);
            $("#" + treeId + "Show").attr("value", names);
            $("#" + treeId + "Show").attr("title", names);
            $("#" + treeId + "Hide").attr("value", ids);
        },
        onBodyDown: function (event) {
            if ($(event.target).parents(".tree-content").html() == null) {
                obj.hideMenu();
            }
        }
    };
    exports('treeSelect', obj);
});