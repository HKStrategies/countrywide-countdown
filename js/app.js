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

    $('.hero').parallax({imageSrc: '/images/agent-lineup-v1-small.jpg'});
});
