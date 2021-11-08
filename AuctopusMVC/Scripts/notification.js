$(document).ready(function () {
    var notificationBar = $('#notificationList');
    console.log(notificationBar.length);
    if (notificationBar.length > 0) {
        //notificationBar.prepend('<li><a class="dropdown-item" href="#">Notification 2</a></li>');
        setInterval(getNotifications, 5000);
    }
    
});

function getNotifications()
{
    var id = $('#sessionid').val();
    var dataurl = "/Notification/NotificationCount/" + id;
    $.ajax({
        url: dataurl,
        method: "GET",
        success: function (data) {
            data = JSON.parse(data);
            //$('#highestBid').text(data['Amount']);
            //$('#highestBidder').text(data['UserId']);
            //console.log(highestBid.val(), data['Amount']);
            console.log(data);
            var countPill = $('#notifCountPill')
            if (data != Number(countPill.text())) //there are change in unread notification count
            {
                $('#notificationAjax').submit();
                //console.log(jj.length);
                if (data > 0) { //unread notification is more than zero
                    $('#notificationAjax').submit();
                    //countPill.text(data);
                    //countPill.removeClass("d-none")
                }
                else
                {
                    //countPill.text('');
                    //countPill.addClass("d-none")
                }
                //console.log(countPill);
            }
        },
        error: function (err) {
            console.log(err.responseText)
        }
    });
}