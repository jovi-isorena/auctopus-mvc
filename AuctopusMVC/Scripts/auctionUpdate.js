$(document).ready(function () {
    var isAdmin = $('#isAdmin').length
    if (isAdmin > 0) {
        setInterval(updateAuction, 5000);
    }
});

function updateAuction() {
    var dataurl = "/AuctionedItem/CloseAllEndedAuction";
    $.ajax({
        url: dataurl,
        method: "GET",
        success: function (data) {
            console.log(data)
        },
        error: function (err) {
            console.log(err)
        }
    });
}