// Element exists extension
$.fn.exists = function () {
    return this.length !== 0;
}

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
});

