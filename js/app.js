$(document).foundation();

$(document).ready(function(){

    // Scroll to any link
	$('a[href^="#"]').on('click',function (e) {
	    e.preventDefault();

	    var target = this.hash;
	    var $target = $(target);

	    $('html, body').stop().animate({
	        'scrollTop': $target.offset().top
	    }, 900, 'swing', function () {
	        window.location.hash = target;
	    });
	});

	// Enable parallax on desktop
	if (Modernizr.mq('only screen and (min-width: 650px)')) {
	    $('.hero').parallax({imageSrc: '/images/agent-lineup-v1-small.jpg'});
	}

	// JSON DATA
	var organisation = [ "WHDH", "TF" ],
		region = [ "TF", "WHDH" ];


    $('#Organisation').empty(); // empty the drop down (if necessarry)
    $(organisation).each(function(iIndex, sElement) {
        $('#Organisation').append('<option>' + sElement + '</option>');
    });

	$('#Region').empty(); // empty the drop down (if necessarry)
    $(region).each(function(iIndex, sElement) {
        $('#Region').append('<option>' + sElement + '</option>');
    });
});
