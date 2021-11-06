
$(document).ready(function () {
    var itemId = document.getElementById("Item_AuctionedItemId").value;
    setInterval(getHighestBid, 1000);
});
function getHighestBid() {

    var id = $('#Item_AuctionedItemId').val();
    var dataurl = "/Bid/HighestBid/" + id;
    $.ajax({
        url: dataurl,
        method: "GET",
        success: function (data) {
            data = JSON.parse(data);
            var highestBid = $('#Amount');
            //$('#highestBid').text(data['Amount']);
            //$('#highestBidder').text(data['UserId']);
            //console.log(highestBid.val(), data['Amount']);
            if (Number(highestBid.val()) !== data['Amount']) {
                $('#ajaxform').submit();
                //console.log('update');
            } else {
                //console.log('not update');
            }
        },
        error: function (err) {
            console.log(err.responseText)
        }
    });
}


//$(document).ready(function () {
//    setInterval(getHighestBid, 1000);
//});
//function getHighestBid() {
//    $('#ajaxform').submit();
//    console.log('bid');
//}