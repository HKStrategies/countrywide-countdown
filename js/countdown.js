// var linkCons = 'http://soumghosh.com/otherProjects/Numbers/'

// var num = []; //this is an empty array to store the image urls
// var linkCons = "http://soumghosh.com/otherProjects/Numbers/";
// for(var i = 0; i < 10; i++) {
//     num.push(linkCons + "nw" + i + ".png");
// }

//clock starts here

$(function () {

    // var future = new Date("October 19 2015 11:50:00 GMT+0200");
    var url = "http://www.google.com"; // ex: "/index.php" , "../" , "/"
    var future = new Date("October 28 2015");

    var _countdown = function () {

        var now = new Date();
        var difference = Math.floor((future.getTime() - now.getTime()) / 1000);

        //Timer reaches 0 - Redirect
        if (difference <= 0) {
            window.location = url;
            difference = 0;
        }

        var seconds = fixIntegers(difference % 60);
        difference = Math.floor(difference / 60);

        var minutes = fixIntegers(difference % 60);
        difference = Math.floor(difference / 60);

        var hours = fixIntegers(difference % 24);
        difference = Math.floor(difference / 24);

        var days = fixIntegers(difference);

        //"Also when the day reaches 00 and their is < 24 hrs to, i would like to add a CSS class to the page somewhere."
        if (days < 1) {
            $('.days').addClass("opacity_05");
        }

        $(".seconds").html(seconds + "<span>SECONDS<\/span>");
        $(".minutes").html(minutes + "<span>MINUTES<\/span>");
        $(".hours").html(hours + "<span>HOURS<\/span>");
        $(".days").html(days + "<span>DAYS<\/span>");
    };

    _countdown(); //Execute immediately to avoid 1 sec delay
    setInterval(_countdown, 1000);

    function fixIntegers(integer) {
        if (integer < 0)
            integer = 0;
        if (integer < 10)
            return "0" + integer;
        return "" + integer;
    }

});
