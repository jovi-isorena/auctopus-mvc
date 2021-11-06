function time() {
    var endDateTime = document.getElementById("endDate").value;
    //set date and time here---------------------
    var time = new Date(endDateTime);
    
		var nowTime = new Date();
		var distance = time - nowTime;
		//console.log(endDateTime);
		var day = Math.floor(distance / (1000 * 60 * 60 * 24));
		var hov = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
		var min = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
		var sec = Math.floor((distance % (1000 * 60)) / 1000);

		document.querySelector('.days').innerHTML = "Days" + "<br><br>" + day;
		document.querySelector('.hours').innerHTML = "Hours" + "<br><br>" + hov;
		document.querySelector('.minutes').innerHTML = "Minutes" + "<br><br>" + min;
		document.querySelector('.seconds').innerHTML = "Seconds" + "<br><br>" + sec;

		if (distance <= 0) {
			clearInterval(osvezi);
			document.querySelector('.days').style.display = "none";
			document.querySelector('.hours').style.display = "none";
			document.querySelector('.minutes').style.display = "none";
			document.querySelector('.seconds').style.display = "none";
			document.querySelector('.end').style.display = "block";
			document.getElementById('NewBid_Amount').disabled = true;
			document.getElementById('newBid').disabled = true;
		}
	};


var osvezi = setInterval(time, 1000);
