// var linkCons = 'http://soumghosh.com/otherProjects/Numbers/'

// var num = []; //this is an empty array to store the image urls
// var linkCons = "http://soumghosh.com/otherProjects/Numbers/";
// for(var i = 0; i < 10; i++) {
//     num.push(linkCons + "nw" + i + ".png");
// }

//clock starts here

setInterval(function(){
	// var future = new Date("October 28 2015 21:15:00 GMT+0200");
    var future = new Date("October 30 2015");
    var now = new Date();
    var difference = Math.floor((future.getTime() - now.getTime()) / 1000);

    var seconds = fixIntegers(difference % 60);
    difference = Math.floor(difference / 60);

    var minutes = fixIntegers(difference % 60);
    difference = Math.floor(difference / 60);

    var hours = fixIntegers(difference % 24);
    difference = Math.floor(difference / 24);

    var days = difference;

    $(".seconds").html(seconds + "<span>SECONDS<\/span>");
    $(".minutes").html(minutes + "<span>MINUTES<\/span>");
    $(".hours").html(hours + "<span>HOURS<\/span>");
    $(".days").html(days + "<span>DAYS<\/span>");
}, 1000);

function fixIntegers(integer)
{
    if (integer < 0)
        integer = 0;
    if (integer < 10)
        return "0" + integer;
    	return "" + integer;
}
