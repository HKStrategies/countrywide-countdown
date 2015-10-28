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

	// JSON DATA

	var organisation = ["Abbotts Countrywide","Accord Lets Lettings","Alan de Maid","Alder King Lettings","Andrew Reeves Lettings","APW Lettings","Ashton Burkinshaw Lettings","Austin & Wyatt","Bairstow Eves","Beresford Adams","Blundells","Bridgfords","Carson & Co.","Chappell & Matthews","CHK Mountford Lettings","Country & Waterside Prestige","Countrywide","Countrywide Estate Management","Countrywide North","Countrywide Property Auctions","Countrywide Scotland Lettings","Cryers Residential Lettings","Dixons","Entwistle Green","Faron Sutaria","Flats in Leeds","Frank Innes","Freeman Forman ","Fulfords","Gascoigne Pees","Geering & Colyer","Greene & Co","Hamptons International","Hartleys Lettings","HE Lettings","Hetheringtons","Jayne & Moss Lettings","JK Lettings","John D Wood & Co.","King & Chasemore","Land & New Homes","Lanes Lettings","Lighthouse Property Services","Mann","Merchant Lettings","Mid Cornwall Lettings","Miller Countrywide","Morris Dibben","Palmer Snell","Property Click","PropertyLinks","R. A. Bennett & Partners","Regal Lettings","Richard Trowbridge Lettings","Russells","Slater Hogg & Howison","Spencers","Stratton Creber Countrywide","Surveying","Taylors","Underwoods Lettings","Watson Bull & Porter","Wilson Peacock"],
    region = ["East Midlands","East of England","Lincolnshire","London","North East & Cumbria","North Ireland/Ulster","North West","Scotland","South East","South West","Wales","West ","West Midlands","Yorkshire"];

    // $('#Organisation').empty(); // empty the dropdown (if necessarry)
    	$(organisation).each(function(iIndex, sElement) {
	        $('#Organisation').append('<option>' + sElement + '</option>');
	    });

	// $('#Region').empty(); // empty the dropdown (if necessarry)
    	$(region).each(function(iIndex, sElement) {
	        $('#Region').append('<option>' + sElement + '</option>');
	    });

	// Character Count

	var text_max = 300;

	$('#textarea_feedback').html(text_max + ' characters remaining');

    $('#Reason').keyup(function() {
        var text_length = $('#Reason').val().length;
        var text_remaining = text_max - text_length;

        $('#textarea_feedback').html(text_remaining + ' characters remaining');
    });

});
