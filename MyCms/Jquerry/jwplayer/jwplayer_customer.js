

jwplayer.key = "jVyLBg5xilJEPUJWXE3Wyf/bNdfXOWXwCcNgc4LTpu60J/PqizK0j8RHKSAkFR98";

jQuery(document).ready(function ($) {
    $(".link-video").click(function () {
        var video_link = $(this).attr("video-link"),
      data_image = $(this).attr("data-image"),
      video_width = $(this).parents(".video-player").width(),
      video_height = $(this).parents(".video-player").height(),
      video_id = $(this).parents(".video-player").attr("id");

        jwplayer(video_id).setup({
            primary: "html5",
            file: video_link,
            height: video_height,
            width: video_width,
            image: data_image,
            autostart: true,
            'logo.hide': true
        });
        return false;
    });
});