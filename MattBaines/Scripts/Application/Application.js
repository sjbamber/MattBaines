// Element exists extension
$.fn.exists = function () {
    return this.length !== 0;
}

//function hexToR(h) { return parseInt((cutHex(h)).substring(0, 2), 16) }
//function hexToG(h) { return parseInt((cutHex(h)).substring(2, 4), 16) }
//function hexToB(h) { return parseInt((cutHex(h)).substring(4, 6), 16) }
//function cutHex(h) { return (h.charAt(0) == "#") ? h.substring(1, 7) : h }
//function 

// Displays an information dialog containing content in dialog_id
function show_dialog(dialog_id) {
    $(dialog_id).dialog({
        resizable: false,
        width: 400,
        modal: true,
        buttons: {
            'OK': function () {
                $(this).dialog('close');
            }
        }
    });
}

$(document).ready(function () {
    $('#advertisingcreative_link').click(function () {
        var target = $('#advertisingcreative');
        if (target.length) {
            var top = target.offset().top;
            $('html,body').animate({ scrollTop: top }, 600);
            return false;
        }
    });
    $('#workilike_link').click(function () {
        var target = $('#workilike');
        if (target.length) {
            var top = target.offset().top;
            $('html,body').animate({ scrollTop: top }, 600);
            return false;
        }
    });
    $('#morefromme_link').click(function () {
        var target = $('#morefromme');
        if (target.length) {
            var top = target.offset().top;
            $('html,body').animate({ scrollTop: top }, 600);
            return false;
        }
    });
    //if ($('#advertisingcreative').length != 0) {
    //    $.ajax({
    //        type: 'POST',
    //        url: '/Home/AdvertisingCreative',
    //        success: function (data) {
    //            $('#advertisingcreative').fadeOut().html(data).fadeIn();
    //        }
    //    });
    //}
    //if ($('#workilike').length != 0) {
    //    $.ajax({
    //        type: 'POST',
    //        url: '/Home/WorkILike',
    //        success: function (data) {
    //            $('#workilike').fadeOut().html(data).fadeIn();
    //        }
    //    });
    //}

    $('input:submit, .button, .button_small').button();

    // Display notice if it appears on the page
    if ($('#notice_dialog').exists()) {
        show_dialog('#notice_dialog');
    }

    $('#tj_container').gridnav({
        rows: 2,
        type: {
            mode: 'sequpdown', 		// use def | fade | seqfade | updown | sequpdown | showhide | disperse | rows
            speed: 500, 			// for fade, seqfade, updown, sequpdown, showhide, disperse, rows
            easing: '', 			// for fade, seqfade, updown, sequpdown, showhide, disperse, rows	
            factor: 50, 			// for seqfade, sequpdown, rows
            reverse: false				// for sequpdown
        }
    });

    $('.delete_button').click(function () {
        return confirm('Are you sure?');
    });
    Cufon.replace('#advertisingcreative h4', { fontFamily: 'THURSTON_erc' });
    Cufon.replace('#advertisingcreative .section_title p', { fontFamily: 'Sketch Block' });
    Cufon.replace('#main #sidebar ul li a', { fontFamily: 'THURSTON_erc' });
});

