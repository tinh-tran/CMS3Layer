/**
 * @license Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    config.uiColor = '#CECECE';
    // config.skins = 'officeXP';
    config.filebrowserBrowseUrl = '/Scripts/ckfinder/ckfinder.html';
    config.htmlEncodeOutput = false;
    config.entities = false;
//  config.filebrowserImageBrowseUrl = '/Scripts/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserImageBrowseUrl = '/Scripts/ckfinder/ckfinder.html';
    config.filebrowserFlashBrowseUrl = '/Scripts/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
//    config.filebrowserImageUploadUrl = '/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserImageUploadUrl = '/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload';
    config.filebrowserFlashUploadUrl = '/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
