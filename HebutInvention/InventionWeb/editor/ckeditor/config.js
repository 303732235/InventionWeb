/*
Copyright (c) 2003-2009, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.enterMode = CKEDITOR.ENTER_BR;
    config.shiftEnterMode = CKEDITOR.ENTER_P;
    //    var ckfinderPath = "/editor";
    config.filebrowserBrowseUrl = '/editor/CKFinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/editor/CKFinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/editor/CKFinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/editor/CKFinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/editor/CKFinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/editor/CKFinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.filebrowserWindowWidth = '800';
    config.filebrowserWindowHeight = '500';
    config.height = '300';
    config.width = '800';
    //    config.width = 300;
    config.font_names = '宋体/宋体;黑体/黑体;微软雅黑/微软雅黑;' + config.font_names;
    //config.defaultLanguage = 'zh-cn'
    //默认的字体名 plugins/font/plugin.js
    //config.font_defaultLabel = '宋体';
    CKEDITOR.config.toolbar_Custom = [
		    ['PasteFromWord', '-', 'Print'],
		    ['Undo', 'Redo'],
		    ['Bold', 'Italic', 'Underline', 'Subscript', 'Superscript'],
		    ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
		    ['Link', 'Unlink', 'Anchor'],
		    ['Image', 'Flash', 'Table'], ['Font', 'FontSize'],
		    ['TextColor', 'BGColor']
    ];
    config.toolbar = 'Custom';




};
